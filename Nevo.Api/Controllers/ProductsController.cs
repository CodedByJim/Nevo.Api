using System.Threading;
using System.Threading.Tasks;
using Coded.Core.Handler;
using Microsoft.AspNetCore.Mvc;
using Nevo.Contract.V1.Products;

namespace Nevo.Api.Controllers
{
    /// <summary>
    ///     Data about products.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IHandler<GetProductRequest, GetProductResponse> _getProductHandler;
        private readonly IHandler<GetProductNutrientsRequest, GetProductNutrientsResponse> _getProductNutrientHandler;
        private readonly IHandler<GetProductsRequest, GetProductsResponse> _getProductsHandler;

        /// <summary>
        ///     Create a new <see cref="ProductsController" />.
        /// </summary>
        /// <param name="getProductsHandler">The get products request handler.</param>
        /// <param name="getProductHandler">The get product request handler.</param>
        /// <param name="getProductNutrientHandler">The get product nutrient handler.</param>
        public ProductsController(
            IHandler<GetProductsRequest, GetProductsResponse> getProductsHandler,
            IHandler<GetProductRequest, GetProductResponse> getProductHandler,
            IHandler<GetProductNutrientsRequest, GetProductNutrientsResponse> getProductNutrientHandler)
        {
            _getProductsHandler = getProductsHandler;
            _getProductHandler = getProductHandler;
            _getProductNutrientHandler = getProductNutrientHandler;
        }

        /// <summary>
        ///     Get all products.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>List of products.</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        [HttpGet]
        public async Task<ActionResult<GetProductsResponse>> GetProducts([FromQuery] GetProductsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _getProductsHandler.Handle(request, cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        ///     Get a single product.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The product.</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        [HttpGet("{code}")]
        public async Task<ActionResult<GetProductResponse>> GetProduct([FromQuery] GetProductRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _getProductHandler.Handle(request, cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        /// <summary>
        ///     Get the product and it's nutrients.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The product and it's nutrients.</returns>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ProblemDetails), 500)]
        [ProducesErrorResponseType(typeof(ProblemDetails))]
        [HttpGet("{code}/nutrients")]
        public async Task<ActionResult<GetProductNutrientsResponse>> GetProductNutrients([FromQuery] GetProductNutrientsRequest request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var response = await _getProductNutrientHandler.Handle(request, cancellationToken);
            if (response == null)
                return NotFound();
            return Ok(response);
        }
    }
}