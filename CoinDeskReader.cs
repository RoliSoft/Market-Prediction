namespace MarketPrediction
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Implements a CoinDesk CSV data dump reader.
    /// Data is freely available from http://www.coindesk.com/price/
    /// </summary>
    class CoinDeskReader
    {
        /// <summary>
        /// Reads the available indices from the specified file.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>List of date and associated index.</returns>
        public static SortedDictionary<DateTime, decimal> ReadIndex(string filename)
        {
            var index = new SortedDictionary<DateTime, decimal>();

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

                    var date = DateTime.Parse(vals[0]);

                    index.Add(date, decimal.Parse(vals[1]));
                }
            }

            return index;
        }
    }
}
