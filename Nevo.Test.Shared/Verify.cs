using System.Diagnostics.CodeAnalysis;
using Xunit.Sdk;

namespace Nevo.Test.Shared
{
    public static class Verify
    {
        /// <summary>Verifies that an object reference is not null.</summary>
        /// <param name="object">The object to be validated.</param>
        /// <exception cref="T:Xunit.Sdk.NotNullException">Thrown when the object is not null.</exception>
        // ReSharper disable once ParameterOnlyUsedForPreconditionCheck.Global
        public static void NotNull([NotNull] object? @object)
        {
            if (@object == null)
                throw new NotNullException();
        }
    }
}