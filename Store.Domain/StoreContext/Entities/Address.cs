using FluentValidator;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Entities
{
    public class Address : Notifiable
    {
        public Address(string street, string number, string complement, string district, string state, string country, string zipCode, string city, EAddressType type)
        {
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            State = state;
            Country = country;
            ZipCode = zipCode;
            City = city;
            Type = type;
        }

        public string Street { get; }
        public string Number { get; }
        public string Complement { get; }
        public string District { get; }
        public string State { get; }
        public string Country { get; }
        public string ZipCode { get; }
        public string City { get; }
        public EAddressType Type { get; }

        public override string ToString() => $"{Street}, {Number} - {City}/{State}";
    }
}
