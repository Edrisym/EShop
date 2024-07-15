using System.Threading.RateLimiting;
using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;
using Catalog.API.Data;
using Catalog.Api.Models;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
    // config.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(assembly);
builder.Services.AddCarter();
builder.Services.AddMarten(options =>
{
    options.Connection(builder.Configuration.GetConnectionString("DefaultConnection")!);
}).UseLightweightSessions();

if (builder.Environment.IsDevelopment())
{
    builder.Services.InitializeMartenWith<CatalogInitialData>();
}

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("DefaultConnection")!);

var fixedPolicy = "fixed";
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.AddPolicy(fixedPolicy, httpContext =>
        RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(),
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 10,
                Window = TimeSpan.FromSeconds(10)
            }));
});

// var myOptions = new MyRateLimitOptions();
// builder.Configuration.GetSection(MyRateLimitOptions.MyRateLimit).Bind(myOptions);
// var slidingPolicy = "sliding";
//
// builder.Services.AddRateLimiter(opt =>
// {
//     opt.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
//     opt.AddSlidingWindowLimiter(policyName: slidingPolicy, options =>
//     {
//         options.PermitLimit = myOptions.PermitLimit;
//         options.Window = TimeSpan.FromSeconds(myOptions.Window);
//         options.SegmentsPerWindow = myOptions.SegmentsPerWindow;
//         options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//         options.QueueLimit = myOptions.QueueLimit;
//     });
// });


// builder.Services.AddRateLimiter(opt => {
//     opt.RejectionStatusCode = 429;
//     opt.AddSlidingWindowLimiter(policyName: "sliding", options => {
//         options.PermitLimit = 30;
//         options.Window = TimeSpan.FromSeconds(60);
//         options.SegmentsPerWindow = 2;
//         options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
//         options.QueueLimit = 2;
//     });
// });

var app = builder.Build();

app.UseRateLimiter();

// static string GetTicks() => (DateTime.Now.Ticks & 0x11111).ToString("00000");
//
// app.MapGet("/", () => Results.Ok($"Sliding Window Limiter {GetTicks()}"))
//     .RequireRateLimiting("sliding");


app.MapCarter();
app.UseHealthChecks("/healthCheck",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
app.UseExceptionHandler(opt => { });
app.Run();