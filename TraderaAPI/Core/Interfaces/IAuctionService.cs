using TraderaAPI.DTOs;

namespace TraderaAPI.Core.Interfaces
{
    public interface IAuctionService
    {
        Task<AuctionDto> CreateAsync(AuctionCreateDto dto);
        Task<List<AuctionDto>> GetOpenAsync();
        Task<AuctionDto?> GetByIdAsync(int id);
    }
}
