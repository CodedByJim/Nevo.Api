using Coded.Core.Handler;

namespace Nevo.Contract.V1.Nutrients
{
    /// <summary>
    ///     List all nutrients.
    /// </summary>
    public sealed record GetNutrientsRequest : IRequest<GetNutrientsResponse>
    {
    }
}