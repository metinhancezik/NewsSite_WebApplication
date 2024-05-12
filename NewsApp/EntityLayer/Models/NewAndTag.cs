using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models
{
    public class NewAndTag
    {
        [Key]
        public int NewsTagID { get; set; }

        public int NewsID { get; set; }
        [ForeignKey("NewsID")]
        public News? New { get; set; }

        public int TagID { get; set; }
        [ForeignKey("TagID")]
        public Tag? Tag { get; set; }
    }
}
