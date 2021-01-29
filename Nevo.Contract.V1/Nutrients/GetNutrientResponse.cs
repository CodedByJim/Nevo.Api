using Nevo.Data.Nutrients;

namespace Nevo.Contract.V1.Nutrients
{
    /// <summary>
    ///     A response containing a single nutrient.
    /// </summary>
    public sealed record GetNutrientResponse
    {
        /// <summary>
        ///     Nutrient.
        /// </summary>
        public Nutrient? Nutrient { get; init; }
    }
}