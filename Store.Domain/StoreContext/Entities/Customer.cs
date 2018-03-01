using System.Collections.Generic;
using System.Linq;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared;

namespace Store.Domain.StoreContext.Entities
{
    public class Customer : Entity
    {
        private readonly IList<Address> _addresses;

        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }

        public Name Name { get; set; }
        public Document Document { get; }
        public Email Email { get; }
        public string Phone { get; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray(); 

        public override string ToString() => Name.ToString();

        public void AddAdress(Address address)
        {
            _addresses.Add(address);
        }

        public void Register(){}

        public void OnRegister(){}
    }
}
