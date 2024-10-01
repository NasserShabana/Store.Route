using Store.Route.Core.Entites;
using Store.Route.Core.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Route.Core
{
    public interface IUnitOfWork
    {
     Task<int>  CompleteAsync();

        // Create Repository<T> And Returnn It
        IGenericRepository<TEntity,TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
    }
}
