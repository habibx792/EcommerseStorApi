namespace ProjectClasses
{
    public class ShipmentRider : User
    {
        public string ShipmentCompany { get; set; } = string.Empty;
        public shippeManStatus Status { get; set; } = shippeManStatus.Free;

    }

}
