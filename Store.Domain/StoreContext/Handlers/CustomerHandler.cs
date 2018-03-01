using FluentValidator;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;
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
            //Criar entidade
            //Persistir o cliente
            //Enviar um E-mail de boas vindas
            //Retornar o resultado para tela
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
