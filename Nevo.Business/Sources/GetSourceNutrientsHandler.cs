using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Handler;
using Coded.Core.Query;
using Nevo.Contract.V1.Sources;
using Nevo.Data;
using Nevo.Data.Sources;

namespace Nevo.Business.Sources
{
    /// <summary>
    ///     Handles the <see cref="GetSourceNutrientsRequest" />.
    /// </summary>
    public class GetSourceNutrientsHandler : IHandler<GetSourceNutrientsRequest, GetSourceNutrientsResponse>
    {
        private readonly IQuery<CountNutrientsBySource, Primitive<int>> _countNutrientsBySourceQuery;
        private readonly IQuery<GetNutrientsBySource, EquatableList<SourceNutrient>> _getNutrientsBySourceQuery;

        /// <summary>
        ///     Create a new <see cref="GetSourceNutrientsHandler" />.
        /// </summary>
        /// <param name="getNutrientsBySourceQuery">Query used to get nutrients by source.</param>
        /// <param name="countNutrientsBySourceQuery">Query used to count nutrients by source.</param>
        public GetSourceNutrientsHandler(IQuery<GetNutrientsBySource, EquatableList<SourceNutrient>> getNutrientsBySourceQuery,
            IQuery<CountNutrientsBySource, Primitive<int>> countNutrientsBySourceQuery)
        {
            _getNutrientsBySourceQuery = getNutrientsBySourceQuery;
            _countNutrientsBySourceQuery = countNutrientsBySourceQuery;
        }

        /// <inheritdoc />
        public async Task<GetSourceNutrientsResponse?> Handle(GetSourceNutrientsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var productNutrients = await _getNutrientsBySourceQuery.Query(new()
            {
                SourceId = request.SourceId,
                Page = request.Page,
                Rows = 100
            }, cancellationToken);

            var totalCount = await _countNutrientsBySourceQuery.Query(new()
            {
                SourceId = request.SourceId
            }, cancellationToken);

            if (productNutrients?.Any() != true || (totalCount ?? 0) <= 0)
                return null;

            return new()
            {
                Nutrients = productNutrients,
                Page = request.Page,
                Total = totalCount ?? 0
            };
        }
    }
}