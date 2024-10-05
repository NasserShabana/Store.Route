using Store.Route.Core.Entites;
using Store.Route.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Route.Core.Repositories.Contract
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
       Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(TKey id);

        Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecifications<TEntity, TKey> Spec);
        Task<TEntity> GetWithSpecAsync(ISpecifications<TEntity, TKey> Spec);

        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TKey id);
    }
}
