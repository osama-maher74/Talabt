

namespace LinkDev.Talabat.Domain.Entites.Products
{
    public class ProductCategory : BaseAuditableEntity<int>
    {
        public required string Name { get; set; }

        //public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
