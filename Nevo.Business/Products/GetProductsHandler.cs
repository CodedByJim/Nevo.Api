using System.Linq;
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
    ///     Handles the <see cref="GetProductRequest" />.
    /// </summary>
    public class GetProductsHandler : IHandler<GetProductsRequest, GetProductsResponse>
    {
        private readonly IQuery<Count<Product>, Primitive<int>> _countProductsQuery;
        private readonly IQuery<GetProducts, EquatableList<Product>> _getProductsQuery;

        /// <summary>
        ///     Create a new get products handler.
        /// </summary>
        /// <param name="getProductsQuery">The query used to get all products.</param>
        /// <param name="countProductsQuery">The query used to count all products.</param>
        public GetProductsHandler(IQuery<GetProducts, EquatableList<Product>> getProductsQuery, IQuery<Count<Product>, Primitive<int>> countProductsQuery)
        {
            _getProductsQuery = getProductsQuery;
            _countProductsQuery = countProductsQuery;
        }

        /// <summary>
        ///     Handles the get products request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The products.</returns>
        public async Task<GetProductsResponse?> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await _getProductsQuery.Query(new()
            {
                Rows = 100,
                Page = request.Page
            }, cancellationToken);
            var count = await _countProductsQuery.Query(new(), cancellationToken);

            if (products?.Any() != true || (count ?? 0) <= 0)
                return null;

            return new()
            {
                Page = request.Page,
                Products = products,
                Total = count ?? 0
            };
        }
    }
}