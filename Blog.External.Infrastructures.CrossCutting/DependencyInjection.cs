using Blog.External.Infrastructures.Persistences.Abstractions;
using Blog.Internal.Applications.Core.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.External.Infrastructures.CrossCutting;

public static class DependencyInjection
{
    public static IServiceCollection AddDependency(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplications();
        services.AddPersistences(configuration);

        return services;
    }

}