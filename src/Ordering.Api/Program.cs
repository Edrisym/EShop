using Ordering.Api;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services
    .AddApplicationLayer()
    .AddInfrastructureLayer(builder.Configuration)
    .AddPresentationLayer();

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// app.UseSwagger();
// app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
// public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }