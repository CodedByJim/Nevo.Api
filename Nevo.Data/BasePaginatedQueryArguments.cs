using System;
using Coded.Core.Query;

namespace Nevo.Data
{
    /// <summary>
    ///     Default properties for paginated queries.
    /// </summary>
    public abstract record BasePaginatedQueryArguments<TResult> : IQueryArguments<EquatableList<TResult>>
        where TResult : class, IEquatable<TResult>, new()
    {
        /// <summary>
        ///     Number of rows to return.
        /// </summary>
        public int Rows { get; init; }

        /// <summary>
        ///     The page to return.
        /// </summary>
        public int Page { get; init; }

        /// <summary>
        ///     The calculated offset.
        /// </summary>
        public int Offset => Rows * Page;
    }
}