using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Route.APIs.Errors;
using Store.Route.APIs.Helper;
using Store.Route.APIs.MiddleWares;
using Store.Route.Core;
using Store.Route.Core.Mapping.Products;
using Store.Route.Core.Services.Contract;
using Store.Route.Repository;
using Store.Route.Repository.Data;
using Store.Route.Repository.Data.Contexts;
using Store.Route.Service.Services.Products;

namespace Route
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
 
            builder.Services.AddDependancy(builder.Configuration);

            var app = builder.Build();


            await app.ConfigureMiddleWareAsync();

            app.Run();

         }
    }
}
