using System.ComponentModel.DataAnnotations;

namespace Nevo.Contract.V1
{
    /// <summary>
    ///     Base class for paginated response.
    /// </summary>
    public abstract record BasePaginatedResponse
    {
        /// <summary>
        ///     The requested page.
        /// </summary>
        [Required]
        public int Page { get; init; }

        /// <summary>
        ///     The number of items in this response.
        /// </summary>

        public abstract int Count { get; }

        /// <summary>
        ///     The number of items that exist in total.
        /// </summary>
        [Required]
        public int? Total { get; init; }

        /// <summary>
        ///     The number of pages for products with this nutrient in total.
        /// </summary>
        public int TotalPages => 1 + ((Total.GetValueOrDefault() - 1) / 100);

        /// <summary>
        ///     True if there is another page.
        /// </summary>
        public bool HasNext => (Page + 1) * 100 < Total;
    }
}