using Microsoft.ML;
using Microsoft.ML.Data;
using MLTestAppOne.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Transforms.TimeSeries;

namespace MLTestAppOne
{
    class Program
    {
        static void Main(string[] args)
        {
            SQLConnector sqlConnector = new SQLConnector();
            DWPerformanceSeries dps = new DWPerformanceSeries(372, 1252);
            SqlConnection sqlConnection = sqlConnector.GetSqlConnection();
            dps.PopulatePerformanceEntries(sqlConnection);



            /// Do the ML magic?
            /// 

            string sqlQuery = dps.GetQuery();
            string conString = "Server=Infra-SQL01.cookdown.local;Database=Ops16DW;User Id=NathanSQL;Password=JamieJo!!;";
            MLContext mlContext = new MLContext();
            //DatabaseLoader loader = mlContext.Data.CreateDatabaseLoader<ModelInput>();
            //DatabaseSource dbSource = new DatabaseSource(SqlClientFactory.Instance, conString, sqlQuery, 25);
            //IDataView dataView = loader.Load(dbSource);
            
            IDataView dataView = mlContext.Data.LoadFromEnumerable(dps.PerformanceEntries);

            // Filter to two datasets for testing
            //IDataView firstYearData = mlContext.Data.FilterRowsByColumn(dataView, "Year", upperBound: 1);
            //IDataView secondYearData = mlContext.Data.FilterRowsByColumn(dataView, "ReadingValue", lowerBound: 1);

            SsaForecastingEstimator forecastingPipeline = mlContext.Forecasting.ForecastBySsa(
                            outputColumnName: "ForecastedValues",
                            inputColumnName: "Value",
                            windowSize: 20,
                            seriesLength: 60,
                            trainSize: 200,
                            horizon: 200,
                            confidenceLevel: 0.95f,
                            confidenceLowerBoundColumn: "LowerBoundValues",
                            confidenceUpperBoundColumn: "UpperBoundValues");
            
            SsaForecastingTransformer forecaster = forecastingPipeline.Fit(dataView);
            var forecastEngine = forecaster.CreateTimeSeriesEngine<PerformanceEntry, ModelOutput>(mlContext);
            ModelOutput results = forecastEngine.Predict();   
        }

        static void Evaluate(IDataView testData, ITransformer model, MLContext mlContext)
        {
            // Make predictions
            IDataView predictions = model.Transform(testData);

            // Actual values
            IEnumerable<float> actual =
                mlContext.Data.CreateEnumerable<PerformanceEntry>(testData, true)
                    .Select(observed => observed.Value);

            // Predicted values
            IEnumerable<float> forecast =
                mlContext.Data.CreateEnumerable<ModelOutput>(predictions, true)
                    .Select(prediction => prediction.ForecastedValues[0]);

            // Calculate error (actual - forecast)
            var metrics = actual.Zip(forecast, (actualValue, forecastValue) => actualValue - forecastValue);

            // Get metric averages
            var MAE = metrics.Average(error => Math.Abs(error)); // Mean Absolute Error
            var RMSE = Math.Sqrt(metrics.Average(error => Math.Pow(error, 2))); // Root Mean Squared Error

            // Output metrics
            Console.WriteLine("Evaluation Metrics");
            Console.WriteLine("---------------------");
            Console.WriteLine($"Mean Absolute Error: {MAE:F3}");
            Console.WriteLine($"Root Mean Squared Error: {RMSE:F3}\n");
        }

    }
}
