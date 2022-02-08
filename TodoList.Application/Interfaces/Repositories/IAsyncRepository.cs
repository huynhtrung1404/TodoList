using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Applications.Interfaces.Repositories
{
    public interface IAsyncRepository<TEntity, TId> : IGenericRepository<TEntity, TId> where TEntity: class
    {
    }
}
