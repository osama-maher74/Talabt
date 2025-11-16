
using AutoMapper;
using LinkDev.Talabat.Application.Abstraction.Services;
using LinkDev.Talabat.Application.Abstraction.Services.Auth;
using LinkDev.Talabat.Application.Abstraction.Services.Basket;
using LinkDev.Talabat.Application.Abstraction.Services.Products;
using LinkDev.Talabat.Application.Services.Auth;
using LinkDev.Talabat.Application.Services.Baskets;
using LinkDev.Talabat.Application.Services.Products;
using LinkDev.Talabat.Domain.Contracts.Presistance;
using Microsoft.Extensions.Configuration;

namespace LinkDev.Talabat.Application.Services
{
    public class ServiceManger : IServiceManger 
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly Lazy<IProductService> productService;
        private readonly Lazy<IBasketServics> basketService;
        private readonly Lazy<IAuthService> authService;
        public ServiceManger(IUnitOfWork unitOfWork,
            IMapper mapper,
             Func<IBasketServics> basketServiceFactory,
             Func<IAuthService> authServiceFactory)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
           
            productService = new Lazy<IProductService>(() => new ProductService(unitOfWork, mapper));
            basketService = new Lazy<IBasketServics>(basketServiceFactory,LazyThreadSafetyMode.ExecutionAndPublication);
            authService = new Lazy<IAuthService>(authServiceFactory,LazyThreadSafetyMode.ExecutionAndPublication);
        }
        public IProductService ProductService => productService.Value;

        public IBasketServics BasketServics => basketService.Value;

        public IAuthService AuthService => authService.Value;
    }
}
