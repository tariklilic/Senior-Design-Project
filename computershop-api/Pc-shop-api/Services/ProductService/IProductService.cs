using computershopAPI.Dtos.ProductDtos;
using computershopAPI.Models;

namespace computershopAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<List<GetProductsDto>>> GetProducts();
        Task<ServiceResponse<List<GetProductsDto>>> AddProduct(AddProductDto newProduct);
        Task<ServiceResponse<GetProductsDto>> GetProductById(int id);
        Task<ServiceResponse<List<GetProductsDto>>> DeleteProduct(int id);   
    }
}
