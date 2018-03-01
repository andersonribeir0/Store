using System;
using System.Collections.Generic;
using System.Text;
using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                    .Requires()
                    .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter ao menos três caracteres.")
                    .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter ao menos três caracteres.")
                    .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres.")
                    .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres.")
                );
        }

        public string FirstName { get; }
        public string LastName { get; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
