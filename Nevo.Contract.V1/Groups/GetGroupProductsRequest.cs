using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Nevo.Contract.V1.Groups
{
    /// <summary>
    ///     Get products within a group.
    /// </summary>
    public sealed record GetGroupProductsRequest : BasePaginatedRequest<GetGroupProductsResponse>
    {
        /// <summary>
        ///     The group code/
        /// </summary>
        [FromRoute(Name = "code")]
        [Required]
        public int GroupCode { get; init; }
    }
}