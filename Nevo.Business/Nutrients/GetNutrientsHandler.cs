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
    using IGetNutrientsQuery = IQuery<SelectAll<Nutrient>, EquatableList<Nutrient>>;

    /// <summary>
    ///     Handles <see cref="GetNutrientRequest" />.
    /// </summary>
    public class GetNutrientsHandler : IHandler<GetNutrientsRequest, GetNutrientsResponse>
    {
        private readonly IGetNutrientsQuery _getNutrients;

        /// <summary>
        ///     Create a new <see cref="GetNutrientHandler" />.
        /// </summary>
        /// <param name="getNutrientsQuery">The query used to get nutrients.</param>
        public GetNutrientsHandler(IGetNutrientsQuery getNutrientsQuery) => _getNutrients = getNutrientsQuery;

        /// <inheritdoc />
        public async Task<GetNutrientsResponse?> Handle(GetNutrientsRequest request, CancellationToken cancellationToken)
        {
            var nutrients = await _getNutrients.Query(new(), cancellationToken);
            if (nutrients?.Any() == true)
                return new()
                {
                    Nutrients = nutrients
                };

            return null;
        }
    }
}