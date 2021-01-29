using Coded.Core.Data;

namespace Nevo.Data.Products
{
    /// <summary>
    ///     Get nutrients by product query.
    /// </summary>
    public sealed class GetNutrientsByProductQuery : ListQuery<GetNutrientsByProduct, ProductNutrient>
    {
        private const string SQL = "SELECT" +
                                   " nutrient_code," +
                                   " source_id," +
                                   " percentage," +
                                   " name_en, " +
                                   " name_nl " +
                                   " FROM product_nutrient" +
                                   " JOIN nutrients" +
                                   " ON product_nutrient.nutrient_code = nutrients.code" +
                                   " WHERE product_code = @ProductCode " +
                                   " ORDER BY percentage DESC ";

        /// <summary>
        ///     Create a new get nutrients by product query.
        /// </summary>
        /// <param name="unitOfWork">The active unit of work.</param>
        public GetNutrientsByProductQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}