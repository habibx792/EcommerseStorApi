using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectClasses
{
    public class User:BaseModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        [Required]
        public string Confirm { get;set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

    }
}
