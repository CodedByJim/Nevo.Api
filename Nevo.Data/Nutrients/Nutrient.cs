namespace Nevo.Data.Nutrients
{
    /// <summary>
    ///     Nutrient
    /// </summary>
    public sealed record Nutrient
    {
        /// <summary>
        ///     The nutrient code
        /// </summary>
        public string? Code { get; init; }

        /// <summary>
        ///     The nutrient name in Dutch
        /// </summary>
        public string? NameNl { get; init; }

        /// <summary>
        ///     The nutrient name in English
        /// </summary>
        public string? NameEn { get; init; }
    }
}