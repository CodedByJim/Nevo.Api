using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Handler;
using Coded.Core.Query;
using Nevo.Contract.V1.Groups;
using Nevo.Data;
using Nevo.Data.Groups;

namespace Nevo.Business.Groups
{
    /// <summary>
    ///     Handles the get group products request.
    /// </summary>
    public class GetGroupProductsHandler : IHandler<GetGroupProductsRequest, GetGroupProductsResponse>
    {
        private readonly IQuery<CountProductsByGroup, Primitive<int>> _countProductsByGroup;
        private readonly IQuery<GetProductsByGroup, EquatableList<GroupProduct>> _getProductsByGroup;

        /// <summary>
        ///     Create a new <see cref="GetGroupProductsHandler" />.
        /// </summary>
        /// <param name="getProductsByGroup">The get products by group query.</param>
        /// <param name="countProductsByGroup">The count products by group query.</param>
        public GetGroupProductsHandler(IQuery<GetProductsByGroup, EquatableList<GroupProduct>> getProductsByGroup,
            IQuery<CountProductsByGroup, Primitive<int>> countProductsByGroup)
        {
            _getProductsByGroup = getProductsByGroup;
            _countProductsByGroup = countProductsByGroup;
        }

        /// <inheritdoc />
        public async Task<GetGroupProductsResponse?> Handle(GetGroupProductsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var products = await _getProductsByGroup.Query(new()
            {
                GroupCode = request.GroupCode,
                Rows = 100,
                Page = request.Page
            }, cancellationToken);
            var count = await _countProductsByGroup.Query(request.GroupCode, cancellationToken);

            if (products?.Any() == true && (count ?? 0) > 0)
                return new()
                {
                    GroupCode = request.GroupCode,
                    Products = products,
                    Page = request.Page,
                    Total = count ?? 0
                };
            return null;
        }
    }
}