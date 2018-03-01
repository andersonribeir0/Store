using System.Security.Cryptography;
using FluentValidator;
using FluentValidator.Validation;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public new bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .IsNotNull(FirstName, "FirstName", "Nome não pode ser nulo.")
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter ao menos três caracteres.")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter ao menos três caracteres.")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres.")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres.")
                .IsEmail(Email, "Email", "Email inválido.")
                .HasLen(Document, 11, "Document", "CPF inválido.")
            );
            return base.Valid;
        }
    }
}
