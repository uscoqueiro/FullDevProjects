using System.Text;
using Xpto.Core.Shared.Entities;

namespace Xpto.Repositories.Customers;

public interface ICustomerAddressRepository
{
    Address Insert(int customerCode, Address address);
    void Update(int customerCode, Address address);
    int Delete(Guid id);
    int DeleteByCustomer(int customerCode);
    Address Get(Guid id);
    IList<Address> FindByCustomer(int customerCode);
    StringBuilder GetSelectQuery();
}