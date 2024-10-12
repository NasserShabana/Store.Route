using AutoMapper;
using Store.Route.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Route.Core.Mapping.Basket
{
    public class BasketProfile : Profile
    {

        public BasketProfile() 
        {
            CreateMap<CustomerBasket,CustomerBasketDto>().ReverseMap();
        }
    }
}
