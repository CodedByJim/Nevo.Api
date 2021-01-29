using System.ComponentModel.DataAnnotations;

namespace Nevo.Data.Products
{
    /// <summary>
    ///     Nutrient and percentage measured as reported by source.
    /// </summary>
    public sealed record ProductNutrient
    {
        /// <summary>
        ///     The nutrient code.
        /// </summary>
        public string? NutrientCode { get; init; }

        /// <summary>
        ///     The source of this measurement or calculation.
        /// </summary>
        public string? SourceId { get; init; }

        /// <summary>
        ///     The percentage of this component in relation to the total product.
        /// </summary>
        [Range(0.0, 100.0)]
        public double Percentage { get; init; }

        /// <summary>
        ///     Nutrient name in Dutch.
        /// </summary>
        public string? NameNl { get; init; }

        /// <summary>
        ///     Nutrient name in English.
        /// </summary>
        public string? NameEn { get; init; }
    }
}