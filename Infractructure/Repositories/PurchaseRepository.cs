using Core.Entities;
using Core.Interfaces;
using Infractructure.DAL;
using Infrastructure.Repositories;

namespace Infractructure.Repositories
{
    public class PurchaseRepository : RepositoryBase<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(OkFruitCtx ctx) : base(ctx)
        {

        }
    }
}
