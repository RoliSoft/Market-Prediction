namespace MarketPrediction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Encapsulates several helper methods.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Resolves the notation returned by the genetic algorithm.
        /// </summary>
        /// <param name="notation">The notation.</param>
        /// <returns>Normalized form.</returns>
        public static string ResolveChromosome(string notation)
        {
            var stack  = new Stack<string>();
            var tokens = notation.Split(' ');
            var wrap   = (Func<string, string>)(s => s.StartsWith("(") && s.EndsWith(")") ? s : (s.IndexOfAny("+-*/".ToCharArray()) == -1 ? s : "(" + s + ")"));

            foreach (var token in tokens)
            {
                switch (token)
                {
                    default:
                    {
                        stack.Push(token);
                    }
                    break;

                    case "+":
                    case "-":
                    {
                        var prevToken = stack.Pop();
                        stack.Push(stack.Pop() + token + prevToken);
                    }
                    break;

                    case "*":
                    case "/":
                    {
                        var prevToken = stack.Pop();
                        stack.Push(wrap(stack.Pop()) + token + wrap(prevToken));
                    }
                    break;
                }
            }

            return stack.Last();
        }
        
        /// <summary>
        /// Scales the specified value from a range to another.
        /// </summary>
        /// <param name="value">The value to scale.</param>
        /// <param name="min">The minimum of the current range.</param>
        /// <param name="max">The maximum of the current range.</param>
        /// <param name="newMin">The minimum of the new range.</param>
        /// <param name="newMax">The maximum of the new range.</param>
        /// <returns>Scaled value.</returns>
        public static double Scale(double value, double min, double max, double newMin = 0, double newMax = 1)
        {
            return value - min;//(value - min) * (newMax - newMin) / (max - min) + newMin;
        }

        /// <summary>
        /// Scales back a previously scaled value.
        /// </summary>
        /// <param name="value">The value to scale.</param>
        /// <param name="min">The minimum of the current range.</param>
        /// <param name="max">The maximum of the current range.</param>
        /// <param name="newMin">The minimum of the new range.</param>
        /// <param name="newMax">The maximum of the new range.</param>
        /// <returns>Scaled value.</returns>
        public static double ScaleBack(double value, double min, double max, double newMin = 0, double newMax = 1)
        {
            return value + min;//value / ((newMax - newMin) / (max - min) + newMin) + min;
        }
    }
}
