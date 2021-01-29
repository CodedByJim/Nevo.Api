using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Handler;
using Microsoft.AspNetCore.Mvc;
using Nevo.Contract.V1.Groups;

namespace Nevo.Api.Controllers
{
    /// <summary>
    ///     Products are categorized into groups.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IHandler<GetGroupRequest, GetGroupResponse> _getGroupHandler;
        private readonly IHandler<GetGroupProductsRequest, GetGroupProductsResponse> _getGroupProductsHandler;
        private readonly IHandler<GetGroupsRequest, GetGroupsResponse> _getGroupsHandler;

        /// <summary>
        ///     Create a new <see cref="GroupsController" />.
        /// </summary>
        /// <param name="getGroupsHandler">Get groups request handler.</param>
        /// <param name="getGroupHandler">Get group request handler.</param>
        /// <param name="getGroupProductsHandler">Get group products request handler</param>
        public GroupsController(
            IHandler<GetGroupsRequest, GetGroupsResponse> getGroupsHandler,
            IHandler<GetGroupRequest, GetGroupResponse> getGroupHandler,
            IHandler<GetGroupProductsRequest, GetGroupProductsResponse> getGroupProductsHandler)
        {
            _getGroupsHandler = getGroupsHandler;
            _getGroupHandler = getGroupHandler;
            _getGroupProductsHandler = getGroupProductsHandler;
        }

        /// <summary>
        ///     List all groups.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All groups.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<ActionResult<GetGroupsResponse>> GetGroups(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _getGroupsHandler.Handle(new(), cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        ///     Get a single group.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The group.</returns>
        [HttpGet("{code}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<ActionResult<GetGroupResponse>> GetGroup([FromQuery] GetGroupRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _getGroupHandler.Handle(request, cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        ///     Gets the products within a group.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The products within the group.</returns>
        [HttpGet("{code}/products")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<ActionResult<GetGroupProductsResponse>> GetGroupProducts([FromQuery] GetGroupProductsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _getGroupProductsHandler.Handle(request, cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}