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
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext _context) : base(_context)
        {
        }

        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void DeleteCategory(Category category)
        {
            Remove(category);
        }

        public Category GetOneCategory(int? id, bool trackChanges)
        {
            return FindByCondition(x => x.CategoryID.Equals(id), trackChanges);
        }

       

        public void UpdateCategory(Category category)
        {
            Update(category);
        }
    }
}
