using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Comment // Şuanlık askıda
    {
        public int CommentID { get; set; }
        public string CommentContent { get; set; } = String.Empty;
        public DateTime CommentDate { get; set; }= DateTime.MinValue;
        public int NewsID { get; set; }
        public News? News { get; set; }
        public int UserID { get; set; }
        public User? User { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
