using Coded.Core.Query;

namespace Nevo.Data
{
    /// <summary>
    ///     Generic count query arguments for a certain entity.
    /// </summary>
    /// <typeparam name="T">The entity type to count.</typeparam>
    // ReSharper disable once UnusedTypeParameter
    public sealed record Count<T> : IQueryArguments<Primitive<int>>
    {
    }
}