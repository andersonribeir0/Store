using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;
using Xunit;

namespace Store.Tests.Commands
{
    public class CreateCustomerCommandTests
    {
        [Fact]
        public void SHould_Return_Instance()
        {
            var command = new CreateCustomerCommand
            {
                Document = "11111111111",
                Email = new Email("kadu@ig.com.br").ToString(),
                FirstName = "Kadu",
                LastName = "Oliveira",
                Phone = "111111111"
            };

            Assert.True(command.Valid());
        }
    }
}
