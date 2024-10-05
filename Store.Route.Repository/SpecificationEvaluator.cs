using Microsoft.EntityFrameworkCore;
using Store.Route.Core.Entites;
using Store.Route.Core.Specifications;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Route.Repository
{
    public class SpecificationEvaluator<TEtity,TKey>  where TEtity : BaseEntity<TKey>
    {
        // Generate Query And Return It
        public static IQueryable<TEtity> GetQuery(IQueryable<TEtity> InputQuery , ISpecifications<TEtity,TKey> Spec)
        { 
        
            var Query = InputQuery;

            // Where
            if (Spec.Criteria != null)
            {
               Query = Query.Where(Spec.Criteria); // _context.products.Where(P => P.Id == 1);
            }
             
                
            // Include
            if (Spec.Includes != null)
            {
               Query = Spec.Includes.Aggregate(Query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
            }

            // Order By Asc
            if (Spec.OrderBy != null)
            {
                Query = Query.OrderBy(Spec.OrderBy);
            }

            // Order By DESC
            if (Spec.OrderByDescending != null)
            {
                Query = Query.OrderByDescending(Spec.OrderByDescending);
            }

            //// Filter
            //if (Spec.Criteria != null)
            //{
            //    Query = Query.Where(Spec.Criteria);
            //}

            return Query;
        }

    }
}
