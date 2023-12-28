namespace WebApp.Models
{
    public class CustomerBuy
    {
        public int CustomerBuyID { get; set; }
        public int CustomerID { get; set; }
        public int ShopProductID { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? ShopName { get; set; }
        public string? ShopLocation { get; set; }
        public string? ProductName{ get; set; }
        public string? ProductPrice { get; set; }
    }
}
