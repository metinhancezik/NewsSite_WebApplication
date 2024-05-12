using Entities.RequestParameters;
using EntityLayer.Models;
using RepositoryLayer.Concrete;
using RepositoryLayer.Contracts;
using RepositoryLayer.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        public NewsRepository(RepositoryContext _context) : base(_context)
        {
        }

        public void CreateNews(News news) => Create(news);

        public void DeleteNews(News news) => Remove(news);

        public IQueryable<News> GetAllNews(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<News> GetAllNewsForPagination(NewsRequestParameters n)
        {
            return _context.News
                .FilteredBySearchTerm(n.SearchTerm)
                .ToPaginate(n.PageNumber, n.PageSize);
        }

        public News? GetOneNews(int id, bool trackChanges)
        {
            return FindByCondition(n => n.NewsID.Equals(id), trackChanges);
        }


		public void UpdateNews(News news) => Update(news);

	   	List<News> INewsRepository.GetPagedNews(List<News> allNews, int page, int pageSize)
		{
			return allNews.Skip((page - 1) * pageSize).Take(pageSize).ToList();
		}
	}
}
