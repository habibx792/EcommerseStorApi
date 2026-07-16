namespace EcommerApi.Data.NewFolder
{
    public class PlaceOrderDto
    {
        public int UserId { get; set; }
        public List<int> ProductIds { get; set; } = new();
    }
}
