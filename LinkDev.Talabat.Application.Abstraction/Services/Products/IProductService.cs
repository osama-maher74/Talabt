using LinkDev.Talabat.Application.Abstraction.Common;
using LinkDev.Talabat.Application.Abstraction.Models.Products;

namespace LinkDev.Talabat.Application.Abstraction.Services.Products
{
    public interface IProductService
    {
        Task<Pagination<ProductToReturnDto>> GetAllProductsAsync(ProudctSpacficationParams spec);
        Task<ProductToReturnDto> GetProductAsync(int id);   
        Task<IEnumerable<BrandDto>> GetBrandsAsync();
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
        

    }
}
