namespace Nevo.Data.Groups
{
    /// <summary>
    ///     The group.
    /// </summary>
    public sealed record Group
    {
        /// <summary>
        ///     The group code.
        /// </summary>
        public int Code { get; init; }

        /// <summary>
        ///     Description in English.
        /// </summary>
        public string? DescriptionEn { get; init; }

        /// <summary>
        ///     Description in Dutch.
        /// </summary>
        public string? DescriptionNl { get; init; }
    }
}