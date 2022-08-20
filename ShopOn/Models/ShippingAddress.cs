namespace ShopOn.Models
{
    public class ShippingAddress
    {
        public int ShippingAddressId { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string pincode { get; set; }

        public string state { get; set; }

        public string City { get; set; }

        public string HouseNumber { get; set; }

        public string LandMark { get; set; }

        public string TypeOfAddress { get; set; }
    }
}
