using EntityLayer.Models;
using RepositoryLayer.Concrete;
using RepositoryLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext _context) : base(_context)
        {

        }

        public IQueryable<Author> GetAll(bool trackChanges)
        {
            return FindAll(trackChanges) ;
        }

        public Author? GetOneAuthor(int id, bool trackChanges)
        {
            return FindByCondition(x=>x.AuthorID.Equals(id),trackChanges);
        }
    }
}
