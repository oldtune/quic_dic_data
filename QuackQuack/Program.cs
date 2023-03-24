using Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContextPool<PorfolioDbContext>(config =>
{
    config.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    config.UseSqlServer(builder.Configuration.GetConnectionString("Porfolio"), dbOptions =>
    {
        dbOptions.CommandTimeout(30);
        dbOptions.EnableRetryOnFailure();
        dbOptions.MigrationsAssembly("Data");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
