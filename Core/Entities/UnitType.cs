using Core.Interfaces;

namespace Core.Entities
{
    public class UnitType : EntityBase, IUnitType
    {
        public string Name { get; set; }
    }
}
