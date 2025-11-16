using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LinkDev.Talabat.Domain.Entites.Basket;
using LinkDev.Talabat.Domain.Infrastrcrture;
using StackExchange.Redis;

namespace LinkDev.Talabat.Infrastracture.Basket_Repositry
{
    public class BasketRepositry : IBasketRepositry
    {
        private readonly IDatabase _database;
        public BasketRepositry(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();    
        }
        public async Task<Basket?> GetAsync(string userId)
        {
            var basket = await _database.StringGetAsync(userId);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket>(basket!);
        }

        public async Task<Basket?> UpdateAsync(Basket basket, TimeSpan timeToLive)
        {
            var serializedBasket = JsonSerializer.Serialize(basket);

            // Convert basket.Id (int) to string for RedisKey
            var created = await _database.StringSetAsync(basket.Id, serializedBasket, timeToLive);

            if (!created) return null;
            return basket;
        }
        public async Task DeleteAsync(string userId)
        {
            await _database.KeyDeleteAsync(userId);
        }
    }
}
