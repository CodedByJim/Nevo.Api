using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nevo.Api
{
    /// <summary>
    ///     Used to configure swagger options.
    /// </summary>
    public class SwaggerConfigureOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        /// <summary>
        ///     Create a new Swagger configure options.
        /// </summary>
        /// <param name="provider">The api version description provider.</param>
        public SwaggerConfigureOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

        /// <summary>
        ///     Configure swagger.
        /// </summary>
        /// <param name="options">The options.</param>
        public void Configure(SwaggerGenOptions options)
        {
            var controllerDocumentation = Path.Combine(AppContext.BaseDirectory, $"{Assemblies.Api.GetName().Name}.xml");
            var contractDocumentation = Path.Combine(AppContext.BaseDirectory, $"{Assemblies.ContractV1.GetName().Name}.xml");
            var dataDocumentation = Path.Combine(AppContext.BaseDirectory, $"{Assemblies.Data.GetName().Name}.xml");

            options.IncludeXmlComments(controllerDocumentation, true);
            options.IncludeXmlComments(contractDocumentation, true);
            options.IncludeXmlComments(dataDocumentation, true);

            foreach (var description in _provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName,
                    new()
                    {
                        Title = "NEVO Dutch Food Composition Database",
                        Description = "The Dutch Food Composition Database (NEVO) " +
                                      "contains data on the composition of foods. " +
                                      "NEVO is owned by the Dutch Ministry of Health, " +
                                      "Welfare and Sports, and is maintained at the " +
                                      "Dutch National Institute for Public Health and " +
                                      "the Environment (RIVM National Institute for " +
                                      "Public Health and the Environment  ). An advisory " +
                                      "board with scientific experts, data providers and " +
                                      "users of NEVO data advises. " +
                                      "RIVM.NEVO online version 2019/6.0, RIVM, Bilthoven.",
                        TermsOfService = new("https://www.rivm.nl/en/dutch-food-composition-database/access-nevo-data/nevo-online/copyright-and-disclaimer"),
                        Contact = new()
                        {
                            Email = "hello@codedbyjim.nl",
                            Name = "CODED by Jim",
                            Url = new("https://codedbyjim.nl")
                        },
                        License = new()
                        {
                            Name = "Copyright and disclaimer.",
                            Url = new("https://www.rivm.nl/en/dutch-food-composition-database/access-nevo-data/nevo-online/copyright-and-disclaimer")
                        },
                        Version = description.ApiVersion.ToString()
                    });
        }
    }
}