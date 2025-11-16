using LinkDev.Talabat.Application.Abstraction.Services.Auth;
using LinkDev.Talabat.Application.Abstraction.Services.Basket;
using LinkDev.Talabat.Application.Abstraction.Services.Products;

namespace LinkDev.Talabat.Application.Abstraction.Services
{
    public interface IServiceManger
    {
        public IProductService ProductService { get; }

        public IBasketServics BasketServics { get; }
        public IAuthService AuthService { get; }

    }
}
    