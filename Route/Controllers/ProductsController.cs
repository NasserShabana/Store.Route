﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Route.Core.Dtos.Products;
using Store.Route.Core.Helper;
using Store.Route.Core.Services.Contract;
using Store.Route.Core.Specifications.Products;

namespace Store.Route.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IproductService _productService;

        public ProductsController(IproductService iproductService)
        {
            _productService = iproductService;
        }

        [HttpGet] // Get BaseUrl/api/Products ? Sort { Name ,PriceAsc , PriceDesc}
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductSpecParams productSpec )  // EndPoint
        {
        var result =   await  _productService.GetAllProductsAsync(productSpec);
            return Ok(result);
        }

        [HttpGet("Brands")]
        public async Task<IActionResult> GetAllBrandsAsync()  // EndPoint
        {
            var result = await _productService.GetAllBrandsAsync();
            return Ok(result);
        }

        [HttpGet("Types")]
        public async Task<IActionResult> GetAllTypesAsync()  // EndPoint
        {
            var result = await _productService.GetAllTypesAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int? id)  // EndPoint
        {
            if(id is null) return BadRequest("Invalid Id");

            var result = await _productService.GetProductByIdAsync(id.Value);

            if(result is null) return NotFound($"The Product Was Not Found {id}");

            return Ok(result);
        }
    }
}
