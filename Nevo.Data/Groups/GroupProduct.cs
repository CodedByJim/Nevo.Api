namespace Nevo.Data.Groups
{
    /// <summary>
    ///     Product in a group.
    /// </summary>
    public sealed record GroupProduct
    {
        /// <summary>
        ///     Product code.
        /// </summary>
        public int Code { get; init; }

        /// <summary>
        ///     Product-identity English.
        /// </summary>
        public string? DescriptionEn { get; init; }

        /// <summary>
        ///     Product-identity Dutch (name, cooking method, packaging).
        /// </summary>
        public string? DescriptionNl { get; init; }
    }
}