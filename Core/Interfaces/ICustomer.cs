
namespace Core.Interfaces
{
    public interface ICustomer:IEntityBase
    {
        string? Name { get; set; }
        string? LastName { get; set; }
    }
}
