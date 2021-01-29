using Coded.Core.Data;

namespace Nevo.Data.Sources
{
    /// <summary>
    ///     Get nutrient by source query.
    /// </summary>
    public sealed class GetNutrientsBySourceQuery : ListQuery<GetNutrientsBySource, SourceNutrient>
    {
        private const string SQL = "SELECT * FROM product_nutrient " +
                                   "WHERE source_id = @SourceId " +
                                   "ORDER BY percentage DESC " +
                                   "LIMIT @Rows offset @Offset";

        /// <summary>
        ///     Create a new get nutrients by source query.
        /// </summary>
        /// <param name="unitOfWork">The active unit of work.</param>
        public GetNutrientsBySourceQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}