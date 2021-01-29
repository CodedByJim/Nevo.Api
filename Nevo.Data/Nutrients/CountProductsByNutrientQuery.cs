using Coded.Core.Data;

namespace Nevo.Data.Nutrients
{
    /// <summary>
    ///     Count products by nutrient query.
    /// </summary>
    public sealed class CountProductsByNutrientQuery : SingleQuery<CountProductsByNutrient, Primitive<int>>
    {
        private const string SQL = "SELECT COUNT(*) Value " +
                                   "FROM product_nutrient " +
                                   "WHERE nutrient_code = @NutrientCode " +
                                   "AND percentage IS NOT NULL " +
                                   "AND percentage > 0";

        /// <summary>
        ///     Create a new <see cref="CountProductsByNutrientQuery" />.
        /// </summary>
        /// <param name="unitOfWork">The active unit of work.</param>
        public CountProductsByNutrientQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}