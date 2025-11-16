using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Models.Basket;
using LinkDev.Talabat.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Domain.Entites.Basket;
using LinkDev.Talabat.Domain.Entites.Products;

namespace LinkDev.Talabat.Application.Mapping
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand!.Name))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category!.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());

            CreateMap<ProductBrand,BrandDto>();

            CreateMap<ProductCategory,CategoryDto>();

            CreateMap<Basket,BasketDto>().ReverseMap();
            CreateMap<BasketItem,BasketItemDto>().ReverseMap();
        }

    }
}
