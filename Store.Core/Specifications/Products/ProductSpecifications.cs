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
        public ProductSpecifications(ProductSpecParams productSpec) : base 
            (
            p =>
            (string.IsNullOrEmpty(productSpec.Search) || p.Name.ToLower().Contains(productSpec.Search))
            &&
            (!productSpec.TypeId.HasValue ||   productSpec.TypeId == p.TypeId )
            &&
            (!productSpec.brandId.HasValue ||   productSpec.brandId == p.BrandId)
            )
        {
 
           // Name , Price ,PriceDesc
           if(!string.IsNullOrEmpty(productSpec.Sort))
            {
                

                switch (productSpec.Sort)
                {
                     case "name":
                        AddOrderBy(x => x.Name);
                        break;
                    case "priceasc":
                        AddOrderBy(x => x.Price);
                        break;
                    case "pricedesc":
                        AddOrderByDescending(x => x.Price);
                        break;
                    default:
                        AddOrderBy(x => x.Name);
                        break;
                }
            }
            else
            {
                AddOrderBy(x => x.Name);
            }

            AddInclude();

            ApplyPagination(productSpec.PageSize * (productSpec.PageIndex - 1), productSpec.PageSize);
        }

        public ProductSpecifications(int Id) : base (p => p.Id == Id)
        {
            AddInclude();
        }

        private void AddInclude()
        {
            Includes.Add(x => x.Brand);
            Includes.Add(x => x.Type);
        }
    }
}
    
    
