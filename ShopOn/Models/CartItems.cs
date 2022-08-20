namespace ShopOn.Models
{
    public class CartItems
    {
        
            public int CartItemsId { get; set; }

            public decimal ItemPrice { get; set; }

            public int Quantity { get; set; }

            public int ItemIdNumber { get; set; }

            public string ItemName { get; set; }
        
    }
}
