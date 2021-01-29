using System;
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
    ///     Handles <see cref="GetNutrientRequest" />.
    /// </summary>
    public class GetNutrientHandler : IHandler<GetNutrientRequest, GetNutrientResponse>
    {
        private readonly IQuery<SelectOne<Nutrient, string>, Nutrient> _getNutrientQuery;

        /// <summary>
        ///     Create a new <see cref="GetNutrientHandler" />.
        /// </summary>
        /// <param name="nutrientQuery">The query to retrieve a nutrient.</param>
        public GetNutrientHandler(IQuery<SelectOne<Nutrient, string>, Nutrient> nutrientQuery) =>
            _getNutrientQuery = nutrientQuery;

        /// <inheritdoc />
        public async Task<GetNutrientResponse?> Handle(GetNutrientRequest request, CancellationToken cancellationToken)
        {
            if (request.NutrientCode == null)
                throw new ArgumentException("No nutrient code provided.", nameof(request));

            var nutrient = await _getNutrientQuery.Query(request.NutrientCode, cancellationToken);
            if (nutrient != null)
                return new()
                {
                    Nutrient = nutrient
                };

            return null;
        }
    }
}