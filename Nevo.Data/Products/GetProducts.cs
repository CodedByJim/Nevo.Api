namespace Nevo.Data.Products
{
    /// <summary>
    ///     Get products query arguments.
    /// </summary>
    public sealed record GetProducts : BasePaginatedQueryArguments<Product>
    {
    }
}