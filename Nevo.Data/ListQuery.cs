using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Data;
using Coded.Core.Query;

namespace Nevo.Data
{
    /// <summary>
    ///     Query for multiple results.
    /// </summary>
    /// <typeparam name="TArguments">Query argument type.</typeparam>
    /// <typeparam name="TResult">Query result type.</typeparam>
    public abstract class ListQuery<TArguments, TResult>
        : IQuery<TArguments, EquatableList<TResult>>
        where TArguments : class, IQueryArguments<EquatableList<TResult>>, IEquatable<TArguments>
        where TResult : IEquatable<TResult>
    {
        private readonly string _sql;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        ///     Create a new list query.
        /// </summary>
        /// <param name="unitOfWork">The current unit of work.</param>
        /// <param name="sql">The sql to execute.</param>
        protected ListQuery(IUnitOfWork unitOfWork, string sql)
        {
            _unitOfWork = unitOfWork;
            _sql = sql;
        }

        /// <inheritdoc />
        public virtual async Task<EquatableList<TResult>?> Query(TArguments arguments, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.QueryAsync<TResult>(_sql, cancellationToken, arguments);
            return result?.ToList();
        }
    }
}