using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public String CategoryName { get; set; } = String.Empty;
        public ICollection<News>? New { get;set; }
    }
}
