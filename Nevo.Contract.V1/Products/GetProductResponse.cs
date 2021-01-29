using Nevo.Data.Products;

namespace Nevo.Contract.V1.Products
{
    /// <summary>
    ///     Get product response.
    /// </summary>
    public sealed record GetProductResponse
    {
        /// <summary>
        ///     The product.
        /// </summary>
        public Product? Product { get; init; }
    }
}