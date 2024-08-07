using BuildingBlocks.Exceptions.Handler;
using Carter;

namespace Ordering.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        services.AddCarter();
        services.AddExceptionHandler<CustomExceptionHandler>();
        return services;
    }

    public static WebApplication UsePresentationLayer(this WebApplication app)
    {
        app.MapCarter();
        app.UseExceptionHandler();
        return app;
    } 
}