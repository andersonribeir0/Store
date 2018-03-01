using System;
using System.Collections.Generic;
using System.Text;
using AutoFixture;
using Moq;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enums;
using Store.Domain.StoreContext.ValueObjects;
using Xunit;

namespace Store.Tests.Entities
{
    public class OrderTests
    {
        
        private readonly Order _order;

        public OrderTests()
        {
            var name = new Name("Anderson", "Ribeiro");
            var document = new Document("11111111111");
            var email = new Email("anderson.moouro@gmail.com");
            var customer = new Customer(name, document, email, "2297854585");
            _order = new Order(customer);
        }

        [Fact]
        public void Should_Create_New_Order_Successfully()
        {
           Assert.True(_order.Valid);
        }

        [Fact]
        public void Should_Become_With_Created_Status_When_Order_Is_Created()
        {
            Assert.Equal(expected: EOrderStatus.Created, actual: _order.Status);
        }

        [Fact]
        public void Should_Change_Quantity_When_A_New_Item_Is_Added()
        {
            
            var helicoptero = new Product("Helicóptero", 100.50M, "Eletrônicos", "helicóptero.jpg", 10);
            var aviao = new Product("Avião", 100.50M, "Eletrônicos", "helicóptero.jpg", 10);
            _order.AddItem(helicoptero, 3);
            _order.AddItem(aviao, 3);
            
            Assert.Equal(2, _order.Items.Count);
        }

        [Fact]
        public void Should_Subtract_Product_Quantity_When_Add_A_New_Product()
        {

        }
    }
}
