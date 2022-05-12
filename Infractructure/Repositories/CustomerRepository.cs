using Core.Entities;
using Core.Interfaces;
using Infractructure.DAL;
using Infrastructure.Repositories;

namespace Infractructure.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer> , ICustomerRepository
    {
        public CustomerRepository(OkFruitCtx ctx) : base(ctx)
        {

        }
    }
}
