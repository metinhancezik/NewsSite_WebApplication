using RepositoryLayer.Concrete;
using RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly INewsRepository _newsRepository;
        private readonly RepositoryContext _context;
        private readonly IAuthorRepository _authorRepository;
   
        public RepositoryManager(ICategoryRepository categoryRepository, INewsRepository newsRepository, RepositoryContext context,IAuthorRepository authorRepository)
        {
            _categoryRepository = categoryRepository;
            _newsRepository = newsRepository;
            _context = context;
            _authorRepository = authorRepository;
       
        }

        public ICategoryRepository Category => _categoryRepository;

        public INewsRepository News => _newsRepository;

        public IAuthorRepository Authors => _authorRepository;

   //   public IUserRepository User => _userRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
