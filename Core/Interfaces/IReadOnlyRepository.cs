namespace Core.Interfaces
{
    public interface IReadOnlyRepository<T> where T : IEntityBase
    {
        T GetAll();
        T GetById();
    }

}
