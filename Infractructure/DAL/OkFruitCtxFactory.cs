using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infractructure.DAL
{
    public class OkFruitCtxFactory : IDesignTimeDbContextFactory<OkFruitCtx>
    {
        private readonly IConfiguration _config;
        public OkFruitCtxFactory(IConfiguration config) => _config = config;
        public OkFruitCtx CreateDbContext(string[] args)
{
            var builder = new DbContextOptionsBuilder<OkFruitCtx>();
            builder.UseSqlServer(_config.GetConnectionString("OkFruitDb")).EnableSensitiveDataLogging();
            
            return new OkFruitCtx(builder.Options);
        }
    }
}
