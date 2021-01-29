using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Nevo.Contract.V1.Nutrients
{
    /// <summary>
    ///     Retrieve products containing a nutrient, ordered by percentage descending.
    /// </summary>
    public sealed record GetNutrientProductsRequest : BasePaginatedRequest<GetNutrientProductsResponse>
    {
        /// <summary>
        ///     The nutrient to lookup products.
        /// </summary>
        [FromRoute(Name = "code")]
        [Required]
        public string? NutrientCode { get; init; }
    }
}