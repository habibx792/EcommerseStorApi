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
        public List<Product> Products { get; set; }
        
        public OrderStatus OrderStatus { get; set; }
    }

}
