using System.Linq;
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
    ///     Handles <see cref="GetGroupRequest" />.
    /// </summary>
    public class GetGroupsHandler : IHandler<GetGroupsRequest, GetGroupsResponse>
    {
        private readonly IQuery<SelectAll<Group>, EquatableList<Group>> _groupQuery;

        /// <summary>
        ///     Create a new <see cref="GetGroupHandler" />.
        /// </summary>
        public GetGroupsHandler(IQuery<SelectAll<Group>, EquatableList<Group>> groupsQuery) => _groupQuery = groupsQuery;

        /// <inheritdoc />
        public async Task<GetGroupsResponse?> Handle(GetGroupsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var groups = await _groupQuery.Query(new(), cancellationToken);
            if (groups?.Any() == true)
                return new()
                {
                    Groups = groups
                };

            return null;
        }
    }
}