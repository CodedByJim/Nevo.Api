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
    ///     Handles <see cref="GetProductNutrientsRequest" />.
    /// </summary>
    public class GetProductNutrientsHandler : IHandler<GetProductNutrientsRequest, GetProductNutrientsResponse>
    {
        private readonly IQuery<GetNutrientsByProduct, EquatableList<ProductNutrient>> _getNutrientsByProductQuery;
        private readonly IQuery<SelectOne<Product, int>, Product> _getProductQuery;

        /// <summary>
        ///     Create a new <see cref="GetProductNutrientsHandler" />.
        /// </summary>
        /// <param name="getNutrientsByProductQuery">The query used to get nutrients by product.</param>
        /// <param name="getProductQuery">The query used to get products.</param>
        public GetProductNutrientsHandler(IQuery<GetNutrientsByProduct, EquatableList<ProductNutrient>> getNutrientsByProductQuery,
            IQuery<SelectOne<Product, int>, Product> getProductQuery)
        {
            _getNutrientsByProductQuery = getNutrientsByProductQuery;
            _getProductQuery = getProductQuery;
        }

        /// <inheritdoc />
        public async Task<GetProductNutrientsResponse?> Handle(GetProductNutrientsRequest request, CancellationToken cancellationToken)
        {
            var product = await _getProductQuery.Query(request.ProductCode, cancellationToken);
            var nutrients = await _getNutrientsByProductQuery.Query(request.ProductCode, cancellationToken);

            if (product == null || nutrients?.Any() != true)
                return null;

            return new()
            {
                Product = product,
                Nutrients = nutrients
            };
        }
    }
}