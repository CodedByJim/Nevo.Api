using Coded.Core.Data;

namespace Nevo.Data.Sources
{
    /// <summary>
    ///     Get source query.
    /// </summary>
    public sealed class GetSourceQuery : SingleQuery<SelectOne<Source, string>, Source>
    {
        private const string SQL = "SELECT * FROM sources WHERE id = @Id";

        /// <summary>
        ///     Get source query.
        /// </summary>
        /// <param name="unitOfWork">The active unit of work</param>
        public GetSourceQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}