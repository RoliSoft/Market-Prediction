namespace MarketPrediction
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelChart = new System.Windows.Forms.Panel();
            this.panelControl = new System.Windows.Forms.Panel();
            this.checkBoxDpo = new System.Windows.Forms.CheckBox();
            this.checkBoxPpo = new System.Windows.Forms.CheckBox();
            this.checkBoxIndex = new System.Windows.Forms.CheckBox();
            this.checkBoxMacd = new System.Windows.Forms.CheckBox();
            this.checkBoxRsi = new System.Windows.Forms.CheckBox();
            this.checkBoxEma = new System.Windows.Forms.CheckBox();
            this.comboBoxSeries = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageHistData = new System.Windows.Forms.TabPage();
            this.tabPageNeuron = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panelChart.SuspendLayout();
            this.panelControl.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageHistData.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.InterlacedColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.InterlacedColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea1.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.Silver;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.BorderColor = System.Drawing.Color.Silver;
            chartArea1.IsSameFontSizeForAllAxes = true;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Alignment = System.Drawing.StringAlignment.Center;
            legend1.BackColor = System.Drawing.SystemColors.Control;
            legend1.BorderColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart.Size = new System.Drawing.Size(665, 360);
            this.chart.TabIndex = 0;
            // 
            // panelChart
            // 
            this.panelChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChart.Controls.Add(this.chart);
            this.panelChart.Location = new System.Drawing.Point(2, 3);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(665, 360);
            this.panelChart.TabIndex = 1;
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.checkBoxDpo);
            this.panelControl.Controls.Add(this.checkBoxPpo);
            this.panelControl.Controls.Add(this.checkBoxIndex);
            this.panelControl.Controls.Add(this.checkBoxMacd);
            this.panelControl.Controls.Add(this.checkBoxRsi);
            this.panelControl.Controls.Add(this.checkBoxEma);
            this.panelControl.Controls.Add(this.comboBoxSeries);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl.Location = new System.Drawing.Point(3, 366);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(664, 48);
            this.panelControl.TabIndex = 3;
            // 
            // checkBoxDpo
            // 
            this.checkBoxDpo.AutoSize = true;
            this.checkBoxDpo.Location = new System.Drawing.Point(437, 18);
            this.checkBoxDpo.Name = "checkBoxDpo";
            this.checkBoxDpo.Size = new System.Drawing.Size(49, 17);
            this.checkBoxDpo.TabIndex = 9;
            this.checkBoxDpo.Tag = "MarketPrediction.DetrendedPriceOscillation";
            this.checkBoxDpo.Text = "DPO";
            this.toolTip.SetToolTip(this.checkBoxDpo, "Detrended Price Oscillation");
            this.checkBoxDpo.UseVisualStyleBackColor = true;
            this.checkBoxDpo.CheckedChanged += new System.EventHandler(this.checkBoxIndicator_CheckedChanged);
            // 
            // checkBoxPpo
            // 
            this.checkBoxPpo.AutoSize = true;
            this.checkBoxPpo.Location = new System.Drawing.Point(383, 18);
            this.checkBoxPpo.Name = "checkBoxPpo";
            this.checkBoxPpo.Size = new System.Drawing.Size(48, 17);
            this.checkBoxPpo.TabIndex = 8;
            this.checkBoxPpo.Tag = "MarketPrediction.PercentagePriceOscillator";
            this.checkBoxPpo.Text = "PPO";
            this.toolTip.SetToolTip(this.checkBoxPpo, "Price Percentage Oscillation");
            this.checkBoxPpo.UseVisualStyleBackColor = true;
            this.checkBoxPpo.CheckedChanged += new System.EventHandler(this.checkBoxIndicator_CheckedChanged);
            // 
            // checkBoxIndex
            // 
            this.checkBoxIndex.AutoSize = true;
            this.checkBoxIndex.Location = new System.Drawing.Point(157, 18);
            this.checkBoxIndex.Name = "checkBoxIndex";
            this.checkBoxIndex.Size = new System.Drawing.Size(52, 17);
            this.checkBoxIndex.TabIndex = 7;
            this.checkBoxIndex.Text = "Index";
            this.toolTip.SetToolTip(this.checkBoxIndex, "Currency Index");
            this.checkBoxIndex.UseVisualStyleBackColor = true;
            this.checkBoxIndex.CheckedChanged += new System.EventHandler(this.checkBoxIndex_CheckedChanged);
            // 
            // checkBoxMacd
            // 
            this.checkBoxMacd.AutoSize = true;
            this.checkBoxMacd.Location = new System.Drawing.Point(320, 18);
            this.checkBoxMacd.Name = "checkBoxMacd";
            this.checkBoxMacd.Size = new System.Drawing.Size(57, 17);
            this.checkBoxMacd.TabIndex = 6;
            this.checkBoxMacd.Tag = "MarketPrediction.MovingAverageConvergenceDivergence";
            this.checkBoxMacd.Text = "MACD";
            this.toolTip.SetToolTip(this.checkBoxMacd, "Moving Average Convergence Divergence");
            this.checkBoxMacd.UseVisualStyleBackColor = true;
            this.checkBoxMacd.CheckedChanged += new System.EventHandler(this.checkBoxIndicator_CheckedChanged);
            // 
            // checkBoxRsi
            // 
            this.checkBoxRsi.AutoSize = true;
            this.checkBoxRsi.Location = new System.Drawing.Point(270, 18);
            this.checkBoxRsi.Name = "checkBoxRsi";
            this.checkBoxRsi.Size = new System.Drawing.Size(44, 17);
            this.checkBoxRsi.TabIndex = 5;
            this.checkBoxRsi.Tag = "MarketPrediction.RelativeStrengthIndex";
            this.checkBoxRsi.Text = "RSI";
            this.toolTip.SetToolTip(this.checkBoxRsi, "Relative Strength Index");
            this.checkBoxRsi.UseVisualStyleBackColor = true;
            this.checkBoxRsi.CheckedChanged += new System.EventHandler(this.checkBoxIndicator_CheckedChanged);
            // 
            // checkBoxEma
            // 
            this.checkBoxEma.AutoSize = true;
            this.checkBoxEma.Location = new System.Drawing.Point(215, 18);
            this.checkBoxEma.Name = "checkBoxEma";
            this.checkBoxEma.Size = new System.Drawing.Size(49, 17);
            this.checkBoxEma.TabIndex = 1;
            this.checkBoxEma.Tag = "MarketPrediction.ExponentialMovingAverage";
            this.checkBoxEma.Text = "EMA";
            this.toolTip.SetToolTip(this.checkBoxEma, "Exponential Moving Average");
            this.checkBoxEma.UseVisualStyleBackColor = true;
            this.checkBoxEma.CheckedChanged += new System.EventHandler(this.checkBoxIndicator_CheckedChanged);
            // 
            // comboBoxSeries
            // 
            this.comboBoxSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSeries.FormattingEnabled = true;
            this.comboBoxSeries.Location = new System.Drawing.Point(12, 15);
            this.comboBoxSeries.Name = "comboBoxSeries";
            this.comboBoxSeries.Size = new System.Drawing.Size(131, 21);
            this.comboBoxSeries.TabIndex = 4;
            this.comboBoxSeries.SelectedIndexChanged += new System.EventHandler(this.comboBoxSeries_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageHistData);
            this.tabControl.Controls.Add(this.tabPageNeuron);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(678, 443);
            this.tabControl.TabIndex = 4;
            // 
            // tabPageHistData
            // 
            this.tabPageHistData.Controls.Add(this.panelChart);
            this.tabPageHistData.Controls.Add(this.panelControl);
            this.tabPageHistData.Location = new System.Drawing.Point(4, 22);
            this.tabPageHistData.Name = "tabPageHistData";
            this.tabPageHistData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHistData.Size = new System.Drawing.Size(670, 417);
            this.tabPageHistData.TabIndex = 0;
            this.tabPageHistData.Text = "Historical Data & Indicators";
            this.tabPageHistData.UseVisualStyleBackColor = true;
            // 
            // tabPageNeuron
            // 
            this.tabPageNeuron.Location = new System.Drawing.Point(4, 22);
            this.tabPageNeuron.Name = "tabPageNeuron";
            this.tabPageNeuron.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNeuron.Size = new System.Drawing.Size(670, 417);
            this.tabPageNeuron.TabIndex = 1;
            this.tabPageNeuron.Text = "Neural Network";
            this.tabPageNeuron.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 467);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Market Prediction";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panelChart.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageHistData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.ComboBox comboBoxSeries;
        private System.Windows.Forms.CheckBox checkBoxMacd;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkBoxRsi;
        private System.Windows.Forms.CheckBox checkBoxEma;
        private System.Windows.Forms.CheckBox checkBoxIndex;
        private System.Windows.Forms.CheckBox checkBoxPpo;
        private System.Windows.Forms.CheckBox checkBoxDpo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageHistData;
        private System.Windows.Forms.TabPage tabPageNeuron;
    }
}

