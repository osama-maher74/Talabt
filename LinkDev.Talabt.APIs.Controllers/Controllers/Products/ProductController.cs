using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinkDev.Talabat.APIs.Controllers.Base;
using LinkDev.Talabat.Application.Abstraction.Common;
using LinkDev.Talabat.Application.Abstraction.Models.Products;
using LinkDev.Talabat.Application.Abstraction.Services;
using LinkDev.Talabt.APIs.Controllers.Erorrs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabt.APIs.Controllers.Controllers.Products
{
    public class ProductController : BaseApiController
    {
        private readonly IServiceManger serviceManger;

        public ProductController(IServiceManger serviceManger)
        {
            this.serviceManger = serviceManger;
        }
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetAllProducts([FromQuery]ProudctSpacficationParams spec)

        {
            var products = await serviceManger.ProductService.GetAllProductsAsync(spec);
            return Ok(products);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProductById(int id)
        {
            var product = await serviceManger.ProductService.GetProductAsync(id);
           
            return Ok(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllProductBrands()
        {
            var brands = await serviceManger.ProductService.GetBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllProductCategories()
        {
            var categories = await serviceManger.ProductService.GetCategoriesAsync();
            return Ok(categories);
        }
       

    }
}
