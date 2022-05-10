using Core.Entities;
using Infractructure.DAL;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddDbContext();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();


app.UseCors(policy => policy.AllowAnyOrigin());

using var scope = app.Services.CreateScope();
var ctx = scope.ServiceProvider.GetRequiredService<OkFruitCtx>();
app.MapGet("/Customers", () =>
{
    return ctx.Customers.ToArray();
});

app.MapGet("/Purchase", (int? customerId) =>
{
    var result = ctx.Purchases.Include(p=>p.Product).Where(c => c.Id == customerId);
    return result;
});


app.Run();