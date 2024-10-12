using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Route.APIs.Errors;
using Store.Route.Repository.Data.Contexts;

namespace Store.Route.APIs.Controllers
{
    
    public class BuggyController : BaseApiController
    {
        private readonly StoreDbContext _context;

        public BuggyController(StoreDbContext context)
        {
            _context = context;
        } 

        [HttpGet("NotFound")]
        public async Task<IActionResult> GetNotFoundRequestError()
        {
            var product = await _context.Products.FindAsync(-1);
            if (product == null)
                return NotFound(new ApiErrorResponse(404));

            return Ok(product);
        }

        [HttpGet("ServerError")]
        public async Task<IActionResult> GetServerError()
        {
            var product = await _context.Products.FindAsync(-1);
           var producttostring = product.ToString();

            return Ok(producttostring);
        }

        [HttpGet("BadRequest")]
        public async Task<IActionResult> GetBadRequestError()
        { 
                return BadRequest(new ApiErrorResponse(400));
        }

        [HttpGet("BadRequest/{id}")]
        public async Task<IActionResult> GetBadRequestError(int id)
        {
            return BadRequest( );
        }

        [HttpGet("Unauthorized")]
        public async Task<IActionResult> GetUnauthorizedError(int id)
        {
            return Unauthorized(new ApiErrorResponse(401));
        }
    }
}
