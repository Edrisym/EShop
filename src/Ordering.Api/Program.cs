
var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureLayer(builder.Configuration)
    .AddPresentationLayer();

var app = builder.Build();

app.UsePresentationLayer();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.Run();