
using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureLayer(builder.Configuration)
    .AddPresentationLayer();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

app.UsePresentationLayer();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.Run();