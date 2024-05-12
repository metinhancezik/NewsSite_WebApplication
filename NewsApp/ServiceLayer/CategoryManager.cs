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
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _manager;

        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateCategory(Category category)
        {
            _manager.Category.CreateCategory(category);
            _manager.Save();
        }

        public void DeleteCategory(int id)
        {
            var category = _manager.Category.GetOneCategory(id, false);
            if(category is not null)
            {
                _manager.Category.Remove(category);
            }
        }

        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.FindAll(trackChanges);
        }

        public void UpdateCategory(Category category)
        {
            _manager.Category.Update(category);
            _manager.Save();
        }
        public Category GetOneCategory(int? id, bool trackChanges)
        {
            var categories = _manager.Category.GetOneCategory(id, false);

            if (categories is not null)
                return categories;

            throw new Exception("Kategori bulunamamaktadır");
        }


    }
}
