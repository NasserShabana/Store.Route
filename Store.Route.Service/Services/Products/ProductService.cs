using AutoMapper;
using Store.Route.Core;
using Store.Route.Core.Dtos.Products;
using Store.Route.Core.Entites;
using Store.Route.Core.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Route.Service.Services.Products
{
    public class ProductService : IproductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork , IMapper mapper ) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync()
        {
          var Brands =  await _unitOfWork.Repository<ProductBrand, int>().GetAllAsync();
          var BrandsMapped =  _mapper.Map<IEnumerable<TypeBrandDto>>(Brands);
          return BrandsMapped;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {

         return _mapper.Map<IEnumerable<ProductDto>>(await _unitOfWork.Repository<Product, int>().GetAllAsync());
         
        }

        public async Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync()
        {
         return  _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repository<ProductType, int>().GetAllAsync());
         }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.Repository<Product, int>().GetAsync(id);
            var mappedProduct = _mapper.Map<ProductDto>(product);
            return mappedProduct;
        }
    }
}
