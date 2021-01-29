using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Handler;
using Coded.Core.Query;
using Nevo.Contract.V1.Sources;
using Nevo.Data;
using Nevo.Data.Sources;

namespace Nevo.Business.Sources
{
    /// <summary>
    ///     Handler for the get sources request.
    /// </summary>
    public class GetSourcesHandler : IHandler<GetSourcesRequest, GetSourcesResponse>
    {
        private readonly IQuery<Count<Source>, Primitive<int>> _countSourcesQuery;
        private readonly IQuery<GetSources, EquatableList<Source>> _getSourcesQuery;

        /// <summary>
        ///     Create a new get sources handler.
        /// </summary>
        public GetSourcesHandler(IQuery<Count<Source>, Primitive<int>> countSourcesQuery, IQuery<GetSources, EquatableList<Source>> getSourcesQuery)
        {
            _countSourcesQuery = countSourcesQuery;
            _getSourcesQuery = getSourcesQuery;
        }

        /// <inheritdoc />
        public async Task<GetSourcesResponse?> Handle(GetSourcesRequest request, CancellationToken cancellationToken)
        {
            var sources = await _getSourcesQuery.Query(new()
            {
                Rows = 100,
                Page = request.Page
            }, cancellationToken);
            var sourcesCount = await _countSourcesQuery.Query(new(), cancellationToken);

            if (sources?.Any() != true || (sourcesCount ?? 0) <= 0)
                return null;

            return new()
            {
                Sources = sources,
                Page = request.Page,
                Total = sourcesCount ?? 0
            };
        }
    }
}