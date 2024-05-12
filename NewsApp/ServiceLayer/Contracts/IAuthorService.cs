using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface IAuthorService
    {
        IEnumerable<Author>? GetAllAuthor(bool trackChanges);
        Author? GetAuthorByID(int id,bool trackChanges);
        void CreateAuthor(Author author);
        void DeleteAuthor(int id);
        void UpdateAuthor(Author author);

    }
}
