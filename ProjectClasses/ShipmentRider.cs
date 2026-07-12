namespace ProjectClasses
{
    public class ShipmentRider : User
    {
        public string ShipmentCompany { get; set; } = string.Empty;

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

}
