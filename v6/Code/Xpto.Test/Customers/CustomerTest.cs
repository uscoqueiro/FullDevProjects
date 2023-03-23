using Xpto.Core.Customers;

namespace Xpto.Test.Customers
{
    [TestClass]
    public class CustomerTest: Dependency
    {
        [TestMethod]
        public void Create()
        {
            var customer = new Customer
            {
                Name = "João da Silva",
                Nickname = "Jaum",
                BirthDate = new DateTime(1985, 08, 19),
                PersonType = "PF",
                Identity = "123456789",
                Note = "Xpto"
            };
 
            var result = customerService.Create(customer);
        }


        [TestMethod]
        public void Update()
        {
            var customer = new Customer
            {
                Code = 22,
                Name = "João da Silva 2",
                Nickname = "Jaum",
                BirthDate = new DateTime(1985, 08, 19),
                PersonType = "PF",
                Identity = "123456789",
                Note = "Xpto"
            };

            var result = customerService.Update(customer);
        }


        [TestMethod]
        public void Get()
        {
            var result = customerService.Get(22);
        }


        [TestMethod]
        public void List()
        {
            var list = customerService.List();
        }

    }
}