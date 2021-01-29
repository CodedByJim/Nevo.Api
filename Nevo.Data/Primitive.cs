namespace Nevo.Data
{
    /// <summary>
    ///     Class used to wrap value types.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    public sealed record Primitive<T>
        where T : struct
    {
        /// <summary>
        ///     Value.
        /// </summary>
        public T Value { get; init; }

        /// <summary>
        ///     Implicit cast to the primitive value.
        /// </summary>
        /// <param name="primitive">The wrapped primitive</param>
        /// <returns>The unwrapped value.</returns>
        public static implicit operator T(Primitive<T> primitive) => primitive.Value;

        /// <summary>
        ///     Implicit cast used to quickly wrap the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A wrapped value.</returns>
        public static implicit operator Primitive<T>(T value) => new()
        {
            Value = value
        };
    }
}