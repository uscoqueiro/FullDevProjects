using Xpto.Core.Shared.Entities;
using Xpto.Core.Shared.Params;
using Xpto.Core.Shared.Results;

namespace Xpto.Core.Customers
{
    public partial class Customer
    {
        public static Customer Create(CustomerCreateParams createParams, IResultService resultService)
        {
            resultService.ClearMessages();

            if (createParams == null)
            {
                resultService.Messages.Add("Parâmentro inválido");
                return null;
            }

            var customer = new Customer();

            customer.Name = createParams.Name;
            customer.Nickname = createParams.Nickname;
            customer.BirthDate = createParams.BirthDate;
            customer.PersonType = createParams.PersonType;
            customer.Identity = createParams.Identity;

            customer.Addresses = new List<Address>();
            createParams.Addresses ??= new List<AddressParams>();
            foreach (var item in createParams.Addresses)
            {
                customer.Addresses.Add(new Address(item));
            }

            customer.Phones = createParams.Phones;
            customer.Emails = createParams.Emails;
            customer.Note = createParams.Note;

            if (!customer.Validate(resultService))
                return null;

            return customer;
        }
    }
}