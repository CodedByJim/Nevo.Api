using System;
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
    ///     Get source handler.
    /// </summary>
    public class GetSourceHandler : IHandler<GetSourceRequest, GetSourceResponse>
    {
        private readonly IQuery<SelectOne<Source, string>, Source> _sourceQuery;

        /// <summary>
        ///     Create a new get source handler.
        /// </summary>
        /// <param name="sourceQuery">The query to get the source.</param>
        public GetSourceHandler(IQuery<SelectOne<Source, string>, Source> sourceQuery)
            => _sourceQuery = sourceQuery;

        /// <inheritdoc />
        public async Task<GetSourceResponse?> Handle(GetSourceRequest request, CancellationToken cancellationToken)
        {
            if (request.SourceId == null)
                throw new ArgumentException("No source id provided.", nameof(request));

            var source = await _sourceQuery.Query(request.SourceId, cancellationToken);

            if (source != null)
                return new()
                {
                    Source = source
                };

            return null;
        }
    }
}