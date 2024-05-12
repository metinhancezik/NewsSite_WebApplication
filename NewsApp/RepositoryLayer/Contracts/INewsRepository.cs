using Entities.RequestParameters;
using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts
{
    public interface INewsRepository :IRepositoryBase<News>
    {
        IQueryable<News> GetAllNews(bool trackChanges);
        News? GetOneNews(int id, bool trackChanges);
        void CreateNews(News news);
        void DeleteNews(News news);
        void UpdateNews(News news);

        List<News> GetPagedNews(List<News> allNews, int page, int pageSize);
        IQueryable<News> GetAllNewsForPagination(NewsRequestParameters n);
        

	}
}
