namespace MarketPrediction
{
    /// <summary>
    /// Represents an interface for all transformers.
    /// </summary>
    interface ISeriesTransform
    {
        /// <summary>
        /// Gets the short name of the transformer.
        /// </summary>
        /// <returns>Short name of the transformer.</returns>
        string GetShortName();

        /// <summary>
        /// Gets the long name of the transformer.
        /// </summary>
        /// <returns>Long name of the transformer.</returns>
        string GetLongName();

        /// <summary>
        /// Adds an index to the transformer.
        /// </summary>
        /// <param name="value">The index value.</param>
        void AddIndex(decimal value);


        /// <summary>
        /// Determines whether this instance is ready.
        /// </summary>
        /// <returns><c>true</c> if this instance is ready; otherwise, <c>false</c>.</returns>
        bool IsReady();


        /// <summary>
        /// Gets the transformed value for the current iteration.
        /// </summary>
        /// <returns>Transformed value for the current iteration.</returns>
        decimal GetValue();
    }
}
