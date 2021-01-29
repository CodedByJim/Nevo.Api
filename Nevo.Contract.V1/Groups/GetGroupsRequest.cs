using Coded.Core.Handler;

namespace Nevo.Contract.V1.Groups
{
    /// <summary>
    ///     List all groups.
    /// </summary>
    public sealed record GetGroupsRequest : IRequest<GetGroupsResponse>
    {
    }
}