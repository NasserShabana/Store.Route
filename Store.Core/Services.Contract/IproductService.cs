﻿using Store.Route.Core.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Route.Core.Services.Contract
{
    public interface IproductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(string? Sort, int? brandId, int? TypeId, int? PageSize,  int? PageIndex);
        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();
        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
          
    }
}
