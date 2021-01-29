using Coded.Core.Data;

namespace Nevo.Data.Groups
{
    /// <summary>
    ///     Gets the products within a group.
    /// </summary>
    public sealed class GetProductsByGroupQuery : ListQuery<GetProductsByGroup, GroupProduct>
    {
        private const string SQL = "SELECT products.code, products.description_nl, products.description_en " +
                                   "FROM products " +
                                   "WHERE group_code = @GroupCode " +
                                   "LIMIT @Rows offset @Offset ";

        /// <summary>
        ///     Creates a new get group products query.
        /// </summary>
        /// <param name="unitOfWork">The active unit of work.</param>
        public GetProductsByGroupQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}