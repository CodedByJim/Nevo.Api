using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Handler;
using Microsoft.AspNetCore.Mvc;
using Nevo.Contract.V1.Nutrients;

namespace Nevo.Api.Controllers
{
    /// <summary>
    ///     Information about the nutrients.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class NutrientsController : ControllerBase
    {
        private readonly IHandler<GetNutrientRequest, GetNutrientResponse> _getNutrientHandler;
        private readonly IHandler<GetNutrientProductsRequest, GetNutrientProductsResponse> _getNutrientProductsHandler;
        private readonly IHandler<GetNutrientsRequest, GetNutrientsResponse> _getNutrientsHandler;

        /// <summary>
        ///     Nutrient sources.
        /// </summary>
        /// <param name="getNutrientsHandler">Request handler for get nutrients.</param>
        /// <param name="getNutrientHandler">Request handler for get nutrient.</param>
        /// <param name="getNutrientProductsHandler">Request handler for get nutrient products.</param>
        public NutrientsController(
            IHandler<GetNutrientsRequest, GetNutrientsResponse> getNutrientsHandler,
            IHandler<GetNutrientRequest, GetNutrientResponse> getNutrientHandler,
            IHandler<GetNutrientProductsRequest, GetNutrientProductsResponse> getNutrientProductsHandler)
        {
            _getNutrientsHandler = getNutrientsHandler;
            _getNutrientHandler = getNutrientHandler;
            _getNutrientProductsHandler = getNutrientProductsHandler;
        }

        /// <summary>
        ///     Get all known nutrients.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>All known nutrients.</returns>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        public async Task<ActionResult<GetNutrientsResponse>> GetNutrients(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _getNutrientsHandler.Handle(new(), cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        ///     Get a single nutrient.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A single nutrient.</returns>
        [HttpGet("{code}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<ActionResult<GetNutrientResponse>> GetNutrient([FromQuery] GetNutrientRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var nutrient = await _getNutrientHandler.Handle(request, cancellationToken);
            if (nutrient == null)
                return NotFound();
            return Ok(nutrient);
        }

        /// <summary>
        ///     List products containing a nutrient, ordered by percentage descending.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A single nutrient.</returns>
        [HttpGet("{code}/products")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        public async Task<ActionResult<GetNutrientProductsResponse>> GetNutrientProducts([FromQuery] GetNutrientProductsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _getNutrientProductsHandler.Handle(request, cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}