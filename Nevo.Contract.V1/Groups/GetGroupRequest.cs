using System.ComponentModel.DataAnnotations;
using Coded.Core.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Nevo.Contract.V1.Groups
{
    /// <summary>
    ///     Get a single group by group code.
    /// </summary>
    public sealed record GetGroupRequest : IRequest<GetGroupResponse>
    {
        /// <summary>
        ///     The group code.
        /// </summary>
        [FromRoute(Name = "code")]
        [Required]
        public int GroupCode { get; init; }
    }
}