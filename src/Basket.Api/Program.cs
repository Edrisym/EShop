
using BuildingBlocks.Behaviors;
using BuildingBlocks.Behaviour;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
    {
        config.RegisterServicesFromAssemblies(assembly);
        config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        config.AddOpenBehavior(typeof(LoggingBehavior<,>));
    }
);
builder.Services.AddCarter();

var app = builder.Build();

app.MapCarter();
app.Run();