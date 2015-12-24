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
            this.contextMenuStripChart = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.groupBoxNeuronSolution = new System.Windows.Forms.GroupBox();
            this.textBoxNeuronPredError = new System.Windows.Forms.TextBox();
            this.textBoxNeuronLearnError = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBoxNeuronParams = new System.Windows.Forms.GroupBox();
            this.numericUpDownNeuronMomentum = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.numericUpDownNeuronLearnRate = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDownNeuronHidden = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDownNeuronInputs = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxNeuronDataSet = new System.Windows.Forms.ComboBox();
            this.numericUpDownNeuronSampleCount = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDownNeuronIterations = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.progressBarNeuronLearn = new System.Windows.Forms.ProgressBar();
            this.buttonLearnNeuron = new MarketPrediction.MenuButton();
            this.contextMenuStripNeuron = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItemNeuron = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageGenetic = new System.Windows.Forms.TabPage();
            this.groupBoxGeneticSolution = new System.Windows.Forms.GroupBox();
            this.textBoxGeneticPredError = new System.Windows.Forms.TextBox();
            this.textBoxGeneticLearnError = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxGeneticSolution = new System.Windows.Forms.TextBox();
            this.groupBoxGeneticParams = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBoxGeneticDataSet = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxGeneticSelection = new System.Windows.Forms.ComboBox();
            this.comboBoxGeneticChromosome = new System.Windows.Forms.ComboBox();
            this.comboBoxGeneticFuncs = new System.Windows.Forms.ComboBox();
            this.checkBoxGeneticShuffle = new System.Windows.Forms.CheckBox();
            this.numericUpDownGeneticSampleCount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownGeneticPopulation = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownGeneticIterations = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBarGeneticLearn = new System.Windows.Forms.ProgressBar();
            this.buttonLearnGenetic = new MarketPrediction.MenuButton();
            this.contextMenuStripGenetic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItemGenetic = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panelChart.SuspendLayout();
            this.contextMenuStripChart.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.groupBoxPlot.SuspendLayout();
            this.groupBoxProcessing.SuspendLayout();
            this.groupBoxIndicators.SuspendLayout();
            this.groupBoxCurrency.SuspendLayout();
            this.tabPageNeuron.SuspendLayout();
            this.groupBoxNeuronSolution.SuspendLayout();
            this.groupBoxNeuronParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronMomentum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronLearnRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronHidden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronInputs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronSampleCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronIterations)).BeginInit();
            this.contextMenuStripNeuron.SuspendLayout();
            this.tabPageGenetic.SuspendLayout();
            this.groupBoxGeneticSolution.SuspendLayout();
            this.groupBoxGeneticParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGeneticSampleCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGeneticPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGeneticIterations)).BeginInit();
            this.contextMenuStripGenetic.SuspendLayout();
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
            this.chart.Size = new System.Drawing.Size(806, 491);
            this.chart.TabIndex = 0;
            // 
            // panelChart
            // 
            this.panelChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelChart.ContextMenuStrip = this.contextMenuStripChart;
            this.panelChart.Controls.Add(this.chart);
            this.panelChart.Location = new System.Drawing.Point(-30, 0);
            this.panelChart.Name = "panelChart";
            this.panelChart.Size = new System.Drawing.Size(806, 491);
            this.panelChart.TabIndex = 1;
            // 
            // contextMenuStripChart
            // 
            this.contextMenuStripChart.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.contextMenuStripChart.Name = "contextMenuStripChart";
            this.contextMenuStripChart.Size = new System.Drawing.Size(108, 48);
            this.contextMenuStripChart.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripChart_Opening);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exportToolStripMenuItem.Text = "Export";
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
            this.tabPageNeuron.Controls.Add(this.groupBoxNeuronSolution);
            this.tabPageNeuron.Controls.Add(this.groupBoxNeuronParams);
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
            // groupBoxNeuronSolution
            // 
            this.groupBoxNeuronSolution.Controls.Add(this.textBoxNeuronPredError);
            this.groupBoxNeuronSolution.Controls.Add(this.textBoxNeuronLearnError);
            this.groupBoxNeuronSolution.Controls.Add(this.label10);
            this.groupBoxNeuronSolution.Controls.Add(this.label11);
            this.groupBoxNeuronSolution.Location = new System.Drawing.Point(10, 224);
            this.groupBoxNeuronSolution.Name = "groupBoxNeuronSolution";
            this.groupBoxNeuronSolution.Size = new System.Drawing.Size(292, 75);
            this.groupBoxNeuronSolution.TabIndex = 14;
            this.groupBoxNeuronSolution.TabStop = false;
            this.groupBoxNeuronSolution.Text = "Solution";
            // 
            // textBoxNeuronPredError
            // 
            this.textBoxNeuronPredError.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNeuronPredError.Location = new System.Drawing.Point(98, 44);
            this.textBoxNeuronPredError.Name = "textBoxNeuronPredError";
            this.textBoxNeuronPredError.ReadOnly = true;
            this.textBoxNeuronPredError.Size = new System.Drawing.Size(184, 20);
            this.textBoxNeuronPredError.TabIndex = 5;
            // 
            // textBoxNeuronLearnError
            // 
            this.textBoxNeuronLearnError.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNeuronLearnError.Location = new System.Drawing.Point(98, 18);
            this.textBoxNeuronLearnError.Name = "textBoxNeuronLearnError";
            this.textBoxNeuronLearnError.ReadOnly = true;
            this.textBoxNeuronLearnError.Size = new System.Drawing.Size(184, 20);
            this.textBoxNeuronLearnError.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Prediction Error:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Learning Error:";
            // 
            // groupBoxNeuronParams
            // 
            this.groupBoxNeuronParams.Controls.Add(this.numericUpDownNeuronMomentum);
            this.groupBoxNeuronParams.Controls.Add(this.label19);
            this.groupBoxNeuronParams.Controls.Add(this.numericUpDownNeuronLearnRate);
            this.groupBoxNeuronParams.Controls.Add(this.label17);
            this.groupBoxNeuronParams.Controls.Add(this.numericUpDownNeuronHidden);
            this.groupBoxNeuronParams.Controls.Add(this.label15);
            this.groupBoxNeuronParams.Controls.Add(this.numericUpDownNeuronInputs);
            this.groupBoxNeuronParams.Controls.Add(this.label14);
            this.groupBoxNeuronParams.Controls.Add(this.label12);
            this.groupBoxNeuronParams.Controls.Add(this.comboBoxNeuronDataSet);
            this.groupBoxNeuronParams.Controls.Add(this.numericUpDownNeuronSampleCount);
            this.groupBoxNeuronParams.Controls.Add(this.label16);
            this.groupBoxNeuronParams.Controls.Add(this.numericUpDownNeuronIterations);
            this.groupBoxNeuronParams.Controls.Add(this.label18);
            this.groupBoxNeuronParams.Location = new System.Drawing.Point(10, 10);
            this.groupBoxNeuronParams.Name = "groupBoxNeuronParams";
            this.groupBoxNeuronParams.Size = new System.Drawing.Size(292, 208);
            this.groupBoxNeuronParams.TabIndex = 13;
            this.groupBoxNeuronParams.TabStop = false;
            this.groupBoxNeuronParams.Text = "Parameters";
            // 
            // numericUpDownNeuronMomentum
            // 
            this.numericUpDownNeuronMomentum.DecimalPlaces = 3;
            this.numericUpDownNeuronMomentum.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownNeuronMomentum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownNeuronMomentum.Location = new System.Drawing.Point(98, 176);
            this.numericUpDownNeuronMomentum.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNeuronMomentum.Name = "numericUpDownNeuronMomentum";
            this.numericUpDownNeuronMomentum.Size = new System.Drawing.Size(184, 20);
            this.numericUpDownNeuronMomentum.TabIndex = 22;
            this.numericUpDownNeuronMomentum.Value = new decimal(new int[] {
            988,
            0,
            0,
            196608});
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 177);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "Momentum:";
            // 
            // numericUpDownNeuronLearnRate
            // 
            this.numericUpDownNeuronLearnRate.DecimalPlaces = 3;
            this.numericUpDownNeuronLearnRate.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownNeuronLearnRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownNeuronLearnRate.Location = new System.Drawing.Point(98, 150);
            this.numericUpDownNeuronLearnRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNeuronLearnRate.Name = "numericUpDownNeuronLearnRate";
            this.numericUpDownNeuronLearnRate.Size = new System.Drawing.Size(184, 20);
            this.numericUpDownNeuronLearnRate.TabIndex = 20;
            this.numericUpDownNeuronLearnRate.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(10, 151);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 19;
            this.label17.Text = "Learning Rate:";
            // 
            // numericUpDownNeuronHidden
            // 
            this.numericUpDownNeuronHidden.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownNeuronHidden.Location = new System.Drawing.Point(98, 124);
            this.numericUpDownNeuronHidden.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
            this.numericUpDownNeuronHidden.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNeuronHidden.Name = "numericUpDownNeuronHidden";
            this.numericUpDownNeuronHidden.Size = new System.Drawing.Size(184, 20);
            this.numericUpDownNeuronHidden.TabIndex = 18;
            this.numericUpDownNeuronHidden.ThousandsSeparator = true;
            this.numericUpDownNeuronHidden.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(10, 125);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Hidden Layers:";
            // 
            // numericUpDownNeuronInputs
            // 
            this.numericUpDownNeuronInputs.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownNeuronInputs.Location = new System.Drawing.Point(98, 98);
            this.numericUpDownNeuronInputs.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
            this.numericUpDownNeuronInputs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNeuronInputs.Name = "numericUpDownNeuronInputs";
            this.numericUpDownNeuronInputs.Size = new System.Drawing.Size(184, 20);
            this.numericUpDownNeuronInputs.TabIndex = 16;
            this.numericUpDownNeuronInputs.ThousandsSeparator = true;
            this.numericUpDownNeuronInputs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(82, 13);
            this.label14.TabIndex = 15;
            this.label14.Text = "Network Inputs:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "Data Set:";
            // 
            // comboBoxNeuronDataSet
            // 
            this.comboBoxNeuronDataSet.DisplayMember = "Item1";
            this.comboBoxNeuronDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNeuronDataSet.FormattingEnabled = true;
            this.comboBoxNeuronDataSet.Location = new System.Drawing.Point(98, 19);
            this.comboBoxNeuronDataSet.Name = "comboBoxNeuronDataSet";
            this.comboBoxNeuronDataSet.Size = new System.Drawing.Size(184, 21);
            this.comboBoxNeuronDataSet.TabIndex = 13;
            // 
            // numericUpDownNeuronSampleCount
            // 
            this.numericUpDownNeuronSampleCount.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownNeuronSampleCount.Location = new System.Drawing.Point(98, 46);
            this.numericUpDownNeuronSampleCount.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
            this.numericUpDownNeuronSampleCount.Name = "numericUpDownNeuronSampleCount";
            this.numericUpDownNeuronSampleCount.Size = new System.Drawing.Size(184, 20);
            this.numericUpDownNeuronSampleCount.TabIndex = 8;
            this.numericUpDownNeuronSampleCount.ThousandsSeparator = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "Sample Size:";
            // 
            // numericUpDownNeuronIterations
            // 
            this.numericUpDownNeuronIterations.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownNeuronIterations.Location = new System.Drawing.Point(98, 72);
            this.numericUpDownNeuronIterations.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
            this.numericUpDownNeuronIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownNeuronIterations.Name = "numericUpDownNeuronIterations";
            this.numericUpDownNeuronIterations.Size = new System.Drawing.Size(184, 20);
            this.numericUpDownNeuronIterations.TabIndex = 4;
            this.numericUpDownNeuronIterations.ThousandsSeparator = true;
            this.numericUpDownNeuronIterations.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 73);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 3;
            this.label18.Text = "Iterations:";
            // 
            // progressBarNeuronLearn
            // 
            this.progressBarNeuronLearn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarNeuronLearn.Location = new System.Drawing.Point(10, 408);
            this.progressBarNeuronLearn.Name = "progressBarNeuronLearn";
            this.progressBarNeuronLearn.Size = new System.Drawing.Size(214, 23);
            this.progressBarNeuronLearn.Step = 1;
            this.progressBarNeuronLearn.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarNeuronLearn.TabIndex = 1;
            // 
            // buttonLearnNeuron
            // 
            this.buttonLearnNeuron.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLearnNeuron.Location = new System.Drawing.Point(230, 408);
            this.buttonLearnNeuron.Menu = this.contextMenuStripNeuron;
            this.buttonLearnNeuron.Name = "buttonLearnNeuron";
            this.buttonLearnNeuron.Size = new System.Drawing.Size(75, 23);
            this.buttonLearnNeuron.TabIndex = 0;
            this.buttonLearnNeuron.Text = "Learn";
            this.buttonLearnNeuron.UseVisualStyleBackColor = true;
            this.buttonLearnNeuron.Click += new System.EventHandler(this.buttonLearnNeuron_Click);
            // 
            // contextMenuStripNeuron
            // 
            this.contextMenuStripNeuron.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItemNeuron});
            this.contextMenuStripNeuron.Name = "contextMenuStripNeuron";
            this.contextMenuStripNeuron.Size = new System.Drawing.Size(102, 26);
            // 
            // clearToolStripMenuItemNeuron
            // 
            this.clearToolStripMenuItemNeuron.Name = "clearToolStripMenuItemNeuron";
            this.clearToolStripMenuItemNeuron.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItemNeuron.Text = "Clear";
            this.clearToolStripMenuItemNeuron.Click += new System.EventHandler(this.clearToolStripMenuItemNeuron_Click);
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
            // groupBoxGeneticSolution
            // 
            this.groupBoxGeneticSolution.Controls.Add(this.textBoxGeneticPredError);
            this.groupBoxGeneticSolution.Controls.Add(this.textBoxGeneticLearnError);
            this.groupBoxGeneticSolution.Controls.Add(this.label3);
            this.groupBoxGeneticSolution.Controls.Add(this.label2);
            this.groupBoxGeneticSolution.Controls.Add(this.label1);
            this.groupBoxGeneticSolution.Controls.Add(this.textBoxGeneticSolution);
            this.groupBoxGeneticSolution.Location = new System.Drawing.Point(10, 254);
            this.groupBoxGeneticSolution.Name = "groupBoxGeneticSolution";
            this.groupBoxGeneticSolution.Size = new System.Drawing.Size(292, 148);
            this.groupBoxGeneticSolution.TabIndex = 12;
            this.groupBoxGeneticSolution.TabStop = false;
            this.groupBoxGeneticSolution.Text = "Solution";
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
            // textBoxGeneticLearnError
            // 
            this.textBoxGeneticLearnError.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGeneticLearnError.Location = new System.Drawing.Point(98, 18);
            this.textBoxGeneticLearnError.Name = "textBoxGeneticLearnError";
            this.textBoxGeneticLearnError.ReadOnly = true;
            this.textBoxGeneticLearnError.Size = new System.Drawing.Size(184, 20);
            this.textBoxGeneticLearnError.TabIndex = 4;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Learning Error:";
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
            // groupBoxGeneticParams
            // 
            this.groupBoxGeneticParams.Controls.Add(this.label13);
            this.groupBoxGeneticParams.Controls.Add(this.comboBoxGeneticDataSet);
            this.groupBoxGeneticParams.Controls.Add(this.label9);
            this.groupBoxGeneticParams.Controls.Add(this.label8);
            this.groupBoxGeneticParams.Controls.Add(this.label7);
            this.groupBoxGeneticParams.Controls.Add(this.comboBoxGeneticSelection);
            this.groupBoxGeneticParams.Controls.Add(this.comboBoxGeneticChromosome);
            this.groupBoxGeneticParams.Controls.Add(this.comboBoxGeneticFuncs);
            this.groupBoxGeneticParams.Controls.Add(this.checkBoxGeneticShuffle);
            this.groupBoxGeneticParams.Controls.Add(this.numericUpDownGeneticSampleCount);
            this.groupBoxGeneticParams.Controls.Add(this.label6);
            this.groupBoxGeneticParams.Controls.Add(this.label5);
            this.groupBoxGeneticParams.Controls.Add(this.numericUpDownGeneticPopulation);
            this.groupBoxGeneticParams.Controls.Add(this.numericUpDownGeneticIterations);
            this.groupBoxGeneticParams.Controls.Add(this.label4);
            this.groupBoxGeneticParams.Location = new System.Drawing.Point(10, 10);
            this.groupBoxGeneticParams.Name = "groupBoxGeneticParams";
            this.groupBoxGeneticParams.Size = new System.Drawing.Size(292, 238);
            this.groupBoxGeneticParams.TabIndex = 11;
            this.groupBoxGeneticParams.TabStop = false;
            this.groupBoxGeneticParams.Text = "Parameters";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Data Set:";
            // 
            // comboBoxGeneticDataSet
            // 
            this.comboBoxGeneticDataSet.DisplayMember = "Item1";
            this.comboBoxGeneticDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGeneticDataSet.FormattingEnabled = true;
            this.comboBoxGeneticDataSet.Location = new System.Drawing.Point(98, 19);
            this.comboBoxGeneticDataSet.Name = "comboBoxGeneticDataSet";
            this.comboBoxGeneticDataSet.Size = new System.Drawing.Size(184, 21);
            this.comboBoxGeneticDataSet.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 181);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Selection:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Chromosome:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Gene Functions:";
            // 
            // comboBoxGeneticSelection
            // 
            this.comboBoxGeneticSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGeneticSelection.FormattingEnabled = true;
            this.comboBoxGeneticSelection.Items.AddRange(new object[] {
            "Elite",
            "Rank",
            "Roulette"});
            this.comboBoxGeneticSelection.Location = new System.Drawing.Point(98, 178);
            this.comboBoxGeneticSelection.Name = "comboBoxGeneticSelection";
            this.comboBoxGeneticSelection.Size = new System.Drawing.Size(184, 21);
            this.comboBoxGeneticSelection.TabIndex = 11;
            // 
            // comboBoxGeneticChromosome
            // 
            this.comboBoxGeneticChromosome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGeneticChromosome.FormattingEnabled = true;
            this.comboBoxGeneticChromosome.Items.AddRange(new object[] {
            "Gene Tree",
            "Gene Expression"});
            this.comboBoxGeneticChromosome.Location = new System.Drawing.Point(98, 151);
            this.comboBoxGeneticChromosome.Name = "comboBoxGeneticChromosome";
            this.comboBoxGeneticChromosome.Size = new System.Drawing.Size(184, 21);
            this.comboBoxGeneticChromosome.TabIndex = 10;
            // 
            // comboBoxGeneticFuncs
            // 
            this.comboBoxGeneticFuncs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGeneticFuncs.FormattingEnabled = true;
            this.comboBoxGeneticFuncs.Items.AddRange(new object[] {
            "Simple Arithmetics",
            "Arithmetics and Functions"});
            this.comboBoxGeneticFuncs.Location = new System.Drawing.Point(98, 124);
            this.comboBoxGeneticFuncs.Name = "comboBoxGeneticFuncs";
            this.comboBoxGeneticFuncs.Size = new System.Drawing.Size(184, 21);
            this.comboBoxGeneticFuncs.TabIndex = 5;
            // 
            // checkBoxGeneticShuffle
            // 
            this.checkBoxGeneticShuffle.AutoSize = true;
            this.checkBoxGeneticShuffle.Location = new System.Drawing.Point(13, 209);
            this.checkBoxGeneticShuffle.Name = "checkBoxGeneticShuffle";
            this.checkBoxGeneticShuffle.Size = new System.Drawing.Size(136, 17);
            this.checkBoxGeneticShuffle.TabIndex = 9;
            this.checkBoxGeneticShuffle.Text = "Shuffle on Each Epoch";
            this.checkBoxGeneticShuffle.UseVisualStyleBackColor = true;
            // 
            // numericUpDownGeneticSampleCount
            // 
            this.numericUpDownGeneticSampleCount.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownGeneticSampleCount.Location = new System.Drawing.Point(98, 46);
            this.numericUpDownGeneticSampleCount.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
            this.numericUpDownGeneticSampleCount.Name = "numericUpDownGeneticSampleCount";
            this.numericUpDownGeneticSampleCount.Size = new System.Drawing.Size(184, 20);
            this.numericUpDownGeneticSampleCount.TabIndex = 8;
            this.numericUpDownGeneticSampleCount.ThousandsSeparator = true;
            this.numericUpDownGeneticSampleCount.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Sample Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Population:";
            // 
            // numericUpDownGeneticPopulation
            // 
            this.numericUpDownGeneticPopulation.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownGeneticPopulation.Location = new System.Drawing.Point(98, 98);
            this.numericUpDownGeneticPopulation.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
            this.numericUpDownGeneticPopulation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGeneticPopulation.Name = "numericUpDownGeneticPopulation";
            this.numericUpDownGeneticPopulation.Size = new System.Drawing.Size(184, 20);
            this.numericUpDownGeneticPopulation.TabIndex = 5;
            this.numericUpDownGeneticPopulation.ThousandsSeparator = true;
            this.numericUpDownGeneticPopulation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownGeneticIterations
            // 
            this.numericUpDownGeneticIterations.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownGeneticIterations.Location = new System.Drawing.Point(98, 72);
            this.numericUpDownGeneticIterations.Maximum = new decimal(new int[] {
            0,
            1,
            0,
            0});
            this.numericUpDownGeneticIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownGeneticIterations.Name = "numericUpDownGeneticIterations";
            this.numericUpDownGeneticIterations.Size = new System.Drawing.Size(184, 20);
            this.numericUpDownGeneticIterations.TabIndex = 4;
            this.numericUpDownGeneticIterations.ThousandsSeparator = true;
            this.numericUpDownGeneticIterations.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Iterations:";
            // 
            // progressBarGeneticLearn
            // 
            this.progressBarGeneticLearn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarGeneticLearn.Location = new System.Drawing.Point(10, 408);
            this.progressBarGeneticLearn.Name = "progressBarGeneticLearn";
            this.progressBarGeneticLearn.Size = new System.Drawing.Size(214, 23);
            this.progressBarGeneticLearn.Step = 1;
            this.progressBarGeneticLearn.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarGeneticLearn.TabIndex = 3;
            // 
            // buttonLearnGenetic
            // 
            this.buttonLearnGenetic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLearnGenetic.Location = new System.Drawing.Point(230, 408);
            this.buttonLearnGenetic.Menu = this.contextMenuStripGenetic;
            this.buttonLearnGenetic.Name = "buttonLearnGenetic";
            this.buttonLearnGenetic.Size = new System.Drawing.Size(75, 23);
            this.buttonLearnGenetic.TabIndex = 2;
            this.buttonLearnGenetic.Text = "Learn";
            this.buttonLearnGenetic.UseVisualStyleBackColor = true;
            this.buttonLearnGenetic.Click += new System.EventHandler(this.buttonLearnGenetic_Click);
            // 
            // contextMenuStripGenetic
            // 
            this.contextMenuStripGenetic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItemGenetic});
            this.contextMenuStripGenetic.Name = "contextMenuStripGenetic";
            this.contextMenuStripGenetic.Size = new System.Drawing.Size(102, 26);
            // 
            // clearToolStripMenuItemGenetic
            // 
            this.clearToolStripMenuItemGenetic.Name = "clearToolStripMenuItemGenetic";
            this.clearToolStripMenuItemGenetic.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItemGenetic.Text = "Clear";
            this.clearToolStripMenuItemGenetic.Click += new System.EventHandler(this.clearToolStripMenuItemGenetic_Click);
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
            this.contextMenuStripChart.ResumeLayout(false);
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
            this.groupBoxNeuronSolution.ResumeLayout(false);
            this.groupBoxNeuronSolution.PerformLayout();
            this.groupBoxNeuronParams.ResumeLayout(false);
            this.groupBoxNeuronParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronMomentum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronLearnRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronHidden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronInputs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronSampleCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownNeuronIterations)).EndInit();
            this.contextMenuStripNeuron.ResumeLayout(false);
            this.tabPageGenetic.ResumeLayout(false);
            this.groupBoxGeneticSolution.ResumeLayout(false);
            this.groupBoxGeneticSolution.PerformLayout();
            this.groupBoxGeneticParams.ResumeLayout(false);
            this.groupBoxGeneticParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGeneticSampleCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGeneticPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGeneticIterations)).EndInit();
            this.contextMenuStripGenetic.ResumeLayout(false);
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
        private MenuButton buttonLearnNeuron;
        private System.Windows.Forms.ProgressBar progressBarNeuronLearn;
        private System.Windows.Forms.TabPage tabPageGenetic;
        private System.Windows.Forms.ProgressBar progressBarGeneticLearn;
        private MenuButton buttonLearnGenetic;
        private System.Windows.Forms.GroupBox groupBoxGeneticSolution;
        private System.Windows.Forms.TextBox textBoxGeneticSolution;
        private System.Windows.Forms.GroupBox groupBoxGeneticParams;
        private System.Windows.Forms.TextBox textBoxGeneticPredError;
        private System.Windows.Forms.TextBox textBoxGeneticLearnError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownGeneticPopulation;
        private System.Windows.Forms.NumericUpDown numericUpDownGeneticIterations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownGeneticSampleCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxGeneticShuffle;
        private System.Windows.Forms.ComboBox comboBoxGeneticSelection;
        private System.Windows.Forms.ComboBox comboBoxGeneticChromosome;
        private System.Windows.Forms.ComboBox comboBoxGeneticFuncs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBoxNeuronSolution;
        private System.Windows.Forms.TextBox textBoxNeuronPredError;
        private System.Windows.Forms.TextBox textBoxNeuronLearnError;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBoxNeuronParams;
        private System.Windows.Forms.NumericUpDown numericUpDownNeuronSampleCount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDownNeuronIterations;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNeuron;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItemNeuron;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGenetic;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItemGenetic;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxNeuronDataSet;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboBoxGeneticDataSet;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripChart;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numericUpDownNeuronInputs;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDownNeuronHidden;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDownNeuronLearnRate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDownNeuronMomentum;
        private System.Windows.Forms.Label label19;
    }
}

