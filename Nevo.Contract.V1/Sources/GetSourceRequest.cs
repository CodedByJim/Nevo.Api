using System.ComponentModel.DataAnnotations;
using Coded.Core.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Nevo.Contract.V1.Sources
{
    /// <summary>
    ///     Request a source.
    /// </summary>
    public sealed record GetSourceRequest : IRequest<GetSourceResponse>
    {
        /// <summary>
        ///     The source id.
        /// </summary>
        [FromRoute(Name = "id")]
        [Required]
        public string? SourceId { get; init; }
    }
}