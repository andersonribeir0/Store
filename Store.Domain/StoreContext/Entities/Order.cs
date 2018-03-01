using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _Items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _Items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _Items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Ëste pedido não possui Items");

            _Items.Add(new OrderItem(product, quantity));
        }
        public void AddDelivery(Delivery delivery) => _deliveries.Add(delivery);

        public void Place()
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if(_Items.Count == 0)
                AddNotification("Order", "Este pedido não possui Items");
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;
            var delivery = new Delivery(DateTime.Now.AddDays(5));
            _deliveries.Add(delivery);
        }

        public void Ship()
        {
            var count = 1;
            var deliveries = new List<Delivery> {new Delivery(DateTime.Now.AddDays(5))};

            foreach (var item in _Items)
            {
                if (count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }
           
            deliveries.ForEach(x => x.Ship());
            deliveries.ForEach(x =>_deliveries.Add(x));
        }

        public void Cancel()
        {
            Status = EOrderStatus.Cancelled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }

    }
}