using Coded.Core.Data;

namespace Nevo.Data.Groups
{
    /// <summary>
    ///     Get all groups.
    /// </summary>
    public sealed class GetGroupsQuery : ListQuery<SelectAll<Group>, Group>
    {
        private const string SQL = "SELECT * FROM groups";

        /// <summary>
        ///     Create a new get groups query.
        /// </summary>
        /// <param name="unitOfWork">The active unit of work.</param>
        public GetGroupsQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}