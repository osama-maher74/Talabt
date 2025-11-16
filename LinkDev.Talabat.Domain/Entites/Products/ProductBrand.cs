
namespace LinkDev.Talabat.Domain.Entites.Products
{
    public class ProductBrand :BaseAuditableEntity<int>
    {
        public required string Name { get; set; }
    }
}
