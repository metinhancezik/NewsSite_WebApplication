using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Models
{
    public class News
    {
        public int NewsID { get; set; }
     //   [Required(ErrorMessage ="Başlık Girilmesi Zorunludur")]
        public String NewsTitle { get; set; } = String.Empty;
     //   [Required(ErrorMessage ="Fotoğraf Olmalı")]
        public String NewsPhoto { get; set; } = String.Empty;
        public String NewsDetail { get; set; } = String.Empty;
        public String NewsShortDescription { get; set; } = String.Empty;
        public bool NewsInSlide { get; set; } = false;
        public String? AnaHaberBaslik { get; set; } = String.Empty;

        public bool AnaHaber { get; set; } = false;

        public bool NewsIsLatest { get; set; } = false;
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }
       public  bool IsActive { get; set; } = true;
        public DateTime NewsDate { get; set; }= DateTime.UtcNow;
    }
}