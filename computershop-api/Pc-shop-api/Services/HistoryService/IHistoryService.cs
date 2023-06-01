using computershopAPI.Dtos.CartDtos;
using computershopAPI.Repository;

namespace computershopAPI.Services.HistoryService
{
    public interface IHistoryService
    {
        Task<HistoryPriceDto> Purchase(string id);
        Task<HistoryPriceDto> GetHistory(string id);

    }
}
