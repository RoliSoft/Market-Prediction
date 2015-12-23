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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelChart = new System.Windows.Forms.Panel();
            this.checkBoxDpo = new System.Windows.Forms.CheckBox();
            this.checkBoxPpo = new System.Windows.Forms.CheckBox();
            this.checkBoxIndex = new System.Windows.Forms.CheckBox();
            this.checkBoxMacd = new System.Windows.Forms.CheckBox();
            this.checkBoxRsi = new System.Windows.Forms.CheckBox();
            this.checkBoxSma = new System.Windows.Forms.CheckBox();
            this.comboBoxSeries = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkBoxEma = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.groupBoxPlot = new System.Windows.Forms.GroupBox();
            this.groupBoxProcessing = new System.Windows.Forms.GroupBox();
            this.groupBoxIndicators = new System.Windows.Forms.GroupBox();
            this.groupBoxCurrency = new System.Windows.Forms.GroupBox();
            this.tabPageNeuron = new System.Windows.Forms.TabPage();
            this.progressBarNeuronLearn = new System.Windows.Forms.ProgressBar();
            this.buttonLearnNeuron = new System.Windows.Forms.Button();
            this.tabPageGenetic = new System.Windows.Forms.TabPage();
            this.progressBarGeneticLearn = new System.Windows.Forms.ProgressBar();
            this.buttonLearnGenetic = new System.Windows.Forms.Button();
            this.groupBoxGeneticParams = new System.Windows.Forms.GroupBox();
            this.groupBoxGeneticSolution = new System.Windows.Forms.GroupBox();
            this.textBoxGeneticSolution = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxGeneticLearnError = new System.Windows.Forms.TextBox();
            this.textBoxGeneticPredError = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panelChart.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.groupBoxPlot.SuspendLayout();
            this.groupBoxProcessing.SuspendLayout();
            this.groupBoxIndicators.SuspendLayout();
            this.groupBoxCurrency.SuspendLayout();
            this.tabPageNeuron.SuspendLayout();
            this.tabPageGenetic.SuspendLayout();
            this.groupBoxGeneticSolution.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.AxisX.InterlacedColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.IsStartedFromZero = false;
            chartArea2.AxisX.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisX.ScaleBreakStyle.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.InterlacedColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.AxisY.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.MajorTickMark.LineColor = System.Drawing.Color.Silver;
            chartArea2.AxisY.ScaleBreakStyle.LineColor = System.Drawing.Color.Silver;
            chartArea2.BackColor = System.Drawing.SystemColors.Control;
            chartArea2.BorderColor = System.Drawing.Color.Silver;
            chartArea2.IsSameFontSizeForAllAxes = true;
            chartArea2.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea2);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.BackColor = System.Drawing.SystemColors.Control;
            legend2.BorderColor = System.Drawing.Color.Transparent;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
            legend2.Name = "Legend1";
            legend2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart.Legends.Add(legend2);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart.Size = new System.Drawing.Size(806, 491);
            this.chart.TabIndex = 0;
            // 
            // panelChart
            // 
            this.panelChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChart.Controls.Add(this.chart);
            this.panelChart.Location = new System.Drawing.Point(-30, 0);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(806, 491);
            this.panelChart.TabIndex = 1;
            // 
            // checkBoxDpo
            // 
            this.checkBoxDpo.AutoSize = true;
            this.checkBoxDpo.Location = new System.Drawing.Point(178, 21);
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
            this.checkBoxPpo.Location = new System.Drawing.Point(124, 21);
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
            this.checkBoxIndex.Location = new System.Drawing.Point(10, 21);
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
            this.checkBoxMacd.Location = new System.Drawing.Point(61, 21);
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
            this.checkBoxRsi.Location = new System.Drawing.Point(11, 21);
            this.checkBoxRsi.Name = "checkBoxRsi";
            this.checkBoxRsi.Size = new System.Drawing.Size(44, 17);
            this.checkBoxRsi.TabIndex = 5;
            this.checkBoxRsi.Tag = "MarketPrediction.RelativeStrengthIndex";
            this.checkBoxRsi.Text = "RSI";
            this.toolTip.SetToolTip(this.checkBoxRsi, "Relative Strength Index");
            this.checkBoxRsi.UseVisualStyleBackColor = true;
            this.checkBoxRsi.CheckedChanged += new System.EventHandler(this.checkBoxIndicator_CheckedChanged);
            // 
            // checkBoxSma
            // 
            this.checkBoxSma.AutoSize = true;
            this.checkBoxSma.Location = new System.Drawing.Point(11, 21);
            this.checkBoxSma.Name = "checkBoxSma";
            this.checkBoxSma.Size = new System.Drawing.Size(49, 17);
            this.checkBoxSma.TabIndex = 1;
            this.checkBoxSma.Tag = "MarketPrediction.SimpleMovingAverage";
            this.checkBoxSma.Text = "SMA";
            this.toolTip.SetToolTip(this.checkBoxSma, "Simple Moving Average");
            this.checkBoxSma.UseVisualStyleBackColor = true;
            this.checkBoxSma.CheckedChanged += new System.EventHandler(this.checkBoxIndicator_CheckedChanged);
            // 
            // comboBoxSeries
            // 
            this.comboBoxSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSeries.FormattingEnabled = true;
            this.comboBoxSeries.Location = new System.Drawing.Point(10, 19);
            this.comboBoxSeries.Name = "comboBoxSeries";
            this.comboBoxSeries.Size = new System.Drawing.Size(272, 21);
            this.comboBoxSeries.TabIndex = 4;
            this.comboBoxSeries.SelectedIndexChanged += new System.EventHandler(this.comboBoxSeries_SelectedIndexChanged);
            // 
            // checkBoxEma
            // 
            this.checkBoxEma.AutoSize = true;
            this.checkBoxEma.Location = new System.Drawing.Point(66, 21);
            this.checkBoxEma.Name = "checkBoxEma";
            this.checkBoxEma.Size = new System.Drawing.Size(49, 17);
            this.checkBoxEma.TabIndex = 2;
            this.checkBoxEma.Tag = "MarketPrediction.ExponentialMovingAverage";
            this.checkBoxEma.Text = "EMA";
            this.toolTip.SetToolTip(this.checkBoxEma, "Exponential Moving Average");
            this.checkBoxEma.UseVisualStyleBackColor = true;
            this.checkBoxEma.CheckedChanged += new System.EventHandler(this.checkBoxIndicator_CheckedChanged);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageData);
            this.tabControl.Controls.Add(this.tabPageNeuron);
            this.tabControl.Controls.Add(this.tabPageGenetic);
            this.tabControl.Location = new System.Drawing.Point(763, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(320, 467);
            this.tabControl.TabIndex = 4;
            // 
            // tabPageData
            // 
            this.tabPageData.AutoScroll = true;
            this.tabPageData.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.tabPageData.Controls.Add(this.groupBoxPlot);
            this.tabPageData.Controls.Add(this.groupBoxCurrency);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(312, 441);
            this.tabPageData.TabIndex = 0;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // groupBoxPlot
            // 
            this.groupBoxPlot.Controls.Add(this.groupBoxProcessing);
            this.groupBoxPlot.Controls.Add(this.groupBoxIndicators);
            this.groupBoxPlot.Controls.Add(this.checkBoxIndex);
            this.groupBoxPlot.Location = new System.Drawing.Point(10, 68);
            this.groupBoxPlot.Name = "groupBoxPlot";
            this.groupBoxPlot.Size = new System.Drawing.Size(292, 153);
            this.groupBoxPlot.TabIndex = 11;
            this.groupBoxPlot.TabStop = false;
            this.groupBoxPlot.Text = "Plot";
            // 
            // groupBoxProcessing
            // 
            this.groupBoxProcessing.Controls.Add(this.checkBoxEma);
            this.groupBoxProcessing.Controls.Add(this.checkBoxSma);
            this.groupBoxProcessing.Location = new System.Drawing.Point(10, 44);
            this.groupBoxProcessing.Name = "groupBoxProcessing";
            this.groupBoxProcessing.Size = new System.Drawing.Size(272, 46);
            this.groupBoxProcessing.TabIndex = 9;
            this.groupBoxProcessing.TabStop = false;
            this.groupBoxProcessing.Text = "Processing";
            // 
            // groupBoxIndicators
            // 
            this.groupBoxIndicators.Controls.Add(this.checkBoxRsi);
            this.groupBoxIndicators.Controls.Add(this.checkBoxPpo);
            this.groupBoxIndicators.Controls.Add(this.checkBoxMacd);
            this.groupBoxIndicators.Controls.Add(this.checkBoxDpo);
            this.groupBoxIndicators.Location = new System.Drawing.Point(10, 96);
            this.groupBoxIndicators.Name = "groupBoxIndicators";
            this.groupBoxIndicators.Size = new System.Drawing.Size(272, 46);
            this.groupBoxIndicators.TabIndex = 8;
            this.groupBoxIndicators.TabStop = false;
            this.groupBoxIndicators.Text = "Indicators";
            // 
            // groupBoxCurrency
            // 
            this.groupBoxCurrency.Controls.Add(this.comboBoxSeries);
            this.groupBoxCurrency.Location = new System.Drawing.Point(10, 10);
            this.groupBoxCurrency.Name = "groupBoxCurrency";
            this.groupBoxCurrency.Size = new System.Drawing.Size(292, 52);
            this.groupBoxCurrency.TabIndex = 10;
            this.groupBoxCurrency.TabStop = false;
            this.groupBoxCurrency.Text = "Currency";
            // 
            // tabPageNeuron
            // 
            this.tabPageNeuron.AutoScroll = true;
            this.tabPageNeuron.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.tabPageNeuron.Controls.Add(this.progressBarNeuronLearn);
            this.tabPageNeuron.Controls.Add(this.buttonLearnNeuron);
            this.tabPageNeuron.Location = new System.Drawing.Point(4, 22);
            this.tabPageNeuron.Name = "tabPageNeuron";
            this.tabPageNeuron.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNeuron.Size = new System.Drawing.Size(312, 441);
            this.tabPageNeuron.TabIndex = 1;
            this.tabPageNeuron.Text = "Neural Network";
            this.tabPageNeuron.UseVisualStyleBackColor = true;
            // 
            // progressBarNeuronLearn
            // 
            this.progressBarNeuronLearn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarNeuronLearn.Location = new System.Drawing.Point(10, 408);
            this.progressBarNeuronLearn.Name = "progressBarNeuronLearn";
            this.progressBarNeuronLearn.Size = new System.Drawing.Size(211, 23);
            this.progressBarNeuronLearn.Step = 1;
            this.progressBarNeuronLearn.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarNeuronLearn.TabIndex = 1;
            // 
            // buttonLearnNeuron
            // 
            this.buttonLearnNeuron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLearnNeuron.Location = new System.Drawing.Point(227, 408);
            this.buttonLearnNeuron.Name = "buttonLearnNeuron";
            this.buttonLearnNeuron.Size = new System.Drawing.Size(75, 23);
            this.buttonLearnNeuron.TabIndex = 0;
            this.buttonLearnNeuron.Text = "Learn";
            this.buttonLearnNeuron.UseVisualStyleBackColor = true;
            this.buttonLearnNeuron.Click += new System.EventHandler(this.buttonLearnNeuron_Click);
            // 
            // tabPageGenetic
            // 
            this.tabPageGenetic.AutoScroll = true;
            this.tabPageGenetic.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.tabPageGenetic.Controls.Add(this.groupBoxGeneticSolution);
            this.tabPageGenetic.Controls.Add(this.groupBoxGeneticParams);
            this.tabPageGenetic.Controls.Add(this.progressBarGeneticLearn);
            this.tabPageGenetic.Controls.Add(this.buttonLearnGenetic);
            this.tabPageGenetic.Location = new System.Drawing.Point(4, 22);
            this.tabPageGenetic.Name = "tabPageGenetic";
            this.tabPageGenetic.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGenetic.Size = new System.Drawing.Size(312, 441);
            this.tabPageGenetic.TabIndex = 2;
            this.tabPageGenetic.Text = "Genetic Algorithm";
            this.tabPageGenetic.UseVisualStyleBackColor = true;
            // 
            // progressBarGeneticLearn
            // 
            this.progressBarGeneticLearn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarGeneticLearn.Location = new System.Drawing.Point(10, 408);
            this.progressBarGeneticLearn.Name = "progressBarGeneticLearn";
            this.progressBarGeneticLearn.Size = new System.Drawing.Size(211, 23);
            this.progressBarGeneticLearn.Step = 1;
            this.progressBarGeneticLearn.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarGeneticLearn.TabIndex = 3;
            // 
            // buttonLearnGenetic
            // 
            this.buttonLearnGenetic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLearnGenetic.Location = new System.Drawing.Point(227, 408);
            this.buttonLearnGenetic.Name = "buttonLearnGenetic";
            this.buttonLearnGenetic.Size = new System.Drawing.Size(75, 23);
            this.buttonLearnGenetic.TabIndex = 2;
            this.buttonLearnGenetic.Text = "Learn";
            this.buttonLearnGenetic.UseVisualStyleBackColor = true;
            this.buttonLearnGenetic.Click += new System.EventHandler(this.buttonLearnGenetic_Click);
            // 
            // groupBoxGeneticParams
            // 
            this.groupBoxGeneticParams.Location = new System.Drawing.Point(10, 10);
            this.groupBoxGeneticParams.Name = "groupBoxGeneticParams";
            this.groupBoxGeneticParams.Size = new System.Drawing.Size(292, 52);
            this.groupBoxGeneticParams.TabIndex = 11;
            this.groupBoxGeneticParams.TabStop = false;
            this.groupBoxGeneticParams.Text = "Parameters";
            // 
            // groupBoxGeneticSolution
            // 
            this.groupBoxGeneticSolution.Controls.Add(this.textBoxGeneticPredError);
            this.groupBoxGeneticSolution.Controls.Add(this.textBoxGeneticLearnError);
            this.groupBoxGeneticSolution.Controls.Add(this.label3);
            this.groupBoxGeneticSolution.Controls.Add(this.label2);
            this.groupBoxGeneticSolution.Controls.Add(this.label1);
            this.groupBoxGeneticSolution.Controls.Add(this.textBoxGeneticSolution);
            this.groupBoxGeneticSolution.Location = new System.Drawing.Point(10, 68);
            this.groupBoxGeneticSolution.Name = "groupBoxGeneticSolution";
            this.groupBoxGeneticSolution.Size = new System.Drawing.Size(292, 148);
            this.groupBoxGeneticSolution.TabIndex = 12;
            this.groupBoxGeneticSolution.TabStop = false;
            this.groupBoxGeneticSolution.Text = "Solution";
            // 
            // textBoxGeneticSolution
            // 
            this.textBoxGeneticSolution.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGeneticSolution.Location = new System.Drawing.Point(10, 92);
            this.textBoxGeneticSolution.Multiline = true;
            this.textBoxGeneticSolution.Name = "textBoxGeneticSolution";
            this.textBoxGeneticSolution.ReadOnly = true;
            this.textBoxGeneticSolution.Size = new System.Drawing.Size(272, 45);
            this.textBoxGeneticSolution.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Equation of Fittest Chromosome:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Learning Error:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Prediction Error:";
            // 
            // textBoxGeneticLearnError
            // 
            this.textBoxGeneticLearnError.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGeneticLearnError.Location = new System.Drawing.Point(98, 18);
            this.textBoxGeneticLearnError.Name = "textBoxGeneticLearnError";
            this.textBoxGeneticLearnError.ReadOnly = true;
            this.textBoxGeneticLearnError.Size = new System.Drawing.Size(184, 20);
            this.textBoxGeneticLearnError.TabIndex = 4;
            // 
            // textBoxGeneticPredError
            // 
            this.textBoxGeneticPredError.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGeneticPredError.Location = new System.Drawing.Point(98, 44);
            this.textBoxGeneticPredError.Name = "textBoxGeneticPredError";
            this.textBoxGeneticPredError.ReadOnly = true;
            this.textBoxGeneticPredError.Size = new System.Drawing.Size(184, 20);
            this.textBoxGeneticPredError.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1095, 491);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panelChart);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Market Prediction";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panelChart.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.groupBoxPlot.ResumeLayout(false);
            this.groupBoxPlot.PerformLayout();
            this.groupBoxProcessing.ResumeLayout(false);
            this.groupBoxProcessing.PerformLayout();
            this.groupBoxIndicators.ResumeLayout(false);
            this.groupBoxIndicators.PerformLayout();
            this.groupBoxCurrency.ResumeLayout(false);
            this.tabPageNeuron.ResumeLayout(false);
            this.tabPageGenetic.ResumeLayout(false);
            this.groupBoxGeneticSolution.ResumeLayout(false);
            this.groupBoxGeneticSolution.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel panelChart;
        private System.Windows.Forms.ComboBox comboBoxSeries;
        private System.Windows.Forms.CheckBox checkBoxMacd;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox checkBoxRsi;
        private System.Windows.Forms.CheckBox checkBoxSma;
        private System.Windows.Forms.CheckBox checkBoxIndex;
        private System.Windows.Forms.CheckBox checkBoxPpo;
        private System.Windows.Forms.CheckBox checkBoxDpo;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.TabPage tabPageNeuron;
        private System.Windows.Forms.GroupBox groupBoxPlot;
        private System.Windows.Forms.GroupBox groupBoxProcessing;
        private System.Windows.Forms.GroupBox groupBoxIndicators;
        private System.Windows.Forms.GroupBox groupBoxCurrency;
        private System.Windows.Forms.CheckBox checkBoxEma;
        private System.Windows.Forms.Button buttonLearnNeuron;
        private System.Windows.Forms.ProgressBar progressBarNeuronLearn;
        private System.Windows.Forms.TabPage tabPageGenetic;
        private System.Windows.Forms.ProgressBar progressBarGeneticLearn;
        private System.Windows.Forms.Button buttonLearnGenetic;
        private System.Windows.Forms.GroupBox groupBoxGeneticSolution;
        private System.Windows.Forms.TextBox textBoxGeneticSolution;
        private System.Windows.Forms.GroupBox groupBoxGeneticParams;
        private System.Windows.Forms.TextBox textBoxGeneticPredError;
        private System.Windows.Forms.TextBox textBoxGeneticLearnError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

