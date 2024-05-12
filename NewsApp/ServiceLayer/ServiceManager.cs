using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICategoryService _categoryService;
        private readonly INewsService _newsService;
        private readonly IAuthorService _authorService;
      //  private readonly IUserService _userService;
        public ServiceManager(INewsService newsService, ICategoryService categoryService, IAuthorService authorService)
        {
            _newsService = newsService;
            _categoryService = categoryService;
            _authorService = authorService;
            //_userService = userService;
        }

        public ICategoryService CategoryService => _categoryService;

        public INewsService NewsService => _newsService;

        public IAuthorService AuthorService => _authorService;

       // public IUserService UserService => _userService;
    }
}
