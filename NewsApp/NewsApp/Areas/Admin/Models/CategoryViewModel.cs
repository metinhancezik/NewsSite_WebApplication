using EntityLayer.Models;

namespace NewsApp.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public Category Category { get; set; }
        public int NewsCount { get; set; }
    }

}
