using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Nevo.Contract.V1.Sources
{
    /// <summary>
    ///     Gets the nutrient values described in the source.
    /// </summary>
    public sealed record GetSourceNutrientsRequest : BasePaginatedRequest<GetSourceNutrientsResponse>
    {
        /// <summary>
        ///     The source id.
        /// </summary>
        [FromRoute(Name = "id")]
        [Required]
        public string? SourceId { get; init; }
    }
}