namespace Xpto.Core
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
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public DateTime? CreationDate { get; set; }
        public Guid CreationUserId { get; set; }
        public string CreationUserName { get; set; }
        public DateTime? ChangeDate { get; set; }
        public Guid ChangeUserId { get; set; }
        public string ChangeUserName { get; set; }

        public Customer()
        {
            this.Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
