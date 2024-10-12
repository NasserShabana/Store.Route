using Store.Route.Core.Dtos.Products;
using Store.Route.Core.Helper;
using Store.Route.Core.Specifications.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Route.Core.Services.Contract
{
    public interface IproductService
    {
        Task<PaginationRespone<ProductDto>> GetAllProductsAsync(ProductSpecParams productSpec);
        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
          
    }
}
