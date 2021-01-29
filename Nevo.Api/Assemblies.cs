using System.Reflection;
using Coded.Core.Handler;
using Nevo.Business;
using Nevo.Contract.V1.Nutrients;
using Nevo.Data.Nutrients;

namespace Nevo.Api
{
    /// <summary>
    ///     List of assemblies.
    /// </summary>
    public static class Assemblies
    {
        /// <summary>
        ///     The Api assembly.
        /// </summary>
        public static Assembly Api => typeof(Startup).Assembly;

        /// <summary>
        ///     The Core assembly.
        /// </summary>
        public static Assembly Core => typeof(IHandler<,>).Assembly;

        /// <summary>
        ///     The Business assembly.
        /// </summary>
        public static Assembly Business => typeof(EventLogger<>).Assembly;

        /// <summary>
        ///     The Data assembly.
        /// </summary>
        public static Assembly Data => typeof(GetNutrientsQuery).Assembly;

        /// <summary>
        ///     The Contract assembly.
        /// </summary>
        public static Assembly ContractV1 => typeof(GetNutrientsRequest).Assembly;

        /// <summary>
        ///     All assemblies.
        /// </summary>
        public static Assembly[] All => new[]
        {
            Api,
            Core,
            Business,
            Data,
            ContractV1
        };
    }
}