using Coded.Core.Data;

namespace Nevo.Data.Products
{
    /// <summary>
    ///     Get products query.
    /// </summary>
    public sealed class GetProductsQuery : ListQuery<GetProducts, Product>
    {
        private const string SQL = "SELECT * FROM products " +
                                   "LIMIT @Rows offset @Offset ";

        /// <summary>
        ///     Create a new <see cref="GetProductsQuery" />.
        /// </summary>
        /// <param name="unitOfWork">The active unit of work.</param>
        public GetProductsQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}