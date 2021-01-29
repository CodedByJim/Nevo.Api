namespace Nevo.Data.Nutrients
{
    /// <summary>
    ///     Percentage of a product.
    /// </summary>
    public sealed record NutrientProduct
    {
        /// <summary>
        ///     The product code.
        /// </summary>
        public int ProductCode { get; init; }

        /// <summary>
        ///     The source of this measurement or calculation.
        /// </summary>
        public string? SourceId { get; init; }

        /// <summary>
        ///     The percentage of this component in relation to the total product.
        /// </summary>
        public double Percentage { get; init; }
    }
}