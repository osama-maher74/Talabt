using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Domain.Entites.Basket
{
    public class BasketItem:BaseEntity<int>
    {

     
        public required string ProductName { get; set; }

        public string? pictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? Brand { get; set; }
        public string? Category { get; set; }

    }
}
