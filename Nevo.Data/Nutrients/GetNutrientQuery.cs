using Coded.Core.Data;

namespace Nevo.Data.Nutrients
{
    /// <summary>
    ///     Get nutrients query.
    /// </summary>
    public sealed class GetNutrientQuery : SingleQuery<SelectOne<Nutrient, string>, Nutrient>
    {
        private const string SQL = "SELECT * FROM nutrients WHERE code = @Id";

        /// <summary>
        ///     Create a new <see cref="GetNutrientQuery" />.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public GetNutrientQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}