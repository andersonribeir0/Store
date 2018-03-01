using Store.Shared;

namespace Store.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            if(product.QuantityOnHand < quantity)
                AddNotification("Quantity", "Produto fora de estoque!");
        }

        public Product Product { get; }
        public decimal Quantity { get; }
        public decimal Price { get; }    
    }
}