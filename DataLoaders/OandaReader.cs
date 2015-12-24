namespace MarketPrediction
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Implements an Oanda CSV data dump reader.
    /// Data is freely available from http://www.oanda.com/currency/historical-rates/
    /// </summary>
    public static class OandaReader
    {
        /// <summary>
        /// Reads the available indices from the specified file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>List of indices with list of date and associated index.</returns>
        public static Dictionary<string, SortedDictionary<DateTime, decimal>> ReadIndices(string filename)
        {
            var indices = new Dictionary<string, SortedDictionary<DateTime, decimal>>
                {
                    { "EUR/USD", new SortedDictionary<DateTime, decimal>() },
                    { "EUR/GBP", new SortedDictionary<DateTime, decimal>() },
                    { "EUR/RON", new SortedDictionary<DateTime, decimal>() },
                };

            using (var sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line[0] == '#')
                    {
                        continue;
                    }

                    var vals = line.Split(",".ToCharArray());

                    var date = DateTime.Parse(vals[0].Trim("\"".ToCharArray()));

                    indices["EUR/USD"].Add(date, decimal.Parse(vals[1].Trim("\"".ToCharArray())));
                    indices["EUR/GBP"].Add(date, decimal.Parse(vals[2].Trim("\"".ToCharArray())));
                    indices["EUR/RON"].Add(date, decimal.Parse(vals[3].Trim("\"".ToCharArray())));
                }
            }

            return indices;
        }
    }
}
