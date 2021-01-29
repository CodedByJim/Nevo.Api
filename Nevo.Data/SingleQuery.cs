using System;
using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Data;
using Coded.Core.Query;

namespace Nevo.Data
{
    /// <summary>
    ///     Query with a single record as result.
    /// </summary>
    /// <typeparam name="TArguments">The query argument type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    public abstract class SingleQuery<TArguments, TResult> :
        IQuery<TArguments, TResult>,
        IQueryArguments<TResult>
        where TResult : class, IEquatable<TResult>, new()
        where TArguments : class, IQueryArguments<TResult>, IEquatable<TArguments>

    {
        private readonly string _sql;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Create a new single query.
        /// </summary>
        /// <param name="unitOfWork">The active.</param>
        /// <param name="sql">The sql-query to execute.</param>
        protected SingleQuery(IUnitOfWork unitOfWork, string sql)
        {
            _unitOfWork = unitOfWork;
            _sql = sql;
        }

        /// <inheritdoc />
        public async Task<TResult?> Query(TArguments arguments, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await _unitOfWork.QuerySingleOrDefaultAsync<TResult>(_sql, cancellationToken, arguments);
        }
    }
}