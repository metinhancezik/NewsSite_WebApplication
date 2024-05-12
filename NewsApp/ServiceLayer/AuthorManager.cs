using EntityLayer.Models;
using RepositoryLayer.Contracts;
using ServiceLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AuthorManager : IAuthorService
    {
        private readonly IRepositoryManager _manager;

        public AuthorManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

		public void CreateAuthor(Author author)
		{
            _manager.Authors.Create(author);
            _manager.Save();
		}

	
		public void DeleteAuthor(int id)
		{
            var model = _manager.Authors.GetOneAuthor(id,true);
            if (model is not null)
            {
                _manager.Authors.Remove(model);
                _manager.Save();
            }
        }

		public IEnumerable<Author>? GetAllAuthor(bool trackChanges)
		{
            return _manager.Authors.GetAll(trackChanges);
		}

        public Author? GetAuthorByID(int id, bool trackChanges)
        {
            var model = _manager.Authors.GetOneAuthor(id, trackChanges);
            return model;
        }

        public void UpdateAuthor(Author author)
		{
            _manager.Authors.Update(author);
            _manager.Save();
		}


    }
}
