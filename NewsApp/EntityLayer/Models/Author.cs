using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Author // Şuanlık askıda
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; } = String.Empty;
        
        public bool IsActive { get; set; } = true;
        public ICollection<News>? New { get; set; } 
    }
}
