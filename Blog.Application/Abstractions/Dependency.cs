using Blog.Intenal.Domains.Core.Results;
using Blog.Internal.Applications.Commands.Users;
using Blog.Internal.Applications.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Internal.Applications.Core.Abstractions
{
    public static class Dependency
    {
        public static IServiceCollection AddApplications(
            this IServiceCollection services)
        {
            services.Scan(scan => scan
            .FromAssembliesOf(typeof(IQueryHandler<,>),
                              typeof(ICommandHandler<,>),
                              typeof(ICommandHandler<>))
            .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            services.AddScoped<Dispatcher>();
            services.AddScoped<WebSocketHandler>();
            services.AddScoped<ICommandHandler<RegisterUserCommand, CustomResult>, RegisterUserCommand.RegisterUserCommandHandler>();


            return services;
        }
    }
}

