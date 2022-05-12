using Core.Exceptions;
using Infractructure.DAL;
using Microsoft.EntityFrameworkCore;
using OkFruitTestServer.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddCommandLine(args);
builder.Logging.AddConsole().AddSimpleConsole(config =>
{
    config.SingleLine = true;
    config.UseUtcTimestamp = true;
});


builder.Services.AddCors();
builder.Services.AddDbContext();
var app = builder.Build();

app.UseHttpsRedirection();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.ConfigureExceptionMiddleware();
}



app.UseCors(policy => policy.AllowAnyOrigin());

app.MapGet("/Customers", (OkFruitCtx ctx) =>
{
    return ctx.Customers;
});

app.MapGet("/Purchase", (int? customerId, OkFruitCtx ctx) =>
{
    if (customerId is null) throw new BadRequestException("Customer Id cannot be null");
    var customer = ctx.Customers?.Where(c => c.Id == customerId).ToList();
    if (customer is null || !customer.Any())
    {
        throw new CustomerNotFoundException(customerId.Value);
    }

    var result = ctx.Purchases?.Include(p => p.Product).Include(p => p.Product.UnitType).Where(c => c.CustomerId == customerId);
    return result;
});

app.MapGet("/exception", () =>
{
    throw new Exception();
});

await ApplyMigrations(app.Services);
app.Run();

static async Task ApplyMigrations(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();

    await using OkFruitCtx ctx = scope.ServiceProvider.GetRequiredService<OkFruitCtx>();

    await ctx.Database.MigrateAsync();
}
