namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; }

        public decimal TotalPrice { get =>  Items.Sum(item => item.Quantity * item.Price); }

        public ShoppingCart()
        {
            Items = new List<ShoppingCartItem>();
        }
        public ShoppingCart(string userName) :this()
        {
            UserName = userName;
        }

    }
}
