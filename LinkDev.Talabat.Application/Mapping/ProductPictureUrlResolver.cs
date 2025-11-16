using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Domain.Entites.Products;
using Microsoft.Extensions.Configuration;

namespace LinkDev.Talabat.Application.Mapping
{
    internal class ProductPictureUrlResolver :IValueResolver<Product,ProductToReturnDto,string>
    {
        private readonly IConfiguration configuration;

        public ProductPictureUrlResolver(IConfiguration configuration )
        {
            this.configuration = configuration;
        }
        public string? Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{configuration["Urls:ApiBaseUrl"]}/{source.PictureUrl}";
            return string.Empty;
        }
    }
}
