using Moq;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Store.Domain.StoreContext.Handlers;
using Store.Domain.StoreContext.Repositories;
using Store.Domain.StoreContext.Services;
using Xunit;

namespace Store.Tests.Handlers
{
    public class CustomerHandlerTests
    {
        public Mock<ICustomerRepository> _customerRepositoryMock = new Mock<ICustomerRepository>();
        public Mock<IEmailService> _emailServiceMock = new Mock<IEmailService>();

        [Fact]
        public void Should_Register_Customer_When_Command_Is_Valid()
        {
            _customerRepositoryMock.Setup(x => x.CheckDocument(It.IsAny<string>())).Returns(false);
            _emailServiceMock.Setup(x =>
                x.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            var command = new CreateCustomerCommand();
            command.FirstName = "Anderson";
            command.LastName = "Ribeiro";
            command.Document = "11111111111";
            command.Email = "anderson.moouro@gmail.com";
            command.Phone = "22999887745";

            var handler = new CustomerHandler(_customerRepositoryMock.Object, _emailServiceMock.Object);
            var result =  handler.Handle(command);

            Assert.True(handler.Valid);
            Assert.NotNull(result);
        }
    }
}
