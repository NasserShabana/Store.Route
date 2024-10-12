using Store.Route.APIs.Errors;
using System.Net;
using System.Text.Json;

namespace Store.Route.APIs.MiddleWares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;
        private readonly ILogger<ExceptionMiddleWare> _logger;

        public ExceptionMiddleWare(RequestDelegate next , ILogger<ExceptionMiddleWare> logger , IHostEnvironment env)
        {
            _next = next;
            _env = env;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context) // When Create MiddleWare We Must Have A Method BY Name [InvokeAsync]
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;


                var response =_env.IsDevelopment() ?
                    new ApiExpectionResponse( StatusCodes.Status500InternalServerError  , ex.Message , ex?.StackTrace?.ToString())
                    : new ApiExpectionResponse(StatusCodes.Status500InternalServerError);

                var json = JsonSerializer.Serialize(response); // Data Serialization To Json

 
               await context.Response.WriteAsync(json);
            }
        }
        
    }
}
