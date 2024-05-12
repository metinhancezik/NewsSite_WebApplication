using Entities.RequestParameters;
using EntityLayer.Models;
using RepositoryLayer.Contracts;
using ServiceLayer.Contracts;

namespace ServiceLayer
{
    public class NewsManager : INewsService
    {
        private readonly IRepositoryManager _manager;

        public NewsManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateNews(News news)
        {
            _manager.News.Create(news);
            _manager.Save();
        }

        public void DeleteNews(int id)
        {
            News news = GetOneNews(id, false);
            if(news is not null)
            {
                _manager.News.DeleteNews(news);
                _manager.Save();
            }
        }

        public IEnumerable<News> GetAllNews(bool trackChanges)
        {
            return _manager.News.GetAllNews(trackChanges);
        }

        public IEnumerable<News> GetAllNewsByCategory(int categoryId)
        {
            var category = _manager.Category.FindByCondition(n => n.CategoryID.Equals(categoryId), false);
            if (category is not null)
            {
                return _manager.News.FindAll(false).Where(n => n.CategoryID.Equals(categoryId)).ToList();
            }
            throw new Exception("Böyle bir kategori yok");
        }

        public IEnumerable<News> GetBreakingtNews()
        {
            return _manager.News.FindAll(false).Where(n => n.NewsIsLatest == true).ToList();
        }

        public IEnumerable<News> GetLastestNews(int count)
        {
            return _manager.News.FindAll(false).OrderByDescending(n=> n.NewsID).Take(count);
        }

        public IEnumerable<News> GetNewsByCategoryandCount(int categoryId, int count)
        {
            return  _manager.News.FindAll(false).Where(n => n.CategoryID.Equals(categoryId)).OrderByDescending(n => n.NewsID).Take(count);
        }

        public News GetOneNews(int id, bool trackChanges)
        {
            var news = _manager.News.GetOneNews(id, false);
            if (news is not null)
                return news;
            throw new Exception("Haber bulunamamaktadır");
        }

        public IEnumerable<News> GetSliderNews()
        {
            return _manager.News.GetAllNews(false).Where(n => n.NewsInSlide == true).ToList(); 
        }
        public IEnumerable<News> GetAnaHaberNews()
        {
            return _manager.News.GetAllNews(false).Where(n => n.AnaHaber == true).ToList();
        }
        public void UpdateNews(News news)
        {
            _manager.News.Update(news);
            _manager.Save();
        }
		public List<News> GetPagedNews(List<News> allNews, int page, int pageSize)
		{
			return allNews.Skip((page - 1) * pageSize).Take(pageSize).ToList();
		}
        public IEnumerable<News> GetAllNewsWithDetails(NewsRequestParameters n)
        {
            return _manager.News.GetAllNewsForPagination(n);
        }

      
      
    }
}
