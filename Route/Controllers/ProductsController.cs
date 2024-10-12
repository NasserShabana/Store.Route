using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Route.APIs.Errors;
using Store.Route.Core.Dtos.Products;
using Store.Route.Core.Helper;
using Store.Route.Core.Services.Contract;
using Store.Route.Core.Specifications.Products;

namespace Store.Route.APIs.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IproductService _productService;

        public ProductsController(IproductService iproductService)
        {
            _productService = iproductService;
        }

        [ProducesResponseType(typeof(PaginationRespone<ProductDto> ),StatusCodes.Status200OK)]
        [HttpGet] // Get BaseUrl/api/Products ? Sort { Name ,PriceAsc , PriceDesc}
        public async Task<ActionResult<PaginationRespone<ProductDto>>> GetAllProducts([FromQuery] ProductSpecParams productSpec )  // EndPoint
        {
        var result =   await  _productService.GetAllProductsAsync(productSpec);
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<TypeBrandDto>), StatusCodes.Status200OK)]
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<TypeBrandDto>>> GetAllBrandsAsync()  // EndPoint
        {
            var result = await _productService.GetAllBrandsAsync();
            return Ok(result);
        }

        [ProducesResponseType(typeof(IEnumerable<TypeBrandDto>), StatusCodes.Status200OK)]
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeBrandDto>>> GetAllTypesAsync()  // EndPoint
        {
            var result = await _productService.GetAllTypesAsync();
            return Ok(result);
        }

        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int? id)  // EndPoint
        {
            if(id is null) return BadRequest(new ApiErrorResponse(400));

            var result = await _productService.GetProductByIdAsync(id.Value);

            if(result is null) return NotFound(new ApiErrorResponse(404));

            return Ok(result);
        }
    }
}
