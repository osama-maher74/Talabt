using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Entites.Basket;

namespace LinkDev.Talabat.Domain.Infrastrcrture
{
    public interface IBasketRepositry
    {

        Task<Basket?> GetAsync(string userId);
        Task<Basket?> UpdateAsync(Basket basket,TimeSpan timeToLive);

        Task DeleteAsync(string userId);
    }
}
