var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddDbContext<DiscountContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")!);
});

var app = builder.Build();

app.UseMigration();
app.MapGrpcService<DiscountService>();

app.Run();