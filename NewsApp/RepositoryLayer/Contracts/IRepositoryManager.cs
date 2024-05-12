using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Contracts
{
    public interface IRepositoryManager
    {
        ICategoryRepository Category { get; }
        INewsRepository News { get; }
        IAuthorRepository Authors { get; }
   //     IUserRepository User { get; }
        void Save();
    }
}
