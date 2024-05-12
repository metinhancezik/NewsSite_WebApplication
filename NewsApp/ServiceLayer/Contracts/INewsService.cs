using Entities.RequestParameters;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface INewsService
    {
        IEnumerable<News> GetAllNews(bool trackChanges);
        News GetOneNews(int id,bool trackChanges);
        List<News> GetPagedNews(List<News> allNews, int page, int pageSize);
		IEnumerable<News> GetSliderNews();
        IEnumerable<News> GetBreakingtNews();
        IEnumerable<News> GetAllNewsByCategory(int categoryId);
        IEnumerable<News> GetNewsByCategoryandCount(int categoryId,int count);
        IEnumerable<News> GetAnaHaberNews();
        IEnumerable<News> GetLastestNews(int count);
        IEnumerable<News> GetAllNewsWithDetails(NewsRequestParameters n);
        void CreateNews(News news);
        void UpdateNews(News news);
        void DeleteNews(int id);
    }
}
