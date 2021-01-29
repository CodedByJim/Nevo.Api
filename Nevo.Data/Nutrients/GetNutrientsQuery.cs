using Coded.Core.Data;

namespace Nevo.Data.Nutrients
{
    /// <summary>
    ///     Get all nutrients query.
    /// </summary>
    public sealed class GetNutrientsQuery : ListQuery<SelectAll<Nutrient>, Nutrient>
    {
        private const string SQL = "SELECT * FROM nutrients";

        /// <summary>
        ///     Create a new <see cref="GetNutrientQuery" />.
        /// </summary>
        /// <param name="unitOfWork">The unit of work</param>
        public GetNutrientsQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}