using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Application.Abstraction.Models.Basket
{
    public record BasketDto
    {
        public required string Id { get; set; }
        public required IEnumerable<BasketItemDto> Items { get; set; }= new List<BasketItemDto>();

    }
}
