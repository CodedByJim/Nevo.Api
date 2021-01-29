using Coded.Core.Data;

namespace Nevo.Data.Products
{
    /// <summary>
    ///     Get product query.
    /// </summary>
    public sealed class GetProductQuery : SingleQuery<SelectOne<Product, int>, Product>
    {
        private const string SQL = "SELECT products.*," +
                                   " groups.description_en group_description_en," +
                                   " groups.description_nl group_description_nl" +
                                   " FROM products" +
                                   " JOIN groups" +
                                   " ON groups.code = products.group_code" +
                                   " WHERE products.code = @Id";

        /// <summary>
        ///     Create a new <see cref="GetProductQuery" />.
        /// </summary>
        /// <param name="unitOfWork">The active unit of work.</param>
        public GetProductQuery(IUnitOfWork unitOfWork) : base(unitOfWork, SQL)
        {
        }
    }
}