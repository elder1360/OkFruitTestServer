using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infractructure.DAL
{
    public static class StartUpSetup
    {
        public static void AddDbContext(this IServiceCollection services) =>
      services.AddDbContext<OkFruitCtx>(options =>
          options.UseSqlServer("Data Source=.;Initial Catalog=OkFruitDb;Integrated Security=true;"));
    }
}
