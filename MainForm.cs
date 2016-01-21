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
        private bool _processEvents = true;

        /// <summary>
        /// The global cancellation token for the neuron network operations.
        /// </summary>
        private CancellationTokenSource _neuronCts;

        /// <summary>
        /// The global cancellation token for the global algorithm operations.
        /// </summary>
        private CancellationTokenSource _geneticCts;

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
            if (!_processEvents)
            {
                return;
            }

            _processEvents = false;

            checkBoxIndex.Checked = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem);
            checkBoxSma.Checked   = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (SMA)");
            checkBoxEma.Checked   = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (EMA)");
            checkBoxRsi.Checked   = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (RSI)");
            checkBoxMacd.Checked  = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (MACD)");
            checkBoxPpo.Checked   = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (PPO)");
            checkBoxDpo.Checked   = chart.Series.Any(x => x.Name == (string)comboBoxSeries.SelectedItem + " (DPO)");

            _processEvents = true;
        }
        
        /// <summary>
        /// Occurs when the checkbox's checked value changes.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void checkBoxIndex_CheckedChanged(object sender, EventArgs e)
        {
            if (!_processEvents || comboBoxSeries.SelectedItem == null)
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
            if (!_processEvents || comboBoxSeries.SelectedItem == null || !(((CheckBox)sender).Tag is string))
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
            
            foreach (var index in data.Skip(offset))
            {
                transform.AddIndex(index.Value);

                if (transform.IsReady())
                {
                    series.Points.AddXY(index.Key, transform.GetValue());
                    
                    if (series.Points.Count >= size)
                    {
                        break;
                    }
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
        /// <param name="inputCount"><c>Value</c> of one of the "Network Inputs" numericUpDowns.</param>
        /// <param name="dataSet"><c>SelectedItem</c> of one of the "Data Set" comboBoxes.</param>
        /// <returns>Tuple of the starting date of the data and the points themselves.</returns>
        private Tuple<DateTime, double[]> PrepareData(decimal sampleSize, decimal sampleOffset, decimal inputCount, object dataSet)
        {
            double[] data;
            DateTime? dataStartDate = null;

            var dataSetVal = (Tuple<string, KeyValuePair<string, SortedDictionary<DateTime, decimal>>, string>)dataSet;
            var sampleSizeVal = (sampleSize != 0 ? (int)sampleSize : dataSetVal.Item2.Value.Values.Count) + (int)inputCount;

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

        /// <summary>
        /// Calculates the error in percentages between the predicted data and actual data.
        /// </summary>
        /// <param name="dataSet"><c>SelectedItem</c> of one of the "Data Set" comboBoxes.</param>
        /// <param name="start">The starting date.</param>
        /// <param name="data">The data.</param>
        /// <returns>MAPE value.</returns>
        private double CalculateError(object dataSet, DateTime start, IEnumerable<double> data)
        {
            var predicted = data.ToArray();
            List<double> actual;

            var dataSetVal = (Tuple<string, KeyValuePair<string, SortedDictionary<DateTime, decimal>>, string>)dataSet;

            if (dataSetVal.Item3 != null)
            {
                var ts = start.AddDays(-60);
                actual = new List<double>();

                var transformer = (ISeriesTransform)Activator.CreateInstance(Type.GetType(dataSetVal.Item3));

                foreach (var val in dataSetVal.Item2.Value.SkipWhile(x => x.Key < ts))
                {
                    transformer.AddIndex(val.Value);

                    if (!transformer.IsReady() || val.Key < start)
                    {
                        continue;
                    }

                    actual.Add((double)transformer.GetValue());

                    if (actual.Count >= predicted.Length)
                    {
                        break;
                    }
                }
            }
            else
            {
                actual = dataSetVal.Item2.Value.SkipWhile(x => x.Key < start).Take(predicted.Length).Select(x => (double)x.Value).ToList();
            }

            var error = 0.0;

            for (int i = 1; i < Math.Min(actual.Count, predicted.Length); i++)
            {
                error += Math.Abs((predicted[i] - actual[i]) / actual[i]);
            }

            return error / Math.Min(actual.Count, predicted.Length) * 100;
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
            if (_neuronCts != null)
            {
                buttonLearnNeuron.Enabled = false;
                buttonLearnNeuron.Text = "Stopping";

                _neuronCts.Cancel();

                return;
            }

            _neuronCts = new CancellationTokenSource();
            
            groupBoxNeuronParams.Enabled = groupBoxNeuronSolution.Enabled = false;
            buttonLearnNeuron.Text = "Stop";

            var learningRate = (double)numericUpDownNeuronLearnRate.Value;
            var momentum     = (double)numericUpDownNeuronMomentum.Value;
            var inputCount   = (int)numericUpDownNeuronInputs.Value;
            var predCount    = (int)numericUpDownNeuronPredictions.Value;
            var hiddenCount  = (int)numericUpDownNeuronHidden.Value;
            var iterations   = (int)numericUpDownNeuronIterations.Value;

            var data = PrepareData(numericUpDownNeuronSampleCount.Value, numericUpDownNeuronSampleOffset.Value, numericUpDownNeuronInputs.Value, comboBoxNeuronDataSet.SelectedItem);

            var solution    = new double[data.Item2.Length - inputCount];
            var predictions = new double[predCount != 0 ? predCount + inputCount : 0];
            var errorLearn  = 0.0;
            var trainRes    = false;

            progressBarNeuronLearn.Value = 0;
            progressBarNeuronLearn.Maximum = iterations;
            
            await Task.Run(() =>
                {
                    try
                    {
                        trainRes = NeuralNetwork.TrainAndEval(data.Item2, ref solution, ref errorLearn, ref predictions, iterations, inputCount, hiddenCount, learningRate, momentum, _neuronCts.Token, p => Invoke(new Action<int>(pi => progressBarNeuronLearn.Value = pi), p));
                    }
                    catch
                    {
                        trainRes = false;
                    }
                });

            _neuronCts = null;

            buttonLearnNeuron.Text = "Learn";
            groupBoxNeuronParams.Enabled = groupBoxNeuronSolution.Enabled = buttonLearnNeuron.Enabled = true;

            if (!trainRes)
            {
                return;
            }

            textBoxNeuronLearnError.Text = errorLearn.ToString("0.0000") + "%";

            AddToChart("NN", data.Item1, solution);

            if (predCount != 0)
            {
                textBoxNeuronPredError.Text = CalculateError(comboBoxNeuronDataSet.SelectedItem, data.Item1.AddDays(solution.Length - 1), predictions.Skip(inputCount - 1)).ToString("0.0000") + "%";

                AddToChart("NN (Pred.)", data.Item1.AddDays(solution.Length - 1), predictions.Skip(inputCount - 1));
            }
        }

        /// <summary>
        /// Occurs when the Bruteforce menu item is clicked on the Learn button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private async void bruteforceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_neuronCts != null)
            {
                buttonLearnNeuron.Enabled = false;
                buttonLearnNeuron.Text = "Stopping";

                _neuronCts.Cancel();

                return;
            }

            _neuronCts = new CancellationTokenSource();
            
            groupBoxNeuronParams.Enabled = groupBoxNeuronSolution.Enabled = false;
            buttonLearnNeuron.Text = "Stop";
            
            var inputCount   = (int)numericUpDownNeuronInputs.Value;
            var predCount    = (int)numericUpDownNeuronPredictions.Value;
            var hiddenCount  = (int)numericUpDownNeuronHidden.Value;
            var iterations   = (int)numericUpDownNeuronIterations.Value;

            var data = PrepareData(numericUpDownNeuronSampleCount.Value, numericUpDownNeuronSampleOffset.Value, numericUpDownNeuronInputs.Value, comboBoxNeuronDataSet.SelectedItem);

            var solution    = new double[data.Item2.Length - inputCount];
            var predictions = new double[predCount != 0 ? predCount + inputCount : 0];
            var errorLearn  = 0.0;
            var trainRes    = false;
            var origDataSet = comboBoxNeuronDataSet.SelectedItem;

            var inputStart = 3;
            var inputMax   = 10;
            var hiddenMax  = 15;
            var momentums  = new[] { 0, /*0.01,*/ 0.05, /*0.1, 0.25,*/ 0.5, /*0.75, 0.8,*/ 0.988 };
            var learnRates = new[] { /*0.01,*/ 0.05, /*0.1, 0.25,*/ 0.5, /*0.75, 0.8,*/ 0.988 };

            progressBarNeuronLearn.Value = 0;
            progressBarNeuronLearn.Maximum = (inputMax - inputStart) * hiddenMax * momentums.Length * learnRates.Length;
            
            var smallestError   = double.MaxValue;
            var bestInputCount  = inputCount;
            var bestHiddenCount = hiddenCount;
            var bestMomentum    = 0;
            var bestLearnRate   = 0;

            await Task.Run(() =>
                {
                    for (int i = inputStart; i < inputMax; i++)
                    {
                        Invoke(new Action<int>(ic => numericUpDownNeuronInputs.Value = ic), i);

                        for (int j = 1; j < hiddenMax; j++)
                        {
                            Invoke(new Action<int>(hc => numericUpDownNeuronHidden.Value = hc), j);

                            for (int k = 0; k < momentums.Length; k++)
                            {
                                Invoke(new Action<int>(mc => numericUpDownNeuronMomentum.Value = (decimal)momentums[mc]), k);

                                for (int l = 0; l < learnRates.Length; l++)
                                {
                                    Invoke(new Action<int, int, int, int>((ic, hc, mc, lc) =>
                                    {
                                        numericUpDownNeuronLearnRate.Value = (decimal)learnRates[lc];
                                        progressBarNeuronLearn.Value = ((ic - inputStart) * hiddenMax) + hc + mc + lc;
                                    }),
                                    i, j, k, l);

                                    solution    = new double[data.Item2.Length - i];
                                    predictions = new double[predCount != 0 ? predCount + i : 0];

                                    try
                                    {
                                        trainRes = NeuralNetwork.TrainAndEval(data.Item2, ref solution, ref errorLearn, ref predictions, iterations, i, j, learnRates[l], momentums[k], _neuronCts.Token);
                                    }
                                    catch
                                    {
                                        trainRes = false;
                                        continue;
                                    }

                                    var err = CalculateError(origDataSet, data.Item1.AddDays(solution.Length - 1), predictions.Skip(i - 1)) + errorLearn;
                                    
                                    if (err < smallestError)
                                    {
                                        smallestError   = err;
                                        bestInputCount  = i;
                                        bestHiddenCount = j;
                                        bestMomentum    = k;
                                        bestLearnRate   = l;
                                    }

                                    if (_neuronCts.IsCancellationRequested)
                                    {
                                        trainRes = false;
                                        return;
                                    }
                                }
                            }
                        }
                    }

                    Invoke(new Action<int, int, int, int>((ic, hc, mc, lc) =>
                        {
                            numericUpDownNeuronInputs.Value = ic;
                            numericUpDownNeuronHidden.Value = hc;
                            numericUpDownNeuronMomentum.Value = (decimal)momentums[mc];
                            numericUpDownNeuronLearnRate.Value = (decimal)learnRates[lc];
                        }),
                        bestInputCount, bestHiddenCount, bestMomentum, bestLearnRate);

                    solution    = new double[data.Item2.Length - bestInputCount];
                    predictions = new double[predCount != 0 ? predCount + bestInputCount : 0];

                    try
                    {
                        trainRes = NeuralNetwork.TrainAndEval(data.Item2, ref solution, ref errorLearn, ref predictions, iterations, bestInputCount, bestHiddenCount, learnRates[bestLearnRate], momentums[bestMomentum], sigmoidAlpha, _neuronCts.Token);
                    }
                    catch
                    {
                        trainRes = false;
                    }
                });

            _neuronCts = null;

            buttonLearnNeuron.Text = "Learn";
            groupBoxNeuronParams.Enabled = groupBoxNeuronSolution.Enabled = buttonLearnNeuron.Enabled = true;

            if (!trainRes)
            {
                return;
            }

            textBoxNeuronLearnError.Text = errorLearn.ToString("0.0000") + "%";

            AddToChart("NN", data.Item1, solution);

            if (predCount != 0)
            {
                textBoxNeuronPredError.Text = CalculateError(comboBoxNeuronDataSet.SelectedItem, data.Item1.AddDays(solution.Length - 1), predictions.Skip(bestInputCount - 1)).ToString("0.0000") + "%";

                AddToChart("NN (Pred.)", data.Item1.AddDays(solution.Length - 1), predictions.Skip(bestInputCount - 1));
            }
        }

        /// <summary>
        /// Occurs when the Clear menu item is clicked on the Learn button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void clearToolStripMenuItemNeuron_Click(object sender, EventArgs e)
        {
            if (_neuronCts != null)
            {
                return;
            }

            try
            {
                textBoxNeuronLearnError.Clear();
                textBoxNeuronPredError.Clear();
                progressBarNeuronLearn.Value = 0;
                chart.Series.Remove(chart.Series.FirstOrDefault(x => x.Name == "NN"));
                chart.Series.Remove(chart.Series.FirstOrDefault(x => x.Name == "NN (Pred.)"));
                chart.ResetAutoValues();
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
            if (_geneticCts != null)
            {
                buttonLearnGenetic.Enabled = false;
                buttonLearnGenetic.Text = "Stopping";

                _geneticCts.Cancel();

                return;
            }

            _geneticCts = new CancellationTokenSource();

            groupBoxGeneticParams.Enabled = groupBoxGeneticSolution.Enabled = false;
            buttonLearnGenetic.Text = "Stop";
            
            var iterations     = (int)numericUpDownGeneticIterations.Value;
            var population     = (int)numericUpDownGeneticPopulation.Value;
            var inputCount     = (int)numericUpDownGeneticInputs.Value;
            var predCount      = (int)numericUpDownGeneticPredictions.Value;
            var shuffle        = checkBoxGeneticShuffle.Checked;
            var geneType       = (GeneticAlgorithm.GeneFunctions)comboBoxGeneticFuncs.SelectedIndex;
            var selectionType  = (GeneticAlgorithm.Selections)comboBoxGeneticSelection.SelectedIndex;
            var chromosomeType = (GeneticAlgorithm.Chromosomes)comboBoxGeneticChromosome.SelectedIndex;

            var data = PrepareData(numericUpDownGeneticSampleCount.Value, numericUpDownGeneticSampleOffset.Value, numericUpDownGeneticInputs.Value, comboBoxGeneticDataSet.SelectedItem);

            var constants      = new[] { data.Item2.Min(), data.Item2.Average(), data.Item2.Max() };
            var solution       = new double[data.Item2.Length - inputCount];
            var predictions    = new double[predCount != 0 ? predCount + inputCount : 0];
            var bestChromosome = "";
            var errorLearn     = 0.0;
            var trainRes       = false;

            progressBarGeneticLearn.Value = 0;
            progressBarGeneticLearn.Maximum = iterations;

            await Task.Run(() =>
                {
                    try
                    { 
                        trainRes = GeneticAlgorithm.TrainAndEval(data.Item2, ref solution, ref bestChromosome, ref errorLearn, ref predictions, iterations, population, inputCount, shuffle, constants, geneType, chromosomeType, selectionType, _geneticCts.Token, p => Invoke(new Action<int>(pi => progressBarGeneticLearn.Value = pi), p));
                    }
                    catch
                    {
                        trainRes = false;
                    }
                });

            _geneticCts = null;

            buttonLearnGenetic.Text = "Learn";
            groupBoxGeneticParams.Enabled = groupBoxGeneticSolution.Enabled = buttonLearnGenetic.Enabled = true;

            if (!trainRes)
            {
                return;
            }

            textBoxGeneticLearnError.Text = errorLearn.ToString("0.0000") + "%";
            textBoxGeneticSolution.Text   = Utils.ResolveChromosome(bestChromosome);

            AddToChart("GA", data.Item1.AddDays(inputCount - 1), solution);

            if (predCount != 0)
            {
                textBoxGeneticPredError.Text = CalculateError(comboBoxGeneticDataSet.SelectedItem, data.Item1.AddDays(solution.Length - 1), predictions.Skip(inputCount - 1)).ToString("0.0000") + "%";

                AddToChart("GA (Pred.)", data.Item1.AddDays(inputCount - 1).AddDays(solution.Length - 1), predictions.Skip(inputCount - 1));
            }
        }

        /// <summary>
        /// Occurs when the Clear menu item is clicked on the Learn button.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void clearToolStripMenuItemGenetic_Click(object sender, EventArgs e)
        {
            if (_geneticCts != null)
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
                chart.Series.Remove(chart.Series.FirstOrDefault(x => x.Name == "GA (Pred.)"));
            }
            catch { }
        }

        #endregion
    }
}
