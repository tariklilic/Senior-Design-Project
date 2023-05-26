using Microsoft.AspNetCore.Mvc;
using computershopAPI.Services.ProductService;
using computershopAPI.Dtos.ProductDtos;
using AutoMapper;

namespace computershopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;


        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productService.GetProducts());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProductDto newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await _productService.DeleteProduct(id));
        }
    }
}
