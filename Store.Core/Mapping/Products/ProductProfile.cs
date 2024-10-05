using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Route.Core.Dtos.Products;
using Store.Route.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Route.Core.Mapping.Products
{
    public class ProductProfile : Profile
    {
        private readonly IConfiguration _congfiguration;

        //public ProductProfile(IConfiguration congfiguration)
        //{
        //    _congfiguration = congfiguration;

        //    CreateMap<Product, ProductDto>()
        //        .ForMember(P => P.BrandName , options => options.MapFrom(src => src.Brand.Name))
        //        .ForMember(P => P.TypeName , options => options.MapFrom(src => src.Type.Name))
        //        .ForMember(P => P.PictureUrl, options => options.MapFrom(src => $"{_congfiguration["BaseUrl"]}{src.PictureUrl}"));


        //    CreateMap<ProductBrand, TypeBrandDto>();
        //    CreateMap<ProductType, TypeBrandDto>();
        //}


        public ProductProfile(IConfiguration congfiguration)
        {
            _congfiguration = congfiguration;

            CreateMap<Product, ProductDto>()
                .ForMember(P => P.BrandName, options => options.MapFrom(src => src.Brand.Name))
                .ForMember(P => P.TypeName, options => options.MapFrom(src => src.Type.Name))
                .ForMember(P => P.PictureUrl, options => options.MapFrom(new PictureUrlResolver(_congfiguration)));

            CreateMap<ProductBrand, TypeBrandDto>();
            CreateMap<ProductType, TypeBrandDto>();
        }
    }
}
