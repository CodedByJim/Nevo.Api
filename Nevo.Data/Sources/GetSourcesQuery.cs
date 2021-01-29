using Coded.Core.Data;

namespace Nevo.Data.Sources
{
    /// <summary>
    ///     Get sources query.
    /// </summary>
    public sealed class GetSourcesQuery : ListQuery<GetSources, Source>
    {
        /// <summary>
        ///     SQL query.
        /// </summary>
        private const string SQL = "SELECT * FROM sources " +
                                   "LIMIT @Rows offset @Offset";

        /// <summary>
        ///     Create a get sources query.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public GetSourcesQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}