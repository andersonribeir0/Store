using System;
using FluentValidator;
using FluentValidator.Validation;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class AddAddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public EAddressType Type { get; set; }
        public new bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasLen(Id.ToString(), 36, "AddressId", "Identificador do endereço inválido.")
            );
            return base.Valid;
        }
    }
}
