using System.Data;

namespace Xpto.Core.Customers;

public interface ICustomerRepository
{
    Customer Insert(Customer customer);
    void Update(Customer customer);
    int Delete(Guid id);
    Customer Get(Guid id);
    Customer Get(int code);
    IList<Customer> Find();
    DataTable LoadDataTable();
    long Count();
}