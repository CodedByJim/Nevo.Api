using Coded.Core.Data;

namespace Nevo.Data.Sources
{
    /// <summary>
    ///     Count nutrient values by source query.
    /// </summary>
    public sealed class CountNutrientsBySourceQuery : SingleQuery<CountNutrientsBySource, Primitive<int>>
    {
        private const string SQL = "SELECT COUNT(*) Value " +
                                   "FROM product_nutrient " +
                                   "WHERE source_id = @SourceId";

        /// <summary>
        ///     Create a new <see cref="CountNutrientsBySourceQuery" />.
        /// </summary>
        /// <param name="unitOfWork">The active unit of work.</param>
        public CountNutrientsBySourceQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}