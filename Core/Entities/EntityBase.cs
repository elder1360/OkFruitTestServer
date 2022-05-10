using Core.Interfaces;

namespace Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public int Id { get; set; }
    }
}
