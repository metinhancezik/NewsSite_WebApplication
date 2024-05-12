using EntityLayer.Models;
using StoreApp.Models;

namespace NewsApp.Models
{
	public class NewsListViewModel
	{
		public IEnumerable<News> News { get; set; } = Enumerable.Empty<News>();
		public Pagination Pagination { get; set; } = new();
		public int TotalCount => News.Count();
	}

}
