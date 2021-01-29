using System.Collections.Generic;
using Nevo.Data.Products;

namespace Nevo.Contract.V1.Products
{
    /// <summary>
    ///     Get products response.
    /// </summary>
    public sealed record GetProductsResponse : BasePaginatedResponse
    {
        /// <summary>
        ///     The products.
        /// </summary>
        public List<Product>? Products { get; init; }

        /// <summary>
        ///     The product count.
        /// </summary>
        public override int Count => Products?.Count ?? 0;
    }
}