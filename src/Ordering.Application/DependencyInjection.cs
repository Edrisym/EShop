using System.Reflection;
using BuildingBlocks.Behaviors;
using BuildingBlocks.Behaviour;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            opt.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            opt.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
        return services;
    }
}