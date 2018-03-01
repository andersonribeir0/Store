using System;
using FluentValidator;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;
using Store.Shared.Commands;

namespace Store.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o CPF já existe na base
            
            //Verificar se o Email já existe na base
            
            //Criar os VO's
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar entidade
            var customer = new Customer(name, document, email, command.Phone);

            //Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            //Persistir o cliente
            //Enviar um E-mail de boas vindas
            //Retornar o resultado para tela
            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.ToString());
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
