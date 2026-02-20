using TraderaAPI.DTOs;

namespace TraderaAPI.Core.Interfaces
{
    public interface IBidService
    {
        Task<BidDto?> CreateAsync(BidCreateDto dto);
        Task<List<BidDto>> GetByAuctionAsync(int auctionId);
    }
}
