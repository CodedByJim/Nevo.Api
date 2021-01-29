using System.ComponentModel.DataAnnotations;
using Coded.Core.Query;

namespace Nevo.Data.Nutrients
{
    /// <summary>
    ///     Count product by nutrient query arguments.
    /// </summary>
    public sealed record CountProductsByNutrient : IQueryArguments<Primitive<int>>
    {
        /// <summary>
        ///     The nutrient code.
        /// </summary>
        [Required]
        public string? NutrientCode { get; init; }

        /// <summary>
        ///     Implicit cast used to pass the nutrient code as argument.
        /// </summary>
        /// <param name="nutrientCode">The nutrient code.</param>
        /// <returns>Query arguments object.</returns>
        public static implicit operator CountProductsByNutrient(string nutrientCode) => new()
        {
            NutrientCode = nutrientCode
        };
    }
}