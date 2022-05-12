using Core.Exceptions;
using Core.Interfaces;
using Infractructure.DAL;
using Infractructure.Repositories.Extensions;
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
builder.Services.AddDbContext(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();
var app = builder.Build();

app.UseHttpsRedirection();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.ConfigureExceptionMiddleware(app.Logger);
}



app.UseCors(policy => policy.AllowAnyOrigin());

app.MapGet("/Customers", (IRepositoryWrapper repo) =>
{
    return repo.Customer.GetAll();
});

app.MapGet("/Purchase", (int? customerId, IRepositoryWrapper repo) =>
{
    if (customerId is null) throw new BadRequestException("Customer Id cannot be null");
    var customer = repo.Customer.GetByCondition(c => c.Id == customerId).ToList();
    if (customer is null || !customer.Any())
    {
        throw new CustomerNotFoundException(customerId.Value);
    }

    var result = repo.Puchase.GetByCondition(c => c.CustomerId == customerId).Include(c=>c.Product).Include(c=>c.Product.UnitType);
    return result;
});

await ApplyMigrations(app.Services);
app.Run();

static async Task ApplyMigrations(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();

    await using OkFruitCtx ctx = scope.ServiceProvider.GetRequiredService<OkFruitCtx>();

    await ctx.Database.MigrateAsync();
}
