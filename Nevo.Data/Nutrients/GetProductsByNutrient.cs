namespace Nevo.Data.Nutrients
{
    /// <summary>
    ///     Get products by nutrient query arguments.
    /// </summary>
    public sealed record GetProductsByNutrient : BasePaginatedQueryArguments<NutrientProduct>
    {
        /// <summary>
        ///     The nutrient code.
        /// </summary>
        public string? NutrientCode { get; init; }
    }
}