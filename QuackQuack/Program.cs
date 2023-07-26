using Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;

var MyCorsOrigins = "MyCorsOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors((options) =>
{
    options.AddPolicy(MyCorsOrigins, policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("localhost:3000");
    });
});

builder.Services.AddDbContextPool<DictionaryDbContext>(config =>
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

if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(MyCorsOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
