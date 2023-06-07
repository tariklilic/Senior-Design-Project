using AutoMapper;
using computershopAPI.Data;
using computershopAPI.Dtos.ProductDtos;
using computershopAPI.Helper;
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
                .Include(x => x.Images)
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
                    .Include(x => x.Images)
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
                .Include(x => x.Images)
                .FirstOrDefaultAsync(a => a.Id == id);

            serviceResponse.Data = _mapper.Map<GetProductsDto>(dbProducts);

            return serviceResponse;
        }

        public async Task<Product> GetProductByIdModel(int id)
        {
            var dbProducts = await _context.Products
                .Include(x => x.Images)
                .FirstOrDefaultAsync(a => a.Id == id);


            return dbProducts;
        }

        public Task<PaginationResponse> GetProducts(int page)
        {
            IQueryable<Product> products = _context.Products.Include(x => x.Images).Where(a => a.Quantity > 0);

            var pageResults = 10f;
            var pageCount = Math.Ceiling(products.Count() / pageResults);
            products = products
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults);

            var paginationResponse = new PaginationResponse
            {
                Products = _mapper.Map<List<GetProductsDto>>(products),
                CurrentPage = page,
                Pages = (int)pageCount
            };


            return Task.FromResult(paginationResponse);
        }

        public Task<PaginationResponse> GetProductsSorted(int componentId, string? searchName, string? sort, int? priceLowest, int? priceHighest, int page)
        {

            if (priceHighest == null) priceHighest = 10000;
            if (priceLowest == null) priceLowest = 0;

            IQueryable<Product> products;

            if (componentId == 0)
            {
                products = _context.Products.Include(x => x.Images)
                .Where(a => a.Price >= priceLowest && a.Price <= priceHighest && a.Quantity > 0);
            }
            else
            {
                products = _context.Products.Include(x => x.Images)
                .Where(a => a.ComponentId == componentId && a.Price >= priceLowest && a.Price <= priceHighest && a.Quantity > 0);
            }

            if (searchName != null) products = products.Where(s => s.Name.ToLower().Contains(searchName.ToLower()));
            switch (sort)
            {
                case "ratingDesc":
                    products = products.OrderByDescending(a => a.Rating);
                    break;
                case "ratingAsc":   
                    products = products.OrderBy(a => a.Id);
                    break;
                case "priceDesc":
                    products = products.OrderByDescending(a => a.Price);
                    break;
                case "priceAsc":
                    products = products.OrderBy(a => a.Price);
                    break;
                case "nameDesc":
                    products = products.OrderByDescending(a => a.Name);
                    break;
                default:
                    products = products.OrderBy(a => a.Name);
                    break;
                
            }

            var pageResults = 10f;
            var pageCount = Math.Ceiling(products.Count() / pageResults );
            products = products
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults);

            var paginationResponse = new PaginationResponse
            {
                Products = _mapper.Map<List<GetProductsDto>>(products),
                CurrentPage = page,
                Pages = (int)pageCount
            };
            return Task.FromResult(paginationResponse);

        }
    }
}
