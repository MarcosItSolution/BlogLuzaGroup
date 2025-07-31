using System;
namespace Blog.External.Presentations.Api.Middlewares.Hosting
{
	public static class HostingExtension
	{
        public static IHostBuilder AddConfiguration(this IHostBuilder host)
        {
            string? environment = Environment
                .GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            host.ConfigureAppConfiguration((context, builder) =>
            {
                builder.AddJsonFile(
                    path: "appsettings.json",
                    optional: false,
                    reloadOnChange: true);

                builder.AddJsonFile(
                    path: $"appsettings.{environment}.json",
                    optional: true,
                    reloadOnChange: true);

                builder.AddEnvironmentVariables();
            });

            return host;
        }
    }
}

