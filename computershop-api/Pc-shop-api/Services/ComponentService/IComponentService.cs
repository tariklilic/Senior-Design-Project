

using computershopAPI.Dtos.ComponentDtos;

namespace computershopAPI.Services.ComponentService
{
    public interface IComponentService
    {
        Task<ServiceResponse<List<GetComponentDto>>> GetComponents();
        Task<ServiceResponse<GetComponentDto>> GetComponentById(int id);

    }
}
