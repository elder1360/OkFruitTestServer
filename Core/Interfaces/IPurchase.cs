using Core.Entities;

namespace Core.Interfaces
{
    public interface IPurchase:IEntityBase
    {
        Customer Customer { get; set; }
        int CustomerId { get; set; }
        Product Product { get; set; }
        int ProductId { get; set; }
        int Quantity { get; set; }
    }
}