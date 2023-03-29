using System.Data;

namespace Xpto.Core.Customers;

public interface ICustomerService
{
    Customer Create(Customer customer);
    Customer Update(Customer customer);
    void Delete(int code);
    Customer Get(int code);
    IList<Customer> List();
    DataTable LoadDataTable();
}