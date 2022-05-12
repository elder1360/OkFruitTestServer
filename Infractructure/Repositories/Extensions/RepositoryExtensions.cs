using Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infractructure.Repositories.Extensions
{
    public static class RepositoryExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}