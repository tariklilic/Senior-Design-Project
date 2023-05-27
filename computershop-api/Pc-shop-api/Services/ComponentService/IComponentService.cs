

using computershopAPI.Dtos.ComponentDtos;
using computershopAPI.Dtos.ProductDtos;

namespace computershopAPI.Services.ComponentService
{
    public interface IComponentService
    {
        Task<ServiceResponse<List<GetComponentDto>>> GetComponents();
        Task<ServiceResponse<GetComponentDto>> GetComponentById(int id);
        Task<ServiceResponse<List<GetComponentDto>>> AddComponent(AddComponentDto newComponent);
        //public async Task<ServiceResponse<GetComponentDto>> GetComponentSorted(int id, string? search, string? sort);

    }
}
