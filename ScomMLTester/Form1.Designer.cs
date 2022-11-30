
namespace ScomMLTester
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dwPerformancePicker1 = new ScomForecastingUI.DWPerformancePicker();
            this.SuspendLayout();
            // 
            // dwPerformancePicker1
            // 
            this.dwPerformancePicker1.ConnectionString = null;
            this.dwPerformancePicker1.Location = new System.Drawing.Point(12, 12);
            this.dwPerformancePicker1.ManagedEntityTypes = null;
            this.dwPerformancePicker1.Name = "dwPerformancePicker1";
            this.dwPerformancePicker1.PerformanceRuleInstanceRows = null;
            this.dwPerformancePicker1.PerformanceRuleRows = null;
            this.dwPerformancePicker1.Size = new System.Drawing.Size(1171, 604);
            this.dwPerformancePicker1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 618);
            this.Controls.Add(this.dwPerformancePicker1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private ScomForecastingUI.DWPerformancePicker dwPerformancePicker1;
    }
}

