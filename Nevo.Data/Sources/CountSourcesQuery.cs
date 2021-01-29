using Coded.Core.Data;

namespace Nevo.Data.Sources
{
    /// <summary>
    ///     Get sources query.
    /// </summary>
    public sealed class CountSourcesQuery : SingleQuery<Count<Source>, Primitive<int>>
    {
        private const string SQL = "SELECT COUNT(*) Value FROM sources";

        /// <summary>
        ///     Create a new count sources query.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public CountSourcesQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}