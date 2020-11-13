using FluentValidation;
using Kerberos.Business.Concrete;
using Kerberos.Business.Interfaces;
using Kerberos.DataAccess.Interfaces;
using Kerberos.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Kerberos.DataTransferObject;
using Kerberos.DataTransferObject.Validators;

namespace Kerberos.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddServiceCollectionExtension(this IServiceCollection services)
        {
            // generic şekilde ekleme
            services.AddScoped(typeof(IBaseService<>),typeof(BaseManager<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppRoleRepository, AppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserRoleRepository, AppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddTransient<IValidator<ProductDto>, ProductValidator>();
            services.AddTransient<IValidator<AppUserLoginDto>, AppUserValidator>();
            services.AddScoped<IJwtService, JwtManager>();
        }
    }
}
