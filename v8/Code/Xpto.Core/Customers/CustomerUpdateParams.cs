using Xpto.Core.Shared.Entities;
using Xpto.Core.Shared.Params;

namespace Xpto.Core.Customers
{
    public class CustomerUpdateParams
    {
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PersonType { get; set; }
        public string Identity { get; set; }
        public IList<AddressParams> Addresses { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<Email> Emails { get; set; }
        public string Note { get; set; }
    }
}