using EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool trackChanges);
        void CreateCategory(Category category);
        void DeleteCategory(int id);
        void UpdateCategory(Category category);
        Category GetOneCategory(int? id, bool trackChanges);
    }
}
