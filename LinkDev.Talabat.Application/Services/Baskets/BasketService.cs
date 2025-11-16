using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Models.Basket;
using LinkDev.Talabat.Application.Abstraction.Services.Basket;
using LinkDev.Talabat.Application.Excpetions;
using LinkDev.Talabat.Domain.Entites.Basket;
using LinkDev.Talabat.Domain.Infrastrcrture;
using Microsoft.Extensions.Configuration;

namespace LinkDev.Talabat.Application.Services.Baskets
{
    public class BasketService : IBasketServics
    {
        private readonly IBasketRepositry basketRepositry;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public BasketService(IBasketRepositry basketRepositry,IMapper mapper,IConfiguration configuration)
        {
            this.basketRepositry = basketRepositry;
            this.mapper = mapper;
            this.configuration = configuration;
        }
       

        public async Task<BasketDto?> GetCustomerBasketAsync(string Id)
        {
            var basket = await basketRepositry.GetAsync(Id);
            
            return basket is null ? throw new NotFoundException(nameof(Basket),Id) : mapper.Map<BasketDto>(basket);


        }

        public async Task<BasketDto?> UpdateCustomerBasketAsync(BasketDto basketDto)
        {
            var mappedBasket = mapper.Map<Basket>(basketDto);
            var timeToLive =int.Parse( configuration.GetSection("RedisSettings")["TimeToliveInDays"]!);
            var updatedBasket =await basketRepositry.UpdateAsync( mappedBasket,TimeSpan.FromDays( timeToLive));
            if(updatedBasket is null) throw new BadRequestException("Problem saving basket");
            return basketDto;

        }
        public async Task DeleteCustomerBasketAsync(string userId)
        
        =>    await basketRepositry.DeleteAsync( userId);
        
    }
}
