using BuildingBlocks.Core.Interfaces;
using BuildingBlocks.Core.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddDefaultGuidProvider(this IServiceCollection services)
    {
        services.AddScoped<IGuidProvider, DefaultGuidProvider>();
        return services;
    }

    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services
            .AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
        return services;
    }
}