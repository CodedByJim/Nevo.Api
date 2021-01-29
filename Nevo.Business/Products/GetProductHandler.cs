using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Handler;
using Coded.Core.Query;
using Nevo.Contract.V1.Products;
using Nevo.Data;
using Nevo.Data.Products;

namespace Nevo.Business.Products
{
    /// <summary>
    ///     Handles <see cref="GetProductRequest" />.
    /// </summary>
    public class GetProductHandler : IHandler<GetProductRequest, GetProductResponse>
    {
        private readonly IQuery<SelectOne<Product, int>, Product> _getProductQuery;

        /// <summary>
        ///     Create a new <see cref="GetProductHandler" />.
        /// </summary>
        /// <param name="getProductQuery">The query to retrieve a product by id.</param>
        public GetProductHandler(IQuery<SelectOne<Product, int>, Product> getProductQuery)
            => _getProductQuery = getProductQuery;

        /// <inheritdoc />
        public async Task<GetProductResponse?> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var product = await _getProductQuery.Query(request.ProductCode, cancellationToken);
            if (product != null)
                return new()
                {
                    Product = product
                };
            return null;
        }
    }
}