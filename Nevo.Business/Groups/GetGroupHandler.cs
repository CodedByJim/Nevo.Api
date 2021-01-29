using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Handler;
using Coded.Core.Query;
using Nevo.Contract.V1.Groups;
using Nevo.Data;
using Nevo.Data.Groups;

namespace Nevo.Business.Groups
{
    /// <summary>
    ///     Handler that handles get group requests.
    /// </summary>
    public class GetGroupHandler : IHandler<GetGroupRequest, GetGroupResponse>
    {
        private readonly IQuery<CountProductsByGroup, Primitive<int>> _countProductsByGroupQuery;
        private readonly IQuery<SelectOne<Group, int>, Group> _groupQuery;

        /// <summary>
        ///     Create a new <see cref="GetGroupHandler" />.
        /// </summary>
        /// <param name="countProductsByGroupQuery">The query used to count products by group.</param>
        /// <param name="groupQuery">Group query.</param>
        public GetGroupHandler(IQuery<CountProductsByGroup, Primitive<int>> countProductsByGroupQuery, IQuery<SelectOne<Group, int>, Group> groupQuery)
        {
            _countProductsByGroupQuery = countProductsByGroupQuery;
            _groupQuery = groupQuery;
        }

        /// <summary>
        ///     Handles the <see cref="GetGroupRequest" />.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The groups found.</returns>
        public async Task<GetGroupResponse?> Handle(GetGroupRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var group = await _groupQuery.Query(request.GroupCode, cancellationToken);
            var productCount = await _countProductsByGroupQuery.Query(request.GroupCode, cancellationToken);

            if (group != null)
                return new()
                {
                    Group = group,
                    ProductCount = productCount ?? 0
                };
            return null;
        }
    }
}