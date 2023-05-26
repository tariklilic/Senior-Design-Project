using AutoMapper;
using computershopAPI.Data;
using computershopAPI.Dtos.ProductDtos;
using computershopAPI.Models.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace computershopAPI.Services.ProductService

{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProductService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetProductsDto>>> AddProduct(AddProductDto newProduct)
        {
            var serviceResponse = new ServiceResponse<List<GetProductsDto>>();

            Product newProd = _mapper.Map<Product>(newProduct);
            _context.Products.Add(newProd);
            await _context.SaveChangesAsync();
            serviceResponse.Data = await _context.Products
                .Select(a => _mapper.Map<GetProductsDto>(a))
                .ToListAsync();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductsDto>>> DeleteProduct(int id)
        {

            ServiceResponse<List<GetProductsDto>> serviceResponse = new ServiceResponse<List<GetProductsDto>>();

            try
            {
                Product product = await _context.Products
                    .FirstOrDefaultAsync(c => c.Id == id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = _context.Products
                        .Select(c => _mapper.Map<GetProductsDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.Success = false;
                    serviceResponse.Message = "Product not found";
                }


            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetProductsDto>> GetProductById(int id)
        {
            var serviceResponse = new ServiceResponse<GetProductsDto>();

            var dbProducts = await _context.Products
                .FirstOrDefaultAsync(a => a.Id == id);

            serviceResponse.Data = _mapper.Map<GetProductsDto>(dbProducts);

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetProductsDto>>> GetProducts()
        {
            var serviceResponse = new ServiceResponse<List<GetProductsDto>>();

            var dbProducts = await _context.Products
                .ToListAsync();
            serviceResponse.Data = dbProducts.Select(a => _mapper.Map<GetProductsDto>(a))
                .ToList();

            return serviceResponse;
        }


    }
}
