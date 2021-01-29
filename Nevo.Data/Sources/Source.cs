using System.ComponentModel.DataAnnotations;

namespace Nevo.Data.Sources
{
    /// <summary>
    ///     Source.
    /// </summary>
    public sealed record Source
    {
        /// <summary>
        ///     Id.
        /// </summary>
        [Required]
        public string? Id { get; init; }

        /// <summary>
        ///     Source in English.
        /// </summary>
        public string? SourceEn { get; init; }

        /// <summary>
        ///     Source in Dutch.
        /// </summary>
        public string? SourceNl { get; init; }
    }
}