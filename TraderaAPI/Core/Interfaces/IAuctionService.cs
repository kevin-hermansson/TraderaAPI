using TraderaAPI.DTOs;

namespace TraderaAPI.Core.Interfaces
{
    public interface IAuctionService
    {
        Task<AuctionDto> CreateAsync(AuctionCreateDto dto);
        Task<List<AuctionDto>> GetOpenAsync();
        Task<AuctionDto?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int auctionId, int userId);
        Task<bool> UpdateAsync(int auctionId, AuctionUpdateDto dto);
    }
}
