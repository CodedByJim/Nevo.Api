using System.ComponentModel.DataAnnotations;
using Coded.Core.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Nevo.Contract.V1.Products
{
    /// <summary>
    ///     Get product request.
    /// </summary>
    public sealed record GetProductRequest : IRequest<GetProductResponse>
    {
        /// <summary>
        ///     The product code.
        /// </summary>
        [FromRoute(Name = "code")]
        [Required]
        public int ProductCode { get; init; }
    }
}