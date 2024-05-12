using EntityLayer.Models;

namespace NewsApp.Models
{
    public class CategoriesOrtaSayfaModel
    {
        public List<Category> Categories { get; set; }
        public Dictionary<Category, List<News>> NewsByCategory { get; set; } = new Dictionary<Category, List<News>>();

    }

}
