using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Domain.Entites.Products
{
    public class Product : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
        public required string NormalizedName { get; set; }
        public required string Description { get; set; }
        public  string? PictureUrl { get; set; }

        public  decimal Price { get; set; }

        public int? CategoryId { get; set; }
        public virtual ProductCategory? Category { get; set; }
        public int? BrandId { get; set; }
        public virtual ProductBrand? Brand { get; set; }
                                     
    }
}
