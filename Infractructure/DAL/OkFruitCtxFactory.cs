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
        public OkFruitCtx CreateDbContext(string[] args)
{
            var builder = new DbContextOptionsBuilder<OkFruitCtx>();
            builder.UseSqlServer("Data Source=.;Initial Catalog=OkFruitDb;Integrated Security=true;").EnableSensitiveDataLogging();
            
            return new OkFruitCtx(builder.Options);
        }
    }
}
