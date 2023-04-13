using Xpto.Core.Shared.Entities;
using Xpto.Core.Shared.Params;
using Xpto.Core.Shared.Results;

namespace Xpto.Core.Customers
{
    public static class CustomerUpdate
    {
        public static Customer Update(this Customer customer, CustomerUpdateParams updateParams, IResultService resultService)
        {
            if (updateParams == null)
            {
                resultService.Messages.Add("Parâmentro inválido");
                return null;
            }

            customer.Name = updateParams.Name;
            customer.Nickname = updateParams.Nickname;
            customer.BirthDate = updateParams.BirthDate;
            customer.PersonType = updateParams.PersonType;
            customer.Identity = updateParams.Identity;

            customer.Addresses = new List<Address>();
            updateParams.Addresses ??= new List<AddressParams>();
            foreach (var item in updateParams.Addresses)
            {
                customer.Addresses.Add(new Address(item));
            }

            customer.Phones = updateParams.Phones;
            customer.Emails = updateParams.Emails;
            customer.Note = updateParams.Note;

            if (!customer.Validate(resultService))
                return null;

            return customer;
        }
    }
}