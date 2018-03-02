using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.StoreContext.Queries
{
    public class CustomerOrdersCountResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public int TotalOrders { get; set; }
    }
}
