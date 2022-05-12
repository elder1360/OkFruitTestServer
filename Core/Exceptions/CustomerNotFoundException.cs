namespace Core.Exceptions
{
    public class CustomerNotFoundException : NotFoundException
    {
        public CustomerNotFoundException(int customerId) : base($"Customer with Id {customerId} Not Found!")
        {
        }
    }
}
