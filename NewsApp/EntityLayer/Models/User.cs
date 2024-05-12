using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EntityLayer.Models
{
    public class User 
    {

        public int UserID { get; set; }

        public string UserName { get; set; } 

        public string UserPassword { get; set; } 

        public ICollection<Comment>? Comments { get; set; }

        public string role { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
