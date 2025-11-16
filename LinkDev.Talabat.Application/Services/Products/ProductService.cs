using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Common;
using LinkDev.Talabat.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Application.Abstraction.Services.Products;
using LinkDev.Talabat.Application.Excpetions;
using LinkDev.Talabat.Domain.Contracts.Presistance;
using LinkDev.Talabat.Domain.Entites.Products;
using LinkDev.Talabat.Domain.Spesfications.Products;

namespace LinkDev.Talabat.Application.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }



        public async Task<Pagination<ProductToReturnDto>> GetAllProductsAsync(ProudctSpacficationParams spec)
        {
            var specs= new ProudctWithBrandAndCategorySpacefications(spec.Sort  ,spec.BrandId,spec.CategoryId,spec.PageIndex,spec.PageSize,spec.Search);
            var Products= await unitOfWork.GetRepository<Product,int>().GetAllWithSpecsAsync(specs);

            var totalItemsSpecs = new ProudctWithBrandAndCategorySpacefications(spec.BrandId, spec.CategoryId, spec.Search);   //(spec.BrandId,spec.CategoryId,spec.Search);
            var count= await unitOfWork.GetRepository<Product,int>().GetCountAsync(totalItemsSpecs);

            var data=mapper.Map<IEnumerable<ProductToReturnDto>>(Products);
            return new Pagination<ProductToReturnDto>(

                 spec.PageIndex,
                 spec.PageSize
                 ,count
                )
            { Data=data };
            
        }



        public async Task<ProductToReturnDto> GetProductAsync(int id)
        {
            var specs = new ProudctWithBrandAndCategorySpacefications(id);
            var Products = await unitOfWork.GetRepository<Product, int>().GetByIdWithSpecsAsync(specs);

            if(Products == null)
                throw new NotFoundException(nameof(Product), id);

            var ProductToReturn = mapper.Map<ProductToReturnDto>(Products);
            return ProductToReturn;

        }

        public async Task<IEnumerable<BrandDto>> GetBrandsAsync()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            var brandsToReturn = mapper.Map<IEnumerable<BrandDto>>(brands);
            return brandsToReturn;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories =await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();

            var categoriesToReturn = mapper.Map<IEnumerable<CategoryDto>>(categories);
            return categoriesToReturn;
        }

      
    }
}
