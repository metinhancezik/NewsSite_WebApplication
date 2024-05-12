using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        IQueryable<Author> GetAll(bool trackChanges);

        Author? GetOneAuthor(int id, bool trackChanges);


    }
}
