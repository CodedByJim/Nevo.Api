using System.ComponentModel.DataAnnotations;
using Coded.Core.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Nevo.Contract.V1.Nutrients
{
    /// <summary>
    ///     Retrieve a singe nutrient by code.
    /// </summary>
    public sealed record GetNutrientRequest : IRequest<GetNutrientResponse>
    {
        /// <summary>
        ///     The (case sensitive) nutrient code.
        /// </summary>
        [FromRoute(Name = "code")]
        [Required]
        public string? NutrientCode { get; init; }
    }
}