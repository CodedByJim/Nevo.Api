using System;
using System.ComponentModel;
using Coded.Core.Handler;
using Microsoft.AspNetCore.Mvc;

namespace Nevo.Contract.V1
{
    /// <summary>
    ///     Base class for paginated requests.
    /// </summary>
    public abstract record BasePaginatedRequest<TResponse> : IRequest<TResponse>
        where TResponse : BasePaginatedResponse, IEquatable<TResponse>, new()
    {
        /// <summary>
        ///     Which page to retrieve, 100 results per page, starts at zero (0).
        /// </summary>
        [FromQuery(Name = "page")]
        [DefaultValue(0)]
        public int Page { get; init; }
    }
}