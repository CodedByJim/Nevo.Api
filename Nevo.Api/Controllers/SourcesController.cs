using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Handler;
using Microsoft.AspNetCore.Mvc;
using Nevo.Contract.V1.Sources;

namespace Nevo.Api.Controllers
{
    /// <summary>
    ///     References to sources used to produce the data.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class SourcesController : ControllerBase
    {
        private readonly IHandler<GetSourceRequest, GetSourceResponse> _getSourceHandler;
        private readonly IHandler<GetSourceNutrientsRequest, GetSourceNutrientsResponse> _getSourceNutrientsHandler;
        private readonly IHandler<GetSourcesRequest, GetSourcesResponse> _getSourcesHandler;

        /// <summary>
        ///     Create a new sources controller.
        /// </summary>
        /// <param name="getSourceHandler">The handler used to handle <see cref="GetSourceRequest" />.</param>
        /// <param name="getSourcesHandler">The handler used to handle ><see cref="GetSourcesRequest" />.</param>
        /// <param name="getSourceNutrientsHandler">The handler used to handle <see cref="GetSourceNutrientsRequest" />.</param>
        public SourcesController(IHandler<GetSourceRequest, GetSourceResponse> getSourceHandler, IHandler<GetSourcesRequest, GetSourcesResponse> getSourcesHandler,
            IHandler<GetSourceNutrientsRequest, GetSourceNutrientsResponse> getSourceNutrientsHandler)
        {
            _getSourceHandler = getSourceHandler;
            _getSourcesHandler = getSourcesHandler;
            _getSourceNutrientsHandler = getSourceNutrientsHandler;
        }

        /// <summary>
        ///     Get all known sources.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All known sources.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<ActionResult<GetSourcesResponse>> GetSources([FromQuery] GetSourcesRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _getSourcesHandler.Handle(request, cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        ///     Get a single source.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The source.</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSourceResponse>> GetSource([FromQuery] GetSourceRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _getSourceHandler.Handle(request, cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        ///     Get the nutritional values found in the source.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The source.</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        [HttpGet("{id}/nutrients")]
        public async Task<ActionResult<GetSourceNutrientsResponse>> GetSourceNutrients([FromQuery] GetSourceNutrientsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _getSourceNutrientsHandler.Handle(request, cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}