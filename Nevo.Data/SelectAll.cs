using System;
using Coded.Core.Query;

namespace Nevo.Data
{
    /// <summary>
    ///     Select all arguments.
    /// </summary>
    /// <typeparam name="T">The type to select all of.</typeparam>
    public sealed record SelectAll<T> : IQueryArguments<EquatableList<T>>
        where T : IEquatable<T>
    {
    }
}