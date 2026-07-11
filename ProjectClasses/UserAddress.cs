
namespace ProjectClasses
{
    public class UserAddress : BaseModel
    {
        public User User { get; set; }
        public int UserId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string streetNumber { get; set; }
        public string Postal_Code { get; set; }
    }
    
}
