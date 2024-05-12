using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string TagName { get; set; } = String.Empty;
        public ICollection<NewAndTag>? NewsTags { get; set; }
    }
}
