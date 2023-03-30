using System.Data;
using Xpto.Core.Shared.Results;

namespace Xpto.Core.Customers;

public interface ICustomerService: IResultService
{
    Customer Create(CustomerCreateParams createParams);
    Customer Update(Guid id, CustomerUpdateParams updateParams);
    void Delete(Guid id);
    Customer Get(Guid id);
    IList<Customer> List();
    DataTable LoadDataTable();
}