using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Application.Abstraction.Models.Basket;

namespace LinkDev.Talabat.Application.Abstraction.Services.Basket
{
    public interface IBasketServics
    {
        Task<BasketDto?> GetCustomerBasketAsync(string Id);
        Task<BasketDto?> UpdateCustomerBasketAsync(BasketDto basketDto);
        Task DeleteCustomerBasketAsync(string userId);
    }
}
