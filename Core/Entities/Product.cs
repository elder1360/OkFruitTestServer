using Core.Interfaces;

namespace Core.Entities
{
    public class Product : EntityBase, IProduct
    {
        public string Name { get; set; }
        public int UnitTypeId { get; set; }
        public virtual UnitType? UnitType { get; set; }
        public double Price { get; set; }
    }
}
