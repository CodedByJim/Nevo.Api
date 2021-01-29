namespace Nevo.Contract.V1.Products
{
    /// <summary>
    ///     Get all products request.
    /// </summary>
    public sealed record GetProductsRequest : BasePaginatedRequest<GetProductsResponse>
    {
    }
}