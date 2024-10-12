using Store.Route.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Route.Core.Specifications.Products
{
    public class ProductwithCountSpecifitions : BaseSpecifications<Product,int>
    {


        public ProductwithCountSpecifitions(ProductSpecParams productSpec) : base
           (
               p =>
                   (!productSpec.TypeId.HasValue || p.TypeId == productSpec.TypeId)
                &&
                   (!productSpec.brandId.HasValue || p.BrandId == productSpec.brandId)
           )

        {

             
        }

    }
}
