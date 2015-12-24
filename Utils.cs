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
    }
}
