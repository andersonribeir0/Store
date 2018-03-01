using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;
            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "Email inválido.")
            );
        }

        public string Address { get; }

        public override string ToString() => Address;

    }
}