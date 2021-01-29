using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Nevo.Api;

Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
    .ConfigureAppConfiguration((context, builder) =>
    {
        if (context.HostingEnvironment.IsDevelopment())
            builder.AddUserSecrets<Startup>();
    })
    .Build()
    .Run();