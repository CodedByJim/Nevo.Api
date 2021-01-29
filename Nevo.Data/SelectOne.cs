using System;
using System.ComponentModel.DataAnnotations;
using Coded.Core.Query;

namespace Nevo.Data
{
    /// <summary>
    ///     Select one entity of type <typeparamref name="T" />.
    /// </summary>
    /// <typeparam name="T">The entity type.</typeparam>
    /// <typeparam name="TId">The id type.</typeparam>
    public sealed record SelectOne<T, TId> : IQueryArguments<T> where T : class, IEquatable<T>, new()
    {
        /// <summary>
        ///     The id of the entity to retrieve.
        /// </summary>
        [Required]
        public TId? Id { get; init; }

        /// <summary>
        ///     Implicit cast used to quickly wrap the Id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>A wrapped value.</returns>
        public static implicit operator SelectOne<T, TId>(TId id) => new() {Id = id};
    }
}