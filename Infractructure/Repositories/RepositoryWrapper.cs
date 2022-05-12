using Core.Interfaces;
using Infractructure.DAL;

namespace Infractructure.Repositories
{
    public class RepositoryWrapper:IRepositoryWrapper
    {
        private readonly PurchaseRepository? _purchase;
        private readonly CustomerRepository? _customer;
        private readonly OkFruitCtx _ctx;

        public RepositoryWrapper(OkFruitCtx ctx) => _ctx = ctx;
        public ICustomerRepository Customer => _customer is null ? new CustomerRepository(_ctx) : _customer;
 
        public IPurchaseRepository Puchase => _purchase is null ? new PurchaseRepository(_ctx) : _purchase;

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
