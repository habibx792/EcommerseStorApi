using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClasses
{
    public class Product:BaseModel
    {
        public string ProductName { get; set; }
        public double Price {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Price Can not Be Negtive");
                }
                this.price = value;
            }
        }
        public int Quantity { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        private double price;
        
    }
}
