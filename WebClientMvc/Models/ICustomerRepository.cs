namespace WebClientMvc.Models
{
    public interface ICustomerRepository
    {
        List<Customer>? GetAllCustomer();
        Customer? GetCustomerById(int customerId);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
    }
}
