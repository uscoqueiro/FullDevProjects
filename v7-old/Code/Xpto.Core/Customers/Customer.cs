using Xpto.Core.Shared.Entities;

namespace Xpto.Core.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PersonType { get; set; }
        public string Identity { get; set; }
        public IList<Address> Addresses { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<Email> Emails { get; set; }
        public string Note { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid CreationUserId { get; set; }
        public string CreationUserName { get; set; }
        public DateTime? ChangeDate { get; set; }
        public Guid ChangeUserId { get; set; }
        public string ChangeUserName { get; set; }

        public Customer()
        {
            Id = Guid.NewGuid();
            Addresses = new List<Address>();
            Phones = new List<Phone>();
            Emails = new List<Email>();
            this.CreationDate = DateTime.Now;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
