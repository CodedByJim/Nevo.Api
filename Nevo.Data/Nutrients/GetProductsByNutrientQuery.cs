using Coded.Core.Data;

namespace Nevo.Data.Nutrients
{
    /// <summary>
    ///     Get products by nutrient.
    /// </summary>
    public sealed class GetProductsByNutrientQuery : ListQuery<GetProductsByNutrient, NutrientProduct>
    {
        private const string SQL = "SELECT product_code, source_id, percentage " +
                                   "FROM product_nutrient " +
                                   "WHERE nutrient_code = @NutrientCode " +
                                   "AND percentage IS NOT NULL " +
                                   "AND percentage > 0 " +
                                   "ORDER BY percentage DESC " +
                                   "LIMIT @Rows offset @Offset";

        /// <summary>
        ///     Create a new <see cref="GetProductsByNutrientQuery" />.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public GetProductsByNutrientQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}