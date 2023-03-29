using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override string ToString()
        {
            return string.Join(" ", Street, Number, Complement, District, City, State, ZipCode);
        }
    }
}
