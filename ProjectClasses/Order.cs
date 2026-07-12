using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClasses
{
    public class Order : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int ShipmentRiderId { get; set; }
        public ShipmentRider ShipmentRider { get; set; } = null!;
        public OrderStatus OrderStatus { get; set; }
    }

}
