using Microsoft.EntityFrameworkCore;
using Store.Route.Core.Services.Contract;
using Store.Route.Core;
using Store.Route.Repository;
using Store.Route.Repository.Data.Contexts;
using Store.Route.Service.Services.Products;
using Store.Route.Core.Mapping.Products;
using Microsoft.AspNetCore.Mvc;
using Store.Route.APIs.Errors;

namespace Store.Route.APIs.Helper
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddDependancy(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddBuiltInService();
            services.AddSwaggerService();
            services.AddDbContextService(configuration); 
            services.AddUserDefinedService();
            services.AddAutoMapperService(configuration);
            services.AddInvalidModelStateResponseService();

            return services;
        }
        private static IServiceCollection AddBuiltInService(this IServiceCollection services)
        {

            services.AddControllers();


            return services;
        }

        private static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            return services;
        }

        private static IServiceCollection AddDbContextService(this IServiceCollection services , IConfiguration configuration)
        {

            services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            return services;
        }

        private static IServiceCollection AddUserDefinedService(this IServiceCollection services)
        {

            services.AddScoped<IproductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitWork>();

            return services;
        }

        private static IServiceCollection AddAutoMapperService(this IServiceCollection services , IConfiguration configuration)
        {

            services.AddAutoMapper(m => m.AddProfile(new ProductProfile(configuration)));


            return services;
        }

        private static IServiceCollection AddInvalidModelStateResponseService(this IServiceCollection services)
        {

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (ActionContext) =>
                {
                    var errors = ActionContext.ModelState.Where(P => P.Value != null)
                      .SelectMany(P => P.Value.Errors)
                      .Select(E => E.ErrorMessage)
                      .ToArray();

                    var Response = new ApiValidationErrorReponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(Response);
                };
            });

            return services;
        }

    }
}
