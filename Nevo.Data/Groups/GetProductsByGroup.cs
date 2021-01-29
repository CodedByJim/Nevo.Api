namespace Nevo.Data.Groups
{
    /// <summary>
    ///     Get products by group query arguments.
    /// </summary>
    public sealed record GetProductsByGroup : BasePaginatedQueryArguments<GroupProduct>
    {
        /// <summary>
        ///     The group code.
        /// </summary>
        public int GroupCode { get; init; }
    }
}