
using Core.Interfaces;

namespace Core.Entities
{
    public class Customer : EntityBase, ICustomer
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
    }
}
