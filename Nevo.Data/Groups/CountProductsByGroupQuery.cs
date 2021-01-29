using Coded.Core.Data;

namespace Nevo.Data.Groups
{
    /// <summary>
    ///     Count products by group query.
    /// </summary>
    public sealed class CountProductsByGroupQuery : SingleQuery<CountProductsByGroup, Primitive<int>>
    {
        private const string SQL = "SELECT COUNT(*) Value FROM products WHERE group_code = @GroupCode";

        /// <summary>
        ///     Create a new count products by group query.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public CountProductsByGroupQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}