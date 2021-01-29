using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Handler;
using Coded.Core.Query;
using Nevo.Contract.V1.Nutrients;
using Nevo.Data;
using Nevo.Data.Nutrients;

namespace Nevo.Business.Nutrients
{
    /// <summary>
    ///     Handles the GetNutrientProducts request.
    /// </summary>
    public class GetNutrientProductsHandler : IHandler<GetNutrientProductsRequest, GetNutrientProductsResponse>
    {
        private readonly IQuery<CountProductsByNutrient, Primitive<int>> _countProductsByNutrientQuery;
        private readonly IQuery<GetProductsByNutrient, EquatableList<NutrientProduct>> _getProductsByNutrientQuery;

        /// <summary>
        ///     Create a new <see cref="GetNutrientProductsHandler" />.
        /// </summary>
        /// <param name="getProductsByNutrientQuery">The query to get the products by nutrient.</param>
        /// <param name="countProductsByNutrientQuery">The query to count the products by nutrient.</param>
        public GetNutrientProductsHandler(IQuery<GetProductsByNutrient, EquatableList<NutrientProduct>> getProductsByNutrientQuery,
            IQuery<CountProductsByNutrient, Primitive<int>> countProductsByNutrientQuery)
        {
            _getProductsByNutrientQuery = getProductsByNutrientQuery;
            _countProductsByNutrientQuery = countProductsByNutrientQuery;
        }

        /// <summary>
        ///     Handle the <see cref="GetNutrientProductsRequest" /> request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The products containing the nutrient.</returns>
        public async Task<GetNutrientProductsResponse?> Handle(GetNutrientProductsRequest request, CancellationToken cancellationToken)
        {
            if (request.NutrientCode == null)
                throw new ArgumentException("No nutrient code provided.", nameof(request));

            var productNutrients = await _getProductsByNutrientQuery.Query(
                new()
                {
                    NutrientCode = request.NutrientCode,
                    Rows = 100,
                    Page = request.Page
                }, cancellationToken);

            var productNutrientCount = await _countProductsByNutrientQuery.Query(
                request.NutrientCode
                , cancellationToken);

            if (productNutrients?.Any() != true || (productNutrientCount?.Value ?? 0) <= 0)
                return null;

            return new()
            {
                Products = productNutrients,
                Page = request.Page,
                Total = productNutrientCount ?? 0,
                NutrientCode = request.NutrientCode
            };
        }
    }
}