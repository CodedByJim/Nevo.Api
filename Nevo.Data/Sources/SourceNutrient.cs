namespace Nevo.Data.Sources
{
    /// <summary>
    ///     Nutrient reported in source.
    /// </summary>
    public sealed record SourceNutrient
    {
        /// <summary>
        ///     The nutrient code.
        /// </summary>
        public string? NutrientCode { get; init; }

        /// <summary>
        ///     The product code.
        /// </summary>
        public int ProductCode { get; init; }

        /// <summary>
        ///     The percentage of this component in relation to the total product.
        /// </summary>
        public double Percentage { get; init; }
    }
}