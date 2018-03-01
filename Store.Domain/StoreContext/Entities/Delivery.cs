using System;
using FluentValidator;
using Store.Domain.StoreContext.Enums;

namespace Store.Domain.StoreContext.Entities
{
    public class Delivery : Notifiable
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; }
        public DateTime EstimatedDeliveryDate { get; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship() => Status = EDeliveryStatus.Shipped;
        public void Cancel() => Status = EDeliveryStatus.Cancelled;
    }
}