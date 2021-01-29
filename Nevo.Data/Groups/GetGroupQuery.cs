using Coded.Core.Data;

namespace Nevo.Data.Groups
{
    /// <summary>
    ///     Get a single group.
    /// </summary>
    public sealed class GetGroupQuery : SingleQuery<SelectOne<Group, int>, Group>
    {
        private const string SQL = "SELECT * FROM groups WHERE code = @Id";

        /// <summary>
        ///     Create a new get group query.
        /// </summary>
        /// <param name="unitOfWork">The active unit of work.</param>
        public GetGroupQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}