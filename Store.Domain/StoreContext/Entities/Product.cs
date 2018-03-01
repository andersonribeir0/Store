using Store.Shared;

namespace Store.Domain.StoreContext.Entities
{
    public class Product : Entity
    {
        public Product(string title, decimal price, string description, string image, decimal quantity)
        {
            Title = title;
            Price = price;
            Description = description;
            Image = image;
            QuantityOnHand = quantity;
        }

        public string Title { get;  }
        public decimal Price { get; }
        public string Description { get; }
        public string Image { get; }
        public decimal QuantityOnHand { get; }

        public override string ToString()
        {
            return $"{Title}";
        }
    }
}