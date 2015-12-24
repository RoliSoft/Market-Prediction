namespace MarketPrediction
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;

    using MarketPrediction.Algorithms;
    using MarketPrediction.DataLoaders;
    using MarketPrediction.Indicators;

    /// <summary>
    /// Main form of the application.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Contains the list of loaded indices.
        /// </summary>
        private Dictionary<string, SortedDictionary<DateTime, decimal>> indices;

        /// <summary>
        /// Indicates whether to process events.
        /// </summary>
        private bool processEvents = true;

        private CancellationTokenSource cts;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #region Data

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                indices = OandaReader.ReadIndices("oanda_2014-2015.csv");
                indices["XBT/USD"] = CoinDeskReader.ReadIndex("coindesk-bpi-USD-close.csv");

                comboBoxSeries.Items.AddRange(indices.Keys.ToArray<object>());
                comboBoxSeries.SelectedIndex = 0;
                
                var transforms = new Dictionary<string, string>
                    {
                        { "SMA",  "MarketPrediction.Indicators.SimpleMovingAverage" },
                        { "EMA",  "MarketPrediction.Indicators.ExponentialMovingAverage" },
                        { "RSI",  "MarketPrediction.Indicators.RelativeStrengthIndex" },
                        { "MACD", "MarketPrediction.Indicators.MovingAverageConvergenceDivergence" },
                        { "PPO",  "MarketPrediction.Indicators.PercentagePriceOscillator" },
                        { "DPO",  "MarketPrediction.Indicators.DetrendedPriceOscillation" },
                    };

                foreach (var index in indices)
                {
                    comboBoxNeuronDataSet.Items.Add(Tuple.Create(index.Key, index, (string)null));
                    comboBoxGeneticDataSet.Items.Add(Tuple.Create(index.Key, index, (string)null));

                    foreach (var transform in transforms)
                    {
                        comboBoxNeuronDataSet.Items.Add(Tuple.Create(index.Key + " (" + transform.Key + ")", index, transform.Value));
                        comboBoxGeneticDataSet.Items.Add(Tuple.Create(index.Key + " (" + transform.Key + ")", index, transform.Value));
                    }
                }

                comboBoxNeuronDataSet.SelectedIndex = 0;
                comboBoxGeneticDataSet.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load indices: " + ex.Message);
                Application.Exit();
                return;
            }

            comboBoxGeneticFuncs.SelectedIndex = 0;
            comboBoxGeneticChromosome.SelectedIndex = 0;
            comboBoxGeneticSelection.SelectedIndex = 0;
        }

        /// <summary>
        /// Occurs when the Clear menu item is clicked on the chart menu.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearToolStripMenuItemNeuron_Click(sender, e);
            clearToolStripMenuItemGenetic_Click(sender, e);
            ClearChart();
        }

        /// <summary>
        /// Occurs when the Export menu item is clicked on the chart menu.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!((sender as ToolStripButton)?.Tag is Series))
            {
                return;
            }

            var series = (Series)((ToolStripButton)sender).Tag;

            var sb = new StringBuilder();

            foreach (var point in series.Points)
            {
                sb.AppendLine(point.XValue + "\t" + point.YValues[0]);
            }

            Clipboard.SetText(sb.ToString());
        }

        /// <summary>
        /// Occurs when the context menu of the chart is opening.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs" /> instance containing the event data.</param>
        private void contextMenuStripChart_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            exportToolStripMenuItem.DropDownItems.Clear();

            if (chart.Series.Count == 0)
            {
                exportToolStripMenuItem.Enabled = false;
                return;
            }

            exportToolStripMenuItem.Enabled = true;

            foreach (var series in chart.Series)
            {
                var tsi = new ToolStripButton
                    {
                        Text = series.Name,
                        Tag  = series
                    };

                tsi.Click += exportToolStripMenuItem_Click;

                exportToolStripMenuItem.DropDownItems.Add(tsi);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the comboBoxSeries control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void comboBoxSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!processEvents)
            {
                return;
            }

            processEvents = false;

            checkBoxIndex.Checked = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem);
            checkBoxSma.Checked   = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (SMA)");
            checkBoxEma.Checked   = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (EMA)");
            checkBoxRsi.Checked   = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (RSI)");
            checkBoxMacd.Checked  = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (MACD)");
            checkBoxPpo.Checked   = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (PPO)");
            checkBoxDpo.Checked   = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (DPO)");

            processEvents = true;
        }
        
        /// <summary>
        /// Occurs when the checkbox's checked value changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void checkBoxIndex_CheckedChanged(object sender, EventArgs e)
        {
            if (!processEvents || comboBoxSeries.SelectedItem == null)
            {
                return;
            }

            if (chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem))
            {
                // unload data

                foreach (var series in chart.Series.Where(x => x.Name == (string)comboBoxSeries.SelectedItem || x.Name.StartsWith((string)comboBoxSeries.SelectedItem + " (")).ToList())
                {
                    chart.Series.Remove(series);
                }

                comboBoxSeries_SelectedIndexChanged(null, e);
                SetChartBoundaries();
            }
            else
            {
                // load data

                SortedDictionary<DateTime, decimal> index;
                if (indices.TryGetValue((string)comboBoxSeries.SelectedItem, out index))
                {
                    LoadSeries((string)comboBoxSeries.SelectedItem, index, (int)numericUpDownDataSampleCount.Value, (int)numericUpDownDataSampleOffset.Value);
                    comboBoxSeries_SelectedIndexChanged(null, e);
                }
            }
        }
        
        /// <summary>
        /// Occurs when an indicator checkbox is toggled.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void checkBoxIndicator_CheckedChanged(object sender, EventArgs e)
        {
            if (!processEvents || comboBoxSeries.SelectedItem == null || !(((CheckBox)sender).Tag is string))
            {
                return;
            }

            var transform = (ISeriesTransform)Activator.CreateInstance(Type.GetType((string)((CheckBox)sender).Tag));

            if (chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (" + transform.GetShortName() + ")"))
            {
                // unload data

                chart.Series.Remove(chart.Series.FirstOrDefault((x => x.Name == (string)comboBoxSeries.SelectedItem + " (" + transform.GetShortName() + ")")));
                comboBoxSeries_SelectedIndexChanged(null, null);
                SetChartBoundaries();
            }
            else
            {
                // load data

                SortedDictionary<DateTime, decimal> index;
                if (indices.TryGetValue((string)comboBoxSeries.SelectedItem, out index))
                {
                    LoadSeriesTransform((string)comboBoxSeries.SelectedItem, index, transform, (int)numericUpDownDataSampleCount.Value, (int)numericUpDownDataSampleOffset.Value);
                    comboBoxSeries_SelectedIndexChanged(null, null);
                }
            }
        }

        /// <summary>
        /// Loads the series into the main chart.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="data">The indices.</param>
        /// <param name="size">The size of the sample to load.</param>
        /// <param name="offset">The offset to start from.</param>
        private void LoadSeries(string name, SortedDictionary<DateTime, decimal> data, int size, int offset)
        {
            var series = new Series(name)
                {
                    ChartType = SeriesChartType.FastLine
                };

            if (size == 0)
            {
                size = data.Values.Count;
            }

            foreach (var index in data.Skip(offset).Take(size))
            {
                series.Points.AddXY(index.Key, index.Value);
            }

            try
            {
                chart.Series.Add(series);
            }
            catch (ArgumentException)
            {
                chart.Series.Remove(chart.Series.FirstOrDefault(x => x.Name == name));
                chart.Series.Add(series);
            }

            SetChartBoundaries();
        }

        /// <summary>
        /// Loads a transformed series into the main chart.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="data">The indices.</param>
        /// <param name="transform">The transformer.</param>
        /// <param name="size">The size of the sample to load.</param>
        /// <param name="offset">The offset to start from.</param>
        private void LoadSeriesTransform(string name, SortedDictionary<DateTime, decimal> data, ISeriesTransform transform, int size, int offset)
        {
            var series = new Series(name + " (" + transform.GetShortName() + ")")
                {
                    ChartType = SeriesChartType.FastLine
                };

            if (size == 0)
            {
                size = data.Values.Count;
            }

            foreach (var index in data.Skip(offset).Take(size))
            {
                transform.AddIndex(index.Value);

                if (transform.IsReady())
                {
                    series.Points.AddXY(index.Key, transform.GetValue());
                }
            }

            try
            {
                chart.Series.Add(series);
            }
            catch (ArgumentException)
            {
                chart.Series.Remove(chart.Series.FirstOrDefault(x => x.Name == name + " (" + transform.GetShortName() + ")"));
                chart.Series.Add(series);
            }

            SetChartBoundaries();
        }

        /// <summary>
        /// Adds a series to the chart starting with the specified date.
        /// </summary>
        /// <param name="name">The name of the series.</param>
        /// <param name="start">The starting date.</param>
        /// <param name="data">The data.</param>
        private void AddToChart(string name, DateTime start, IEnumerable data)
        {
            var series = new Series(name)
                {
                    ChartType = SeriesChartType.FastLine
                };

            var date = start;
            foreach (var point in data)
            {
                series.Points.AddXY(date, point);
                date = date.AddDays(1);
            }

            try
            {
                chart.Series.Add(series);
            }
            catch (ArgumentException)
            {
                chart.Series.Remove(chart.Series.FirstOrDefault(x => x.Name == name));
                chart.Series.Add(series);
            }

            SetChartBoundaries();
        }

        /// <summary>
        /// Clears the chart.
        /// </summary>
        private void ClearChart()
        {
            chart.Series.Clear();
            comboBoxSeries_SelectedIndexChanged(null, null);
        }

        /// <summary>
        /// Sets the min/max boundaries for the chart.
        /// </summary>
        private void SetChartBoundaries()
        {
            double min = double.MaxValue,
                   max = double.MinValue;

            if (chart.Series.Count == 0)
            {
                return;
            }

            foreach (var series in chart.Series)
            {
                min = Math.Min(min, (series.Points.FindMinByValue("Y1")?.GetValueByName("Y1")).GetValueOrDefault(double.MaxValue));
                max = Math.Max(max, (series.Points.FindMaxByValue("Y1")?.GetValueByName("Y1")).GetValueOrDefault(double.MinValue));
            }

            if (Math.Abs(min - double.MaxValue) > 0.01)
            {
                chart.ChartAreas[0].AxisY.Minimum = min;
            }

            if (Math.Abs(max - double.MinValue) > 0.01)
            {
                chart.ChartAreas[0].AxisY.Maximum = max;
            }
        }

        /// <summary>
        /// Prepares the data from the specified UI settings.
        /// </summary>
        /// <param name="sampleSize"><c>Value</c> of one of the "Sample Size" numericUpDowns.</param>
        /// <param name="sampleOffset"><c>Value</c> of one of the "Sample Offset" (or "Ofs.") numericUpDowns.</param>
        /// <param name="dataSet"><c>SelectedItem</c> of one of the "Data Set" comboBoxes.</param>
        /// <returns>Tuple of the starting date of the data and the points themselves.</returns>
        private Tuple<DateTime, double[]> PrepareData(decimal sampleSize, decimal sampleOffset, object dataSet)
        {
            double[] data;
            DateTime? dataStartDate = null;

            var dataSetVal = (Tuple<string, KeyValuePair<string, SortedDictionary<DateTime, decimal>>, string>)dataSet;
            var sampleSizeVal = sampleSize != 0 ? (int)sampleSize : dataSetVal.Item2.Value.Values.Count;

            if (dataSetVal.Item3 != null)
            {
                var dataTmp = new List<double>();
                var transformer = (ISeriesTransform)Activator.CreateInstance(Type.GetType(dataSetVal.Item3));

                foreach (var val in dataSetVal.Item2.Value.Skip((int)sampleOffset))
                {
                    transformer.AddIndex(val.Value);

                    if (transformer.IsReady())
                    {
                        dataTmp.Add((double)transformer.GetValue());

                        if (!dataStartDate.HasValue)
                        {
                            dataStartDate = val.Key;
                        }

                        if (dataTmp.Count >= sampleSizeVal)
                        {
                            break;
                        }
                    }
                }

                data = dataTmp.ToArray();
            }
            else
            {
                data = dataSetVal.Item2.Value.Values.Skip((int)sampleOffset).Take(sampleSizeVal).Select(x => (double)x).ToArray();
                dataStartDate = dataSetVal.Item2.Value.Keys.First().AddDays((int)sampleOffset);
            }

            return Tuple.Create(dataStartDate.Value, data);
        }

        #endregion

        #region Neural Network

        /// <summary>
        /// Occurs when the Learn button is clicked on the Neural Network tab page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private async void buttonLearnNeuron_Click(object sender, EventArgs e)
        {
            if (NeuralNetwork.NeuronRunning)
            {
                buttonLearnNeuron.Enabled = false;
                buttonLearnNeuron.Text = "Stopping";
                NeuralNetwork.NeuronStop = true;
                return;
            }

            NeuralNetwork.NeuronStop = false;
            NeuralNetwork.NeuronRunning = true;

            groupBoxNeuronParams.Enabled = groupBoxNeuronSolution.Enabled = false;
            buttonLearnNeuron.Text = "Stop";

            var learningRate = (double)numericUpDownNeuronLearnRate.Value;
            var momentum     = (double)numericUpDownNeuronMomentum.Value;
            var inputCount   = (int)numericUpDownNeuronInputs.Value;
            var hiddenCount  = (int)numericUpDownNeuronHidden.Value;
            var iterations   = (int)numericUpDownNeuronIterations.Value;
            var sigmoidAlpha = 2.0;

            var data = PrepareData(numericUpDownNeuronSampleCount.Value, numericUpDownNeuronSampleOffset.Value, comboBoxNeuronDataSet.SelectedItem);

            var solution   = new double[data.Item2.Length - inputCount];
            var errorLearn = 0.0;
            var trainRes   = false;

            progressBarNeuronLearn.Value = 0;
            progressBarNeuronLearn.Maximum = iterations;

            await Task.Run(() =>
                {
                    trainRes = NeuralNetwork.TrainAndEval(data.Item2, ref solution, ref errorLearn, iterations, inputCount, hiddenCount, learningRate, momentum, sigmoidAlpha, p => Invoke(new Action<int>(pi => progressBarNeuronLearn.Value = pi), p));
                });
            
            NeuralNetwork.NeuronStop = NeuralNetwork.NeuronRunning = false;

            buttonLearnNeuron.Text = "Learn";
            groupBoxNeuronParams.Enabled = groupBoxNeuronSolution.Enabled = buttonLearnNeuron.Enabled = true;

            if (!trainRes)
            {
                return;
            }

            textBoxNeuronLearnError.Text = errorLearn.ToString();
            //textBoxNeuronPredError.Text  = errorPred.ToString();

            AddToChart("NN", data.Item1, solution);
        }

        /// <summary>
        /// Occurs when the Clear menu item is clicked on the Learn button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void clearToolStripMenuItemNeuron_Click(object sender, EventArgs e)
        {
            if (NeuralNetwork.NeuronRunning)
            {
                return;
            }

            try
            {
                textBoxNeuronLearnError.Clear();
                textBoxNeuronPredError.Clear();
                progressBarNeuronLearn.Value = 0;
                chart.Series.Remove(chart.Series.FirstOrDefault(x => x.Name == "NN"));
            }
            catch { }
        }

        #endregion

        #region Genetic Algorithm

        /// <summary>
        /// Occurs when the Learn button is clicked on the Genetic Algorithm tab page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private async void buttonLearnGenetic_Click(object sender, EventArgs e)
        {
            if (GeneticAlgorithm.GeneticRunning)
            {
                buttonLearnGenetic.Enabled = false;
                buttonLearnGenetic.Text = "Stopping";
                GeneticAlgorithm.GeneticStop = true;
                return;
            }

            GeneticAlgorithm.GeneticStop = false;
            GeneticAlgorithm.GeneticRunning = true;

            groupBoxGeneticParams.Enabled = groupBoxGeneticSolution.Enabled = false;
            buttonLearnGenetic.Text = "Stop";
            
            var iterations     = (int)numericUpDownGeneticIterations.Value;
            var population     = (int)numericUpDownGeneticPopulation.Value;
            var inputCount     = (int)numericUpDownGeneticInputs.Value;
            var shuffle        = checkBoxGeneticShuffle.Checked;
            var geneType       = (GeneticAlgorithm.GeneFunctions)comboBoxGeneticFuncs.SelectedIndex;
            var selectionType  = (GeneticAlgorithm.Selections)comboBoxGeneticSelection.SelectedIndex;
            var chromosomeType = (GeneticAlgorithm.Chromosomes)comboBoxGeneticChromosome.SelectedIndex;

            var data = PrepareData(numericUpDownGeneticSampleCount.Value, numericUpDownGeneticSampleOffset.Value, comboBoxGeneticDataSet.SelectedItem);

            var constants      = new[] { data.Item2.Min(), data.Item2.Average(), data.Item2.Max() };
            var solution       = new double[data.Item2.Length - inputCount];
            var bestChromosome = "";
            var errorLearn     = 0.0;
            var trainRes       = false;

            progressBarGeneticLearn.Value = 0;
            progressBarGeneticLearn.Maximum = iterations;

            await Task.Run(() =>
                {
                    trainRes = GeneticAlgorithm.TrainAndEval(data.Item2, ref solution, ref bestChromosome, ref errorLearn, iterations, population, inputCount, shuffle, constants, geneType, chromosomeType, selectionType, p => Invoke(new Action<int>(pi => progressBarGeneticLearn.Value = pi), p));
                });
            
            GeneticAlgorithm.GeneticStop = GeneticAlgorithm.GeneticRunning = false;

            buttonLearnGenetic.Text = "Learn";
            groupBoxGeneticParams.Enabled = groupBoxGeneticSolution.Enabled = buttonLearnGenetic.Enabled = true;

            if (!trainRes)
            {
                return;
            }

            textBoxGeneticLearnError.Text = errorLearn.ToString();
            //textBoxGeneticPredError.Text  = errorPred.ToString();
            textBoxGeneticSolution.Text   = Utils.ResolveChromosome(bestChromosome);

            AddToChart("GA", data.Item1.AddDays(inputCount - 1), solution);
        }

        /// <summary>
        /// Occurs when the Clear menu item is clicked on the Learn button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void clearToolStripMenuItemGenetic_Click(object sender, EventArgs e)
        {
            if (GeneticAlgorithm.GeneticRunning)
            {
                return;
            }

            try
            {
                textBoxGeneticLearnError.Clear();
                textBoxGeneticPredError.Clear();
                textBoxGeneticSolution.Clear();
                progressBarGeneticLearn.Value = 0;
                chart.Series.Remove(chart.Series.FirstOrDefault(x => x.Name == "GA"));
            }
            catch { }
        }

        #endregion
    }
}
