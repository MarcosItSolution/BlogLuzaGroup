using Microsoft.AspNetCore.Mvc;

namespace Blog.External.Presentations.Api.Middlewares.Versioning
{
    public static class ApiVersioningExtensions
    {
        public static IServiceCollection AddApiVersioningConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true; // Permite que os clientes da API vejam todas as versões disponiveis
               /* options.ApiVersionReader = ApiVersionReader.Combine // recebe a versão pelo header ou URI
                (
                    new QueryStringApiVersionReader("api-version")
                    new HeaderApiVersionReader("api-version")
                );*/
            });

            services.AddVersionedApiExplorer(options => {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
    }
}
