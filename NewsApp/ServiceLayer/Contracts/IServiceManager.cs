using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
        INewsService NewsService { get; }
        IAuthorService AuthorService { get; }

       //UserService UserService { get; }
    }
}
