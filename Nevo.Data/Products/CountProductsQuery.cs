using Coded.Core.Data;

namespace Nevo.Data.Products
{
    /// <summary>
    ///     Query that counts all products.
    /// </summary>
    public sealed class CountProductsQuery : SingleQuery<Count<Product>, Primitive<int>>
    {
        private const string SQL = "SELECT COUNT(*) Value FROM products";

        /// <summary>
        ///     Create a new count products query.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public CountProductsQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}