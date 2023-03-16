using Xpto.Core.Customers;

namespace Xpto.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
 
        public Customer Create(Customer customer)
        {
            _repository.Insert(customer);
            return customer;
        }

        public Customer Update(Customer customer)
        {
            _repository.Update(customer);
            return customer;
        }

        public void Delete(int code)
        {
            var customer = _repository.Get(code);

            if (customer != null)
            {
                _repository.Delete(customer.Id);
            }
        }

        public Customer Get(int code)
        {
            var customer = _repository.Get(code);
            return customer;
        }

        public IList<Customer> List()
        {
            var list = _repository.Find();
            return list;
        }
    }
}
