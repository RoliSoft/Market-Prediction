using AForge;
using AForge.Neuro;
using AForge.Neuro.Learning;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load indices: " + ex.Message);
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
        /// Occurs when the Learn button is clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        private void buttonLearn_Click(object sender, EventArgs e)
        {
            SortedDictionary<DateTime, decimal> index = indices[(string)comboBoxSeries.SelectedItem];
            double[] data = index.Values.Select(x => (double)x).ToArray();

            double learningRate = 0.05;
            double momentum = 0.99;
            double sigmoidAlphaValue = 2.0;
            int windowSize = 5;
            int predictionSize = 1;
            int iterations = 1000;//1000

            progressBarNeuronLearn.Value = 0;
            progressBarNeuronLearn.Maximum = iterations;

            int samples = index.Count - predictionSize - windowSize;
            double yMin = (double)index.Values.Min();
            double[][] input = new double[samples][];
            double[][] output = new double[samples][];

            for (int i = 0; i < samples; i++)
            {
                input[i] = new double[windowSize];
                output[i] = new double[1];

                // set input
                for (int j = 0; j < windowSize; j++)
                {
                    input[i][j] = data[i + j] - yMin;
                }

                // set output
                output[i][0] = data[i + windowSize] - yMin;
            }

            Neuron.RandRange = new Range(0.3f, 0.3f);

            var nn = new ActivationNetwork(new BipolarSigmoidFunction(sigmoidAlphaValue),
                windowSize,     // number of inputs
                windowSize * 2, // number of neurons on the first layer
                1);             // number of neurons on the second layer
            
            var bp = new BackPropagationLearning(nn);
            bp.LearningRate = learningRate;
            bp.Momentum = momentum;
            
            int iteration = 1;

            // solution array
            int solutionSize = index.Count - windowSize;
            double[,] solution = new double[solutionSize, 2];
            double[] networkInput = new double[windowSize];

            // calculate X values to be used with solution function
            for (int j = 0; j < solutionSize; j++)
            {
                solution[j, 0] = j + windowSize;
            }

            bool needToStop = false;
            
            while (!needToStop)
            {
                double error = bp.RunEpoch(input, output) / samples;

                // calculate solution and learning and prediction errors
                double learningError = 0.0;
                double predictionError = 0.0;
                // go through all the data
                for (int i = 0, n = index.Count - windowSize; i < n; i++)
                {
                    // put values from current window as network's input
                    for (int j = 0; j < windowSize; j++)
                    {
                        networkInput[j] = data[i + j] - yMin;
                    }

                    // evalue the function
                    solution[i, 1] = nn.Compute(networkInput)[0] + yMin;

                    // calculate prediction error
                    if (i >= n - predictionSize)
                    {
                        predictionError += Math.Abs(solution[i, 1] - data[windowSize + i]);
                    }
                    else
                    {
                        learningError += Math.Abs(solution[i, 1] - data[windowSize + i]);
                    }
                }
                
                // increase current iteration
                iteration++;

                // check if we need to stop
                if ((iterations != 0) && (iteration > iterations))
                {
                    Text = predictionError + " " + learningError + " " + error;
                    break;
                }

                progressBarNeuronLearn.Value = iteration;
            }


            var series = new Series("NN");
            series.ChartType = SeriesChartType.FastLine;

            /*for (int j = windowSize, k = 0, n = index.Count; j < n; j++, k++)
            {
                //AddSubItem(dataList, j, solution[k, 1].ToString());
                series.Points.Add(solution[k, 1]);
            }*/

            /*int k = 0;
            foreach (var idx in index)
            {
                series.Points.AddXY(idx.Key, solution[k++, 1]);

                if (k >= solution.Length / 2)
                {
                    break;
                }
            }*/

            var date = index.Keys.Min();
            for (int j = windowSize, k = 0, n = index.Count; j < n; j++, k++)
            {
                //AddSubItem(dataList, j, solution[k, 1].ToString());
                series.Points.AddXY(date, solution[k, 1]);
                date = date.AddDays(1);
            }

            // predict 30 days into the future
            /*for (int i = 0; i < 30; i ++)
            {
                series.Points.AddXY(date, (nn.Compute(networkInput)[0] + 0.85) / factor + yMin);
                date = date.AddDays(1);
            }*/

            try
            {
                chart.Series.Add(series);
            }
            catch (ArgumentException)
            {
                chart.Series.Remove(chart.Series.FirstOrDefault(x => x.Name == "NN"));
                chart.Series.Add(series);
            }

            SetChartBoundaries();
        }

        #endregion
    }
}
