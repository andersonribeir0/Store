using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Store.Domain.StoreContext.ValueObjects;
using Xunit;
using Xunit.Sdk;

namespace Store.Tests.ValueObjects
{
    public class DocumentTests
    {

        [Fact]
        public void Should_Not_Return_Notification_When_Document_Is_Valid()
        {
            var document = new Document("12033524760");

            Assert.True(document.Valid);
            Assert.True(document.Notifications.Count == 0);
        }

        [Theory]
        [InlineData("1234567890")]
        [InlineData("1111111318")]
        [InlineData("4579851231")]
        public void Should_Return_Notification_When_Document_Is_Invalid(string documentNumber)
        {
            var document = new Document(documentNumber);

            Assert.True(document.Invalid);
            Assert.True(document.Notifications.Count > 0);
        }
    }
}
