using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Nevo.Api
{
    /// <summary>
    ///     Routines used at startup.
    /// </summary>
    public class Startup
    {
        private readonly Container _container;

        /// <summary>
        ///     Startup the application.
        /// </summary>
        public Startup()
        {
            _container = new();
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        }

        /// <summary>
        ///     Configure the services.
        /// </summary>
        /// <param name="services">The current service collection.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .WithMethods("GET", "HEAD", "POST", "PUT", "DELETE", "OPTIONS")
                        .AllowAnyHeader()
                        ;
                });
            });
            services.AddMemoryCache();
            services.AddResponseCaching();
            services.AddResponseCompression();

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new(1, 0);
                options.ApiVersionReader =
                    new UrlSegmentApiVersionReader();
            });

            services.AddVersionedApiExplorer(options => options.SubstituteApiVersionInUrl = true);
            services.AddLocalization();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfigureOptions>();
            services.AddSwaggerGen();

            services.AddSimpleInjector(_container, options =>
            {
                options
                    .AddLogging()
                    .AddLocalization()
                    .AddAspNetCore()
                    .AddControllerActivation();
            });
        }

        /// <summary>
        ///     Configure the application.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">Environment.</param>
        /// <param name="apiVersionDescriptionProvider">The api version description provider.</param>
        /// <param name="configuration">The current configuration.</param>
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IApiVersionDescriptionProvider apiVersionDescriptionProvider,
            IConfiguration configuration)
        {
            app.UseCors();
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRequestLocalization();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var orderedDescriptions =
                    apiVersionDescriptionProvider
                        .ApiVersionDescriptions
                        .OrderByDescending(versionDescription => versionDescription.ApiVersion)
                        .ToArray();

                foreach (var description in orderedDescriptions)
                    options.SwaggerEndpoint($"{description.GroupName}/swagger.yaml",
                        description.GroupName.ToLowerInvariant());
            });

            app.UseSimpleInjector(_container);
            Bootstrapper.Bootstrap(_container, configuration);
            _container.Verify();
        }
    }
}