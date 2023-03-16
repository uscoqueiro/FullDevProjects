using Xpto.Core.Customers;

namespace Xpto.Services.Customers;

public interface ICustomerService
{
    Customer Create(Customer customer);
    Customer Update(Customer customer);
    void Delete(int code);
    Customer Get(int code);
    IList<Customer> List();
}