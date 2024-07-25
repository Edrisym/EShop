using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        return services;
    }
}