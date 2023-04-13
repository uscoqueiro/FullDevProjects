using Xpto.Core.Shared.Params;

namespace Xpto.Core.Shared.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Note { get; set; }

        public Address()
        {
            Id = Guid.NewGuid();
        }


        public Address(AddressParams addressParams)
        {
            this.Id = Guid.NewGuid();

            if (addressParams.Id != null)
                this.Id = (Guid)addressParams.Id;

            this.Type = addressParams.Type;
            this.Street = addressParams.Street;
            this.Number = addressParams.Number;
            this.Complement = addressParams.Complement;
            this.District = addressParams.District;
            this.City = addressParams.City;
            this.State = addressParams.State;
            this.ZipCode = addressParams.ZipCode;
            this.Note = addressParams.Note;
        }

        public AddressParams ToParams()
        {
            var x = new AddressParams
            {
                Id = this.Id,
                Type = this.Type,
                Street = this.Street,
                Number = this.Number,
                Complement = this.Complement,
                District = this.District,
                City = this.City,
                State = this.State,
                ZipCode = this.ZipCode,
                Note = this.Note
            };

            return x;
        }

        public override string ToString()
        {
            return string.Join(" ", Street, Number, Complement, District, City, State, ZipCode);
        }
    }
}
