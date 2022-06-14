using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace WebClientMvc.Models;

public class CustomerRepository : ICustomerRepository
{
    private const string ApiUrl = "http://localhost:7267/api/customers";
    private readonly HttpClient _client;

    public CustomerRepository()
    {
        _client = new HttpClient();
    }

    public List<Customer>? GetAllCustomer()
    {
        var result = _client.GetStringAsync(ApiUrl).Result;

        var list = JsonConvert
            .DeserializeObject<List<Customer>>(result);

        return list;
    }

    public Customer? GetCustomerById(int customerId)
    {
        var result = _client
            .GetStringAsync(ApiUrl + "/" + customerId).Result;

        var customer = JsonConvert.DeserializeObject<Customer>(result);

        return customer;
    }

    public void AddCustomer(Customer customer)
    {
        var jsonCustomer = JsonConvert.SerializeObject(customer);

        var content = new StringContent(
            jsonCustomer,
            Encoding.UTF8, "application/json");

        var res = _client.PostAsync(ApiUrl, content).Result;
    }

    public void UpdateCustomer(Customer customer)
    {
        var jsonCustomer = JsonConvert.SerializeObject(customer);

        var content = new StringContent(
            jsonCustomer,
            Encoding.UTF8, "application/json");

        var res = _client
            .PutAsync(ApiUrl + "/" + customer.Id, content).Result;
    }

    public void DeleteCustomer(int customerId)
    {
        var res = _client
            .DeleteAsync(ApiUrl + "/" + customerId).Result;
    }
}