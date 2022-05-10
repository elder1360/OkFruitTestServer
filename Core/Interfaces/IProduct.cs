using Core.Entities;

namespace Core.Interfaces
{
    public interface IProduct:IEntityBase
    {
        string Name { get; set; }
        double Price { get; set; }
        UnitType? UnitType { get; set; }
        int UnitTypeId { get; set; }
    }
}