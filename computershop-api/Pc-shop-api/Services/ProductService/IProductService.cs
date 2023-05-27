using computershopAPI.Dtos.ProductDtos;
using computershopAPI.Helper;
using computershopAPI.Models;

namespace computershopAPI.Services.ProductService
{
    public interface IProductService
    {
        Task<PaginationResponse> GetProducts(int page);
        Task<ServiceResponse<List<GetProductsDto>>> AddProduct(AddProductDto newProduct);
        Task<ServiceResponse<GetProductsDto>> GetProductById(int id);
        Task<ServiceResponse<List<GetProductsDto>>> DeleteProduct(int id);
        Task<PaginationResponse> GetProductsSorted(int componentId, string? searchName, string? sort, int? priceLowest, int? priceHighest, int page);
    }
}
