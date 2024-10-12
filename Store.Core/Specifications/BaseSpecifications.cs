using Store.Route.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Route.Core.Specifications
{
    public class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public Expression<Func<TEntity, bool>> Criteria { get  ; set  ; }
        public List<Expression<Func<TEntity, object>>> Includes { get  ; set  ; } = new List<Expression<Func<TEntity, object>>> ();
        public Expression<Func<TEntity, object>> OrderBy { get  ; set  ; }
        public Expression<Func<TEntity, object>> OrderByDescending { get  ; set  ; }
        public int Skip { get  ; set  ; }
        public int Take { get  ; set  ; }
        public bool IsPagingEnabled { get  ; set  ; }

        public BaseSpecifications(Expression<Func<TEntity, bool>> expression)
        {
              Criteria = expression;
        }

        public BaseSpecifications() 
        { 

        }

        public void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        public void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        } 

        public void ApplyPagination(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }
    }
}
