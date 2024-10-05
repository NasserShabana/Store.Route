using Store.Route.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Route.Core.Specifications.Products
{
    public class ProductSpecifications : BaseSpecifications<Product,int>
    {
        public ProductSpecifications(string? Sort , int? TypeId, int? brandId) : base 
            (
            (p =>
            (!TypeId.HasValue || p.TypeId == TypeId)
            &&
            (!brandId.HasValue || p.BrandId == brandId))
            )
        {
            AddInclude();

           // Name , Price ,PriceDesc
           if(!string.IsNullOrEmpty(Sort))
            {
                var result = Sort.ToLower();

                switch (result)
                {
                     case "name":
                        OrderBy = x => x.Name;
                        break;
                    case "priceasc":
                        OrderBy = x => x.Price;
                        break;
                    case "pricedesc":
                        OrderByDescending = x => x.Price;
                        break;
                    default: 
                        OrderBy = x => x.Name;
                        break;
                }
            }
            else
            {
                OrderBy = x => x.Name;
            }

        }

        public ProductSpecifications(int Id)
        {
            Criteria = p => p.Id == Id;

            AddInclude();
        }

        private void AddInclude()
        {
            Includes.Add(x => x.Brand);
            Includes.Add(x => x.Type);
        }
    }
}
    
    
