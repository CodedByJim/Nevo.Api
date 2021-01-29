using System.ComponentModel.DataAnnotations;
using Coded.Core.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Nevo.Contract.V1.Products
{
    /// <summary>
    ///     Get the products nutrients.
    /// </summary>
    public sealed record GetProductNutrientsRequest : IRequest<GetProductNutrientsResponse>
    {
        /// <summary>
        ///     The product code.
        /// </summary>
        [FromRoute(Name = "code")]
        [Required]
        public int ProductCode { get; init; }
    }
}