using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infractructure.DAL
{
    public static class StartUpSetup
    {
        public static void AddDbContext(this IServiceCollection services,IConfiguration config) =>
      services.AddDbContext<OkFruitCtx>(options =>
          options.UseSqlServer(config.GetConnectionString("OkFruitDb")));
    }
}
