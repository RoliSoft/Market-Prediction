namespace MarketPrediction
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using System.Windows.Forms.DataVisualization.Charting;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using AForge;
    using AForge.Neuro;
    using AForge.Neuro.Learning;
    using AForge.Genetic;

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

        /// <summary>
        /// Indicates whether a genetic algorithm is currently learning.
        /// </summary>
        private bool geneticRunning = false;

        /// <summary>
        /// Signals a currently running genetic algorithm to stop.
        /// </summary>
        private bool geneticStop = false;

        /// <summary>
        /// Indicates whether a neural network is currently learning.
        /// </summary>
        private bool neuronRunning = false;

        /// <summary>
        /// Signals a currently running neural network to stop.
        /// </summary>
        private bool neuronStop = false;

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
                        { "SMA",  "MarketPrediction.SimpleMovingAverage" },
                        { "EMA",  "MarketPrediction.ExponentialMovingAverage" },
                        { "RSI",  "MarketPrediction.RelativeStrengthIndex" },
                        { "MACD", "MarketPrediction.MovingAverageConvergenceDivergence" },
                        { "PPO",  "MarketPrediction.PercentagePriceOscillator" },
                        { "DPO",  "MarketPrediction.DetrendedPriceOscillation" },
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
                    LoadSeries((string)comboBoxSeries.SelectedItem, index);
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
                    LoadSeriesTransform((string)comboBoxSeries.SelectedItem, index, transform);
                    comboBoxSeries_SelectedIndexChanged(null, null);
                }
            }
        }

        /// <summary>
        /// Loads the series into the main chart.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="indices">The indices.</param>
        private void LoadSeries(string name, SortedDictionary<DateTime, decimal> indices)
        {
            var series = new Series(name);
            series.ChartType = SeriesChartType.FastLine;

            foreach (var index in indices)
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
        /// <param name="indices">The indices.</param>
        /// <param name="transform">The transformer.</param>
        private void LoadSeriesTransform(string name, SortedDictionary<DateTime, decimal> indices, ISeriesTransform transform)
        {
            var series = new Series(name + " (" + transform.GetShortName() + ")");
            series.ChartType = SeriesChartType.FastLine;
            
            foreach (var index in indices)
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

        #endregion

        #region Neural Network

        /// <summary>
        /// Occurs when the Learn button is clicked on the Neural Network tab page.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private async void buttonLearnNeuron_Click(object sender, EventArgs e)
        {
            if (neuronRunning)
            {
                buttonLearnNeuron.Enabled = false;
                buttonLearnNeuron.Text = "Stopping";
                neuronStop = true;
                return;
            }

            neuronStop = false;
            neuronRunning = true;

            groupBoxNeuronParams.Enabled = groupBoxNeuronSolution.Enabled = false;
            buttonLearnNeuron.Text = "Stop";

            double[] data;
            DateTime? dataStartDate = null;
            {
                var dataSetVal = (Tuple<string, KeyValuePair<string, SortedDictionary<DateTime, decimal>>, string>)comboBoxNeuronDataSet.SelectedItem;
                var sampleSize = numericUpDownNeuronSampleCount.Value != 0 ? (int)numericUpDownNeuronSampleCount.Value : dataSetVal.Item2.Value.Values.Count;

                if (dataSetVal.Item3 != null)
                {
                    var dataTmp = new List<double>();
                    var transformer = (ISeriesTransform)Activator.CreateInstance(Type.GetType(dataSetVal.Item3));

                    foreach (var val in dataSetVal.Item2.Value)
                    {
                        transformer.AddIndex(val.Value);

                        if (transformer.IsReady())
                        {
                            dataTmp.Add((double)transformer.GetValue());

                            if (!dataStartDate.HasValue)
                            {
                                dataStartDate = val.Key;
                            }

                            if (dataTmp.Count >= sampleSize)
                            {
                                break;
                            }
                        }
                    }

                    data = dataTmp.ToArray();
                }
                else
                {
                    data = dataSetVal.Item2.Value.Values.Take(sampleSize).Select(x => (double)x).ToArray();
                    dataStartDate = dataSetVal.Item2.Value.Keys.First();
                }
            }

            var learningRate = 0.05;
            var momentum = 0.99;
            var sigmoidAlphaValue = 2.0;
            var window = 1;
            var prediction = 1;
            var iterations = (int)numericUpDownNeuronIterations.Value;

            progressBarNeuronLearn.Value = 0;
            progressBarNeuronLearn.Maximum = iterations;

            var samples = data.Length - prediction - window;
            var min = data.Min();
            var input = new double[samples][];
            var output = new double[samples][];

            for (int i = 0; i < samples; i++)
            {
                input[i]  = new double[window];
                output[i] = new double[1];
                
                for (int j = 0; j < window; j++)
                {
                    input[i][j] = data[i + j] - min;
                }
                
                output[i][0] = data[i + window] - min;
            }

            Neuron.RandRange = new Range(0.3f, 0.3f);

            var nn = new ActivationNetwork(new BipolarSigmoidFunction(sigmoidAlphaValue),
                window,     // number of inputs
                window * 2, // number of neurons on the first layer
                1);         // number of neurons on the second layer

            var bp = new BackPropagationLearning(nn)
                {
                    LearningRate = learningRate,
                    Momentum     = momentum
                };
            
            var solution = new double[data.Length - window];
            var testin   = new double[window];
            
            await Task.Run(() =>
                {
                    for (int i = 0; i < iterations; i++)
                    {
                        bp.RunEpoch(input, output);

                        Invoke(new Action<int>(p => progressBarNeuronLearn.Value = p), i);

                        if (neuronStop)
                        {
                            return;
                        }
                    }
                });

            if (neuronStop)
            {
                neuronStop = neuronRunning = false;

                buttonLearnNeuron.Text = "Learn";
                groupBoxNeuronParams.Enabled = groupBoxNeuronSolution.Enabled = buttonLearnNeuron.Enabled = true;

                return;
            }

            var errorLearn = 0.0;
            var errorPred  = 0.0;

            for (int i = 0, n = data.Length - window; i < n; i++)
            {
                for (int j = 0; j < window; j++)
                {
                    testin[j] = data[i + j] - min;
                }
                
                solution[i] = nn.Compute(testin)[0] + min;
                
                if (i >= n - prediction)
                {
                    errorPred  += Math.Abs(solution[i] - data[window + i]);
                }
                else
                {
                    errorLearn += Math.Abs(solution[i] - data[window + i]);
                }
            }

            neuronStop = neuronRunning = false;

            buttonLearnNeuron.Text = "Learn";
            groupBoxNeuronParams.Enabled = groupBoxNeuronSolution.Enabled = buttonLearnNeuron.Enabled = true;

            textBoxNeuronLearnError.Text = errorLearn.ToString();
            textBoxNeuronPredError.Text  = errorPred.ToString();

            AddToChart("NN", dataStartDate.Value, solution);
        }

        /// <summary>
        /// Occurs when the Clear menu item is clicked on the Learn button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void clearToolStripMenuItemNeuron_Click(object sender, EventArgs e)
        {
            if (neuronRunning)
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
            if (geneticRunning)
            {
                buttonLearnGenetic.Enabled = false;
                buttonLearnGenetic.Text = "Stopping";
                geneticStop = true;
                return;
            }

            geneticStop = false;
            geneticRunning = true;

            groupBoxGeneticParams.Enabled = groupBoxGeneticSolution.Enabled = false;
            buttonLearnGenetic.Text = "Stop";

            double[] data;
            DateTime? dataStartDate = null;
            {
                var dataSetVal = (Tuple<string, KeyValuePair<string, SortedDictionary<DateTime, decimal>>, string>)comboBoxGeneticDataSet.SelectedItem;
                var sampleSize = numericUpDownGeneticSampleCount.Value != 0 ? (int)numericUpDownGeneticSampleCount.Value : dataSetVal.Item2.Value.Values.Count;

                if (dataSetVal.Item3 != null)
                {
                    var dataTmp = new List<double>();
                    var transformer = (ISeriesTransform)Activator.CreateInstance(Type.GetType(dataSetVal.Item3));

                    foreach (var val in dataSetVal.Item2.Value)
                    {
                        transformer.AddIndex(val.Value);

                        if (transformer.IsReady())
                        {
                            dataTmp.Add((double)transformer.GetValue());

                            if (!dataStartDate.HasValue)
                            {
                                dataStartDate = val.Key;
                            }

                            if (dataTmp.Count >= sampleSize)
                            {
                                break;
                            }
                        }
                    }

                    data = dataTmp.ToArray();
                }
                else
                {
                    data = dataSetVal.Item2.Value.Values.Take(sampleSize).Select(x => (double)x).ToArray();
                    dataStartDate = dataSetVal.Item2.Value.Keys.First();
                }
            }

            int iterations = (int)numericUpDownGeneticIterations.Value;
            int population = (int)numericUpDownGeneticPopulation.Value;
            int window = 5;
            int prediction = 0;
            
            progressBarGeneticLearn.Value = 0;
            progressBarGeneticLearn.Maximum = iterations;
            
            var consts = new[] { data.Min(), data.Average(), data.Max() };

            IGPGene gene;

            switch (comboBoxGeneticFuncs.SelectedIndex)
            {
                default:
                case 0:
                    gene = new SimpleGeneFunction(window + consts.Length);
                    break;

                case 1:
                    gene = new ExtendedGeneFunction(window + consts.Length);
                    break;
            }

            IChromosome chromosome;
            
            switch (comboBoxGeneticChromosome.SelectedIndex)
            {
                default:
                case 0:
                    chromosome = new GPTreeChromosome(gene);
                    break;

                case 1:
                    chromosome = new GEPChromosome(gene, 20);
                    break;
            }

            ISelectionMethod selection;

            switch (comboBoxGeneticSelection.SelectedIndex)
            {
                default:
                case 0:
                    selection = new EliteSelection();
                    break;

                case 1:
                    selection = new RankSelection();
                    break;

                case 2:
                    selection = new RouletteWheelSelection();
                    break;
            }

            var ga = new Population(
                population,
                chromosome,
                new TimeSeriesPredictionFitness(data, window, 0, consts),
                selection
            );

            ga.AutoShuffling = checkBoxGeneticShuffle.Checked;
            
            var solution = new double[data.Length - window];
            var input = new double[window + consts.Length];

            for (int j = 0; j < data.Length - window; j++)
            {
                solution[j] = j + window;
            }
            
            Array.Copy(consts, 0, input, window, consts.Length);

            await Task.Run(() =>
                {
                    for (int i = 0; i < iterations; i++)
                    {
                        ga.RunEpoch();

                        Invoke(new Action<int>(p => progressBarGeneticLearn.Value = p), i);

                        if (geneticStop)
                        {
                            return;
                        }
                    }
                });

            if (geneticStop)
            {
                geneticStop = geneticRunning = false;

                buttonLearnGenetic.Text = "Learn";
                groupBoxGeneticParams.Enabled = groupBoxGeneticSolution.Enabled = buttonLearnGenetic.Enabled = true;

                return;
            }

            var errorLearn = 0.0;
            var errorPred  = 0.0;

            for (int j = 0, n = data.Length - window; j < n; j++)
            {
                for (int k = 0, b = j + window - 1; k < window; k++)
                {
                    input[k] = data[b - k];
                }

                solution[j] = PolishExpression.Evaluate(ga.BestChromosome.ToString(), input);

                if (j >= n - prediction)
                {
                    errorPred  += Math.Abs(solution[j] - data[window + j]);
                }
                else
                {
                    errorLearn += Math.Abs(solution[j] - data[window + j]);
                }
            }

            geneticStop = geneticRunning = false;

            buttonLearnGenetic.Text = "Learn";
            groupBoxGeneticParams.Enabled = groupBoxGeneticSolution.Enabled = buttonLearnGenetic.Enabled = true;

            textBoxGeneticLearnError.Text = errorLearn.ToString();
            textBoxGeneticPredError.Text  = errorPred.ToString();
            textBoxGeneticSolution.Text   = Utils.ResolveChromosome(ga.BestChromosome.ToString());

            AddToChart("GA", dataStartDate.Value.AddDays(window - 1), solution);
        }

        /// <summary>
        /// Occurs when the Clear menu item is clicked on the Learn button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void clearToolStripMenuItemGenetic_Click(object sender, EventArgs e)
        {
            if (geneticRunning)
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
