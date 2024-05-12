using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Extensions
{
    public static class NewsRepositoryExtension
    {
        public static IQueryable<News> FilteredBySearchTerm(this IQueryable<News> news,String? searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
                return news;
            else
                return news.Where(x => x.NewsTitle.ToLower().Contains(searchTerm.ToLower()));
        }
        public static IQueryable<News> ToPaginate(this IQueryable<News> news,int pageNumber,int pageSize)
        {

            return news.Skip(((pageNumber - 1) * pageSize))
                .Take(pageSize);
        }
    }
}
