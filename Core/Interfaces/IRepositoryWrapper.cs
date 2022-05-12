namespace Core.Interfaces
{
    public interface IRepositoryWrapper
    {
        ICustomerRepository Customer { get; }
        IPurchaseRepository Puchase { get; }
        void Save();
    }
}
