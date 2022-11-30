
namespace ScomForecastingUI
{
    partial class DWPerformancePicker
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxSqlServer = new System.Windows.Forms.TextBox();
            this.labelSqlServer = new System.Windows.Forms.Label();
            this.labelDWDatabase = new System.Windows.Forms.Label();
            this.textBoxDWDB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxClassPicker = new System.Windows.Forms.ComboBox();
            this.labelScomObjectClass = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPerfRules = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxEntity = new System.Windows.Forms.ComboBox();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timestampDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relativeAgeSecondsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.performanceEntryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewForecast = new System.Windows.Forms.DataGridView();
            this.forecastDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.predictedValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowerBoundDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.upperBoundDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forecastRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericWindowSize = new System.Windows.Forms.NumericUpDown();
            this.numericSeriesLength = new System.Windows.Forms.NumericUpDown();
            this.numericTrainSize = new System.Windows.Forms.NumericUpDown();
            this.numericHorizon = new System.Windows.Forms.NumericUpDown();
            this.numericConfidence = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceEntryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForecast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forecastRecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeriesLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTrainSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHorizon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericConfidence)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSqlServer
            // 
            this.textBoxSqlServer.Location = new System.Drawing.Point(54, 65);
            this.textBoxSqlServer.Name = "textBoxSqlServer";
            this.textBoxSqlServer.Size = new System.Drawing.Size(244, 20);
            this.textBoxSqlServer.TabIndex = 0;
            this.textBoxSqlServer.Text = "infra-sql01.cookdown.local";
            // 
            // labelSqlServer
            // 
            this.labelSqlServer.AutoSize = true;
            this.labelSqlServer.Location = new System.Drawing.Point(51, 42);
            this.labelSqlServer.Name = "labelSqlServer";
            this.labelSqlServer.Size = new System.Drawing.Size(156, 13);
            this.labelSqlServer.TabIndex = 1;
            this.labelSqlServer.Text = "SCOM Data Warehouse Server";
            // 
            // labelDWDatabase
            // 
            this.labelDWDatabase.AutoSize = true;
            this.labelDWDatabase.Location = new System.Drawing.Point(330, 42);
            this.labelDWDatabase.Name = "labelDWDatabase";
            this.labelDWDatabase.Size = new System.Drawing.Size(137, 13);
            this.labelDWDatabase.TabIndex = 3;
            this.labelDWDatabase.Text = "Data Warehouse Database";
            // 
            // textBoxDWDB
            // 
            this.textBoxDWDB.Location = new System.Drawing.Point(330, 65);
            this.textBoxDWDB.Name = "textBoxDWDB";
            this.textBoxDWDB.Size = new System.Drawing.Size(244, 20);
            this.textBoxDWDB.TabIndex = 2;
            this.textBoxDWDB.Text = "Ops16DW";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(636, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(176, 36);
            this.button1.TabIndex = 4;
            this.button1.Text = "Set Credentials";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxClassPicker
            // 
            this.comboBoxClassPicker.FormattingEnabled = true;
            this.comboBoxClassPicker.Location = new System.Drawing.Point(54, 138);
            this.comboBoxClassPicker.Name = "comboBoxClassPicker";
            this.comboBoxClassPicker.Size = new System.Drawing.Size(520, 21);
            this.comboBoxClassPicker.TabIndex = 5;
            // 
            // labelScomObjectClass
            // 
            this.labelScomObjectClass.AutoSize = true;
            this.labelScomObjectClass.Location = new System.Drawing.Point(51, 122);
            this.labelScomObjectClass.Name = "labelScomObjectClass";
            this.labelScomObjectClass.Size = new System.Drawing.Size(100, 13);
            this.labelScomObjectClass.TabIndex = 6;
            this.labelScomObjectClass.Text = "SCOM Object Class";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "SCOM Performance Rules";
            // 
            // comboBoxPerfRules
            // 
            this.comboBoxPerfRules.FormattingEnabled = true;
            this.comboBoxPerfRules.Location = new System.Drawing.Point(54, 198);
            this.comboBoxPerfRules.Name = "comboBoxPerfRules";
            this.comboBoxPerfRules.Size = new System.Drawing.Size(520, 21);
            this.comboBoxPerfRules.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 236);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Entity / Instance";
            // 
            // comboBoxEntity
            // 
            this.comboBoxEntity.FormattingEnabled = true;
            this.comboBoxEntity.Location = new System.Drawing.Point(54, 252);
            this.comboBoxEntity.Name = "comboBoxEntity";
            this.comboBoxEntity.Size = new System.Drawing.Size(520, 21);
            this.comboBoxEntity.TabIndex = 9;
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.AllowUserToAddRows = false;
            this.dataGridViewHistory.AllowUserToDeleteRows = false;
            this.dataGridViewHistory.AutoGenerateColumns = false;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valueDataGridViewTextBoxColumn,
            this.timestampDataGridViewTextBoxColumn,
            this.relativeAgeSecondsDataGridViewTextBoxColumn});
            this.dataGridViewHistory.DataSource = this.performanceEntryBindingSource;
            this.dataGridViewHistory.Location = new System.Drawing.Point(33, 308);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.ReadOnly = true;
            this.dataGridViewHistory.RowHeadersWidth = 62;
            this.dataGridViewHistory.Size = new System.Drawing.Size(402, 235);
            this.dataGridViewHistory.TabIndex = 11;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            this.valueDataGridViewTextBoxColumn.Width = 150;
            // 
            // timestampDataGridViewTextBoxColumn
            // 
            this.timestampDataGridViewTextBoxColumn.DataPropertyName = "Timestamp";
            this.timestampDataGridViewTextBoxColumn.HeaderText = "Timestamp";
            this.timestampDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.timestampDataGridViewTextBoxColumn.Name = "timestampDataGridViewTextBoxColumn";
            this.timestampDataGridViewTextBoxColumn.ReadOnly = true;
            this.timestampDataGridViewTextBoxColumn.Width = 175;
            // 
            // relativeAgeSecondsDataGridViewTextBoxColumn
            // 
            this.relativeAgeSecondsDataGridViewTextBoxColumn.DataPropertyName = "RelativeAgeSeconds";
            this.relativeAgeSecondsDataGridViewTextBoxColumn.HeaderText = "RelativeAgeSeconds";
            this.relativeAgeSecondsDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.relativeAgeSecondsDataGridViewTextBoxColumn.Name = "relativeAgeSecondsDataGridViewTextBoxColumn";
            this.relativeAgeSecondsDataGridViewTextBoxColumn.ReadOnly = true;
            this.relativeAgeSecondsDataGridViewTextBoxColumn.Visible = false;
            this.relativeAgeSecondsDataGridViewTextBoxColumn.Width = 150;
            // 
            // performanceEntryBindingSource
            // 
            this.performanceEntryBindingSource.DataSource = typeof(ScomForecastingEngine.Models.PerformanceEntry);
            // 
            // dataGridViewForecast
            // 
            this.dataGridViewForecast.AllowUserToAddRows = false;
            this.dataGridViewForecast.AllowUserToDeleteRows = false;
            this.dataGridViewForecast.AutoGenerateColumns = false;
            this.dataGridViewForecast.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForecast.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.forecastDateDataGridViewTextBoxColumn,
            this.predictedValueDataGridViewTextBoxColumn,
            this.lowerBoundDataGridViewTextBoxColumn,
            this.upperBoundDataGridViewTextBoxColumn});
            this.dataGridViewForecast.DataSource = this.forecastRecordBindingSource;
            this.dataGridViewForecast.Location = new System.Drawing.Point(441, 308);
            this.dataGridViewForecast.Name = "dataGridViewForecast";
            this.dataGridViewForecast.ReadOnly = true;
            this.dataGridViewForecast.RowHeadersWidth = 62;
            this.dataGridViewForecast.Size = new System.Drawing.Size(707, 235);
            this.dataGridViewForecast.TabIndex = 12;
            // 
            // forecastDateDataGridViewTextBoxColumn
            // 
            this.forecastDateDataGridViewTextBoxColumn.DataPropertyName = "ForecastDate";
            this.forecastDateDataGridViewTextBoxColumn.HeaderText = "ForecastDate";
            this.forecastDateDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.forecastDateDataGridViewTextBoxColumn.Name = "forecastDateDataGridViewTextBoxColumn";
            this.forecastDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.forecastDateDataGridViewTextBoxColumn.Width = 175;
            // 
            // predictedValueDataGridViewTextBoxColumn
            // 
            this.predictedValueDataGridViewTextBoxColumn.DataPropertyName = "PredictedValue";
            this.predictedValueDataGridViewTextBoxColumn.HeaderText = "PredictedValue";
            this.predictedValueDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.predictedValueDataGridViewTextBoxColumn.Name = "predictedValueDataGridViewTextBoxColumn";
            this.predictedValueDataGridViewTextBoxColumn.ReadOnly = true;
            this.predictedValueDataGridViewTextBoxColumn.Width = 150;
            // 
            // lowerBoundDataGridViewTextBoxColumn
            // 
            this.lowerBoundDataGridViewTextBoxColumn.DataPropertyName = "LowerBound";
            this.lowerBoundDataGridViewTextBoxColumn.HeaderText = "LowerBound";
            this.lowerBoundDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.lowerBoundDataGridViewTextBoxColumn.Name = "lowerBoundDataGridViewTextBoxColumn";
            this.lowerBoundDataGridViewTextBoxColumn.ReadOnly = true;
            this.lowerBoundDataGridViewTextBoxColumn.Width = 150;
            // 
            // upperBoundDataGridViewTextBoxColumn
            // 
            this.upperBoundDataGridViewTextBoxColumn.DataPropertyName = "UpperBound";
            this.upperBoundDataGridViewTextBoxColumn.HeaderText = "UpperBound";
            this.upperBoundDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.upperBoundDataGridViewTextBoxColumn.Name = "upperBoundDataGridViewTextBoxColumn";
            this.upperBoundDataGridViewTextBoxColumn.ReadOnly = true;
            this.upperBoundDataGridViewTextBoxColumn.Width = 150;
            // 
            // forecastRecordBindingSource
            // 
            this.forecastRecordBindingSource.DataSource = typeof(ScomForecastingEngine.Models.ForecastRecord);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(636, 139);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Window Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(633, 171);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Series Length";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(651, 203);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Train Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(662, 235);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Horizon";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(615, 267);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Confidence Level";
            // 
            // numericWindowSize
            // 
            this.numericWindowSize.Location = new System.Drawing.Point(732, 137);
            this.numericWindowSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericWindowSize.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericWindowSize.Name = "numericWindowSize";
            this.numericWindowSize.Size = new System.Drawing.Size(80, 20);
            this.numericWindowSize.TabIndex = 23;
            this.numericWindowSize.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numericSeriesLength
            // 
            this.numericSeriesLength.Location = new System.Drawing.Point(732, 169);
            this.numericSeriesLength.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericSeriesLength.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericSeriesLength.Name = "numericSeriesLength";
            this.numericSeriesLength.Size = new System.Drawing.Size(80, 20);
            this.numericSeriesLength.TabIndex = 24;
            this.numericSeriesLength.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericTrainSize
            // 
            this.numericTrainSize.Location = new System.Drawing.Point(732, 201);
            this.numericTrainSize.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericTrainSize.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericTrainSize.Name = "numericTrainSize";
            this.numericTrainSize.Size = new System.Drawing.Size(80, 20);
            this.numericTrainSize.TabIndex = 25;
            this.numericTrainSize.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // numericHorizon
            // 
            this.numericHorizon.Location = new System.Drawing.Point(732, 233);
            this.numericHorizon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericHorizon.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericHorizon.Name = "numericHorizon";
            this.numericHorizon.Size = new System.Drawing.Size(80, 20);
            this.numericHorizon.TabIndex = 26;
            this.numericHorizon.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericConfidence
            // 
            this.numericConfidence.DecimalPlaces = 3;
            this.numericConfidence.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericConfidence.Location = new System.Drawing.Point(732, 265);
            this.numericConfidence.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numericConfidence.Name = "numericConfidence";
            this.numericConfidence.Size = new System.Drawing.Size(80, 20);
            this.numericConfidence.TabIndex = 27;
            this.numericConfidence.Value = new decimal(new int[] {
            950,
            0,
            0,
            196608});
            // 
            // DWPerformancePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxSqlServer);
            this.Controls.Add(this.numericConfidence);
            this.Controls.Add(this.numericHorizon);
            this.Controls.Add(this.numericTrainSize);
            this.Controls.Add(this.numericSeriesLength);
            this.Controls.Add(this.numericWindowSize);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewForecast);
            this.Controls.Add(this.dataGridViewHistory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxEntity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPerfRules);
            this.Controls.Add(this.labelScomObjectClass);
            this.Controls.Add(this.comboBoxClassPicker);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelDWDatabase);
            this.Controls.Add(this.textBoxDWDB);
            this.Controls.Add(this.labelSqlServer);
            this.Name = "DWPerformancePicker";
            this.Size = new System.Drawing.Size(1151, 608);
            this.Load += new System.EventHandler(this.DWPerformancePicker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performanceEntryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForecast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forecastRecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWindowSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSeriesLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTrainSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericHorizon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericConfidence)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSqlServer;
        private System.Windows.Forms.Label labelSqlServer;
        private System.Windows.Forms.Label labelDWDatabase;
        private System.Windows.Forms.TextBox textBoxDWDB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBoxClassPicker;
        private System.Windows.Forms.Label labelScomObjectClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPerfRules;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxEntity;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.BindingSource performanceEntryBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewForecast;
        private System.Windows.Forms.BindingSource forecastRecordBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timestampDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativeAgeSecondsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn forecastDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn predictedValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowerBoundDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn upperBoundDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericWindowSize;
        private System.Windows.Forms.NumericUpDown numericSeriesLength;
        private System.Windows.Forms.NumericUpDown numericTrainSize;
        private System.Windows.Forms.NumericUpDown numericHorizon;
        private System.Windows.Forms.NumericUpDown numericConfidence;
    }
}
