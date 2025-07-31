using System.Reflection;
using Blog.External.Infrastructure.Persistences.Contexts;
using Blog.Intenal.Domains.Core.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.External.Infrastructures.Persistences.Abstractions
{
    public static class Dependency
	{
        public static IServiceCollection AddPersistences(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.Scan(scan => scan
            .FromAssemblies(Assembly.GetExecutingAssembly())
            .AddClasses(c => c.AssignableTo(typeof(IBaseRepository<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(c => c.AssignableTo(typeof(IUnitOfWork)))
                .AsImplementedInterfaces()
            .WithScopedLifetime()
            );

            var npgConnection = configuration
               .GetConnectionString("PostgreConnection");

            services.AddDbContext<MainContext>(
            options => options.UseNpgsql(npgConnection));

            return services;
        }
    }
}

