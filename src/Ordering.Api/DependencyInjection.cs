namespace Ordering.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        // services.AddCarter();
        return services;
    }

    public static WebApplication UsePresentationLayer(this WebApplication app)
    {
        // app.UseCarter();
        return app;
    } 
}