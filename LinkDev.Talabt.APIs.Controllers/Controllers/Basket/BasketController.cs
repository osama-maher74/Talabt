using LinkDev.Talabat.APIs.Controllers.Base;
using LinkDev.Talabat.Application.Abstraction.Models.Basket;
using LinkDev.Talabat.Application.Abstraction.Services;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabt.APIs.Controllers.Controllers.Basket
{
    public class BasketController : BaseApiController
    {
        private readonly IServiceManger serviceManger;

        public BasketController(IServiceManger serviceManger)
        {
            this.serviceManger = serviceManger;
        }

        [HttpGet("items")]
       public async Task<IActionResult> GetItems(string id)
       {
           var items = await serviceManger.BasketServics.GetCustomerBasketAsync(id);
           return Ok(items);
       }
        [HttpPost]
        public async Task<IActionResult> UpdateBasket(BasketDto basket)
        {
            var updatedBasket = await serviceManger.BasketServics.UpdateCustomerBasketAsync(basket);
            return Ok(updatedBasket);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(string id)
        {
            await serviceManger.BasketServics.DeleteCustomerBasketAsync(id);
            return NoContent();
        }

    }
}
