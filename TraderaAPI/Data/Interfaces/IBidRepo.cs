using TraderaAPI.Data.Models;

namespace TraderaAPI.Data.Interfaces
{
    public interface IBidRepo
    {
        Task<Bid> AddAsync(Bid bid);
        Task<List<Bid>> GetByAuctionIdAsync(int auctionId);
        Task<Bid?> GetHighestBidAsync(int auctionId);
    }
}
