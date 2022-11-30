using Meziantou.Framework.Win32;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using ScomForecastingEngine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScomForecastingUI
{
    public partial class DWPerformancePicker : UserControl
    {
        public string ConnectionString { get; set; }

        public Dictionary<string, int> ManagedEntityTypes { get; set; }
        public Dictionary<string, int> PerformanceRuleRows { get; set; }
        public Dictionary<string, DWPerformanceSeries> PerformanceRuleInstanceRows { get; set; }
        public DWPerformancePicker()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var creds = CredentialManager.PromptForCredentials(
                captionText: $"{textBoxDWDB.Text} @ {textBoxSqlServer.Text}",
                messageText: "This will allow the app to connect to your SQL Data Warehouse and get performance data",
                saveCredential: CredentialSaveOption.Hidden
                );

            if (creds.UserName != null && creds.Password != null)
            {
                button1.Text = "I have your password!";

                ConnectionString = $"Server={textBoxSqlServer.Text};Database={textBoxDWDB.Text};User Id={creds.UserName};Password={creds.Password};";
            }

            PopulateManagedEntityTypes();
        }

        private void PopulateManagedEntityTypes()
        {
            ManagedEntityTypes = new Dictionary<string, int>();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cm = new SqlCommand("SELECT [ManagedEntityTypeRowId] [metRowId], [ManagedEntityTypeDefaultName] [Name] FROM [dbo].[vManagedEntityType] Where [ManagedEntityTypeRowId] in (Select Distinct ManagedEntityTypeRowId from vManagedEntity where ManagedEntityRowId in (SELECT Distinct [ManagedEntityRowId] FROM [Perf].[vPerfRaw])) Order By 2 Asc", connection);
                connection.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    if (!ManagedEntityTypes.ContainsKey(sdr[1].ToString()))
                    {
                        ManagedEntityTypes.Add(sdr[1].ToString(), int.Parse(sdr[0].ToString()));
                    }
                }
            }

            comboBoxClassPicker.Items.AddRange(ManagedEntityTypes.Keys.ToArray());
            comboBoxClassPicker.Text = "Please select a class";

            comboBoxClassPicker.SelectedIndexChanged += ComboBoxClassPicker_SelectedIndexChanged;
        }

        private void ComboBoxClassPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            int managedEntityTypeId = ManagedEntityTypes[comboBoxClassPicker.Text];
            PerformanceRuleRows = new Dictionary<string, int>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cm = new SqlCommand($";with MostRecentMPs AS ( SELECT Max([ManagementPackVersionRowId]) CurrentMPVersionRowId, [ManagementPackRowId] FROM [dbo].[vManagementPackVersion] Group By [ManagementPackRowId] ), EntityTargetRules AS ( SELECT [RuleRowId] FROM [dbo].[vRuleManagementPackVersion] ruleMPVersion Where ruleMPVersion.ManagementPackVersionRowId in ( Select CurrentMPVersionRowId from MostRecentMPs ) and TargetManagedEntityTypeRowId in ( SELECT ManagedEntityTypeRowId FROM [dbo].[ManagedEntityDerivedTypeHierarchy] ({managedEntityTypeId}, 12) ) ), PerformanceCounters AS ( SELECT [RuleRowId], [ObjectName], [CounterName], [MultiInstanceInd] FROM [dbo].[vPerformanceRule] perfRules Where perfRules.RuleRowId in ( Select RuleRowId from EntityTargetRules ) ) SELECT rules.RuleRowId, RuleDefaultName, ObjectName, CounterName, MultiInstanceInd FROM [dbo].[vRule] rules Inner Join PerformanceCounters on rules.RuleRowId = PerformanceCounters.RuleRowId", connection);
                connection.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    if (!PerformanceRuleRows.ContainsKey(sdr["RuleDefaultName"].ToString()))
                    {
                        PerformanceRuleRows.Add(sdr["RuleDefaultName"].ToString(), int.Parse(sdr["RuleRowId"].ToString()));
                    }
                }
            }

            comboBoxPerfRules.Items.AddRange(PerformanceRuleRows.Keys.ToArray());
            comboBoxPerfRules.Text = "Please choose a performance rule";

            comboBoxPerfRules.SelectedIndexChanged += ComboBoxPerfRules_SelectedIndexChanged;

        }

        private void ComboBoxPerfRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            int performanceRuleRow = PerformanceRuleRows[comboBoxPerfRules.Text];
            PerformanceRuleInstanceRows = new Dictionary<string, DWPerformanceSeries>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cm = new SqlCommand($";with PerformanceRuleInstances AS ( SELECT [PerformanceRuleInstanceRowId], InstanceName FROM [dbo].[vPerformanceRuleInstance] Where RuleRowId = {performanceRuleRow} ), PerformanceResults AS ( SELECT [DateTime], [PerformanceRuleInstanceRowId], [ManagedEntityRowId], [SampleValue] FROM [Perf].[vPerfRaw] Where PerformanceRuleInstanceRowId in ( Select PerformanceRuleInstanceRowId from PerformanceRuleInstances ) ) SELECT [Path] + '; ' + [ManagedEntityDefaultName] + ' ( ' + PerformanceRuleInstances.InstanceName + ' ) ' [Name], PerformanceRuleInstances.[PerformanceRuleInstanceRowId], vme.[ManagedEntityRowId] FROM [dbo].[vManagedEntity] vme Inner Join PerformanceResults on vme.ManagedEntityRowId = PerformanceResults.ManagedEntityRowId Inner Join PerformanceRuleInstances on PerformanceResults.PerformanceRuleInstanceRowId = PerformanceRuleInstances.PerformanceRuleInstanceRowId group by [Path] + '; ' + [ManagedEntityDefaultName] + ' ( ' + PerformanceRuleInstances.InstanceName + ' ) ', PerformanceRuleInstances.[PerformanceRuleInstanceRowId], vme.[ManagedEntityRowId]", connection);
                connection.Open();
                SqlDataReader sdr = cm.ExecuteReader();
                while (sdr.Read())
                {
                    if (!PerformanceRuleInstanceRows.ContainsKey(sdr["Name"].ToString()))
                    {
                        PerformanceRuleInstanceRows.Add(sdr["Name"].ToString(), new DWPerformanceSeries(int.Parse(sdr["ManagedEntityRowId"].ToString()), int.Parse(sdr["PerformanceRuleInstanceRowId"].ToString())));
                    }
                }
            }

            comboBoxEntity.Items.AddRange(PerformanceRuleInstanceRows.Keys.ToArray());
            comboBoxEntity.Text = "Please choose an entity / instance";

            comboBoxEntity.SelectedIndexChanged += ComboBoxEntity_SelectedIndexChanged;
        }

        private void ComboBoxEntity_SelectedIndexChanged(object sender, EventArgs e)
        {
            DWPerformanceSeries selectedSeries = PerformanceRuleInstanceRows[comboBoxEntity.Text];
            selectedSeries.PopulatePerformanceEntries(ConnectionString);

            dataGridViewHistory.DataSource = selectedSeries.PerformanceEntries;
            List<ForecastRecord> forecastRecords = selectedSeries.PerformForecast((int)numericWindowSize.Value, (int)numericSeriesLength.Value, (int)numericTrainSize.Value, (int)numericHorizon.Value, (float)numericConfidence.Value);
            dataGridViewForecast.DataSource = forecastRecords;
        }

        private void PerformForecast(DWPerformanceSeries selectedSeries, int windowSize, int seriesLength, int trainSize, int horizon, float confidenceLevel)
        {
            MLContext mlContext = new MLContext();
            IDataView dataView = mlContext.Data.LoadFromEnumerable(selectedSeries.PerformanceEntries);
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

            List<ForecastRecord> forecastRecords = ForecastRecord.CreateForecastRecords(results, selectedSeries.AverageSeperationSeconds);
            dataGridViewForecast.DataSource = forecastRecords;
        }

        private void DWPerformancePicker_Load(object sender, EventArgs e)
        {

        }
    }
}
