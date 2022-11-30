using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScomForecastingEngine.Models
{
    public class DWPerformanceSeries
    {
        const string dwQuery = ";with PerformanceRuleInstances AS ( SELECT [PerformanceRuleInstanceRowId], InstanceName FROM [dbo].[vPerformanceRuleInstance] Where RuleRowId = {0} ), PerformanceResults AS ( SELECT [DateTime], [SampleValue] FROM [Perf].[vPerfRaw] Where PerformanceRuleInstanceRowId in ( Select PerformanceRuleInstanceRowId from PerformanceRuleInstances ) and ManagedEntityRowId = {1} ) SELECT cast(SampleValue as float) [ReadingValue], [DateTime] [ReadingDateTime] FROM PerformanceResults";

        public int ManagedEntityRowId { get; set; }
        public int PerformanceRuleInstanceRowId { get; set; }
        public double AverageSeperationSeconds { get; set; }

        internal string GetQuery()
        {
            return string.Format(dwQuery, PerformanceRuleInstanceRowId, ManagedEntityRowId);
        }

        public List<PerformanceEntry> PerformanceEntries { get; set; }
        public DWPerformanceSeries(int managedEntityRowId, int performanceRuleInstanceRowId)
        {
            ManagedEntityRowId = managedEntityRowId;
            PerformanceRuleInstanceRowId = performanceRuleInstanceRowId;
            PerformanceEntries = new List<PerformanceEntry>();
        }

        public void PopulatePerformanceEntries(SqlConnection connection)
        {
            SqlCommand cm = new SqlCommand(string.Format(dwQuery, PerformanceRuleInstanceRowId, ManagedEntityRowId), connection);
            // Executing the SQL query  
            SqlDataReader sdr = cm.ExecuteReader();
            DateTime previousReading = DateTime.MinValue;
            long ageInSeconds = 0;
            while (sdr.Read())
            {
                while (sdr.Read())
                {
                    if (previousReading != DateTime.MinValue)
                    {
                        ageInSeconds = (long)Math.Abs((DateTime.Parse(sdr[1].ToString()) - previousReading).TotalSeconds);
                    }
                    PerformanceEntries.Add(new PerformanceEntry(float.Parse(sdr[0].ToString()), DateTime.Parse(sdr[1].ToString()), ageInSeconds));
                    previousReading = DateTime.Parse(sdr[1].ToString());
                }
            }
        }

        public void PopulatePerformanceEntries(string connectionString)
        {
            if (PerformanceEntries.Count > 10)
            {
                //return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cm = new SqlCommand($"SELECT TOP (10000) [SampleValue],[DateTime] FROM [Ops16DW].[Perf].[vPerfRaw] Where PerformanceRuleInstanceRowId = {PerformanceRuleInstanceRowId} and ManagedEntityRowId = {ManagedEntityRowId}", connection);
                connection.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                DateTime previousReading = DateTime.MinValue;
                long ageInSeconds = 0;
                while (sdr.Read())
                {
                    while (sdr.Read())
                    {
                        if (previousReading != DateTime.MinValue)
                        {
                            ageInSeconds = (long)Math.Abs((DateTime.Parse(sdr[1].ToString()) - previousReading).TotalSeconds);
                        }
                        PerformanceEntries.Add(new PerformanceEntry(float.Parse(sdr[0].ToString()), DateTime.Parse(sdr[1].ToString()), ageInSeconds));
                        previousReading = DateTime.Parse(sdr[1].ToString());
                    }
                }

                AverageSeperationSeconds = Math.Round(PerformanceEntries.Select(p => p.RelativeAgeSeconds).Average(),2);
            }
        }

        public List<ForecastRecord> PerformForecast(int windowSize, int seriesLength, int trainSize, int horizon, float confidenceLevel)
        {
            MLContext mlContext = new MLContext();
            IDataView dataView = mlContext.Data.LoadFromEnumerable(PerformanceEntries);
            SsaForecastingEstimator forecastingPipeline = mlContext.Forecasting.ForecastBySsa(
                            outputColumnName: "ForecastedValues",
                            inputColumnName: "Value",
                            windowSize: windowSize,
                            seriesLength: seriesLength,
                            trainSize: trainSize,
                            horizon: horizon,
                            confidenceLevel: confidenceLevel,
                            confidenceLowerBoundColumn: "LowerBoundValues",
                            confidenceUpperBoundColumn: "UpperBoundValues");

            SsaForecastingTransformer forecaster = forecastingPipeline.Fit(dataView);
            var forecastEngine = forecaster.CreateTimeSeriesEngine<PerformanceEntry, ModelOutput>(mlContext);
            ModelOutput results = forecastEngine.Predict();

            List<ForecastRecord> forecastRecords = ForecastRecord.CreateForecastRecords(results, AverageSeperationSeconds);
            return forecastRecords;
        }
    }
}
