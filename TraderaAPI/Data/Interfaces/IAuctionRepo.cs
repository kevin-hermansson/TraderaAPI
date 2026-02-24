using TraderaAPI.Data.Models;

namespace TraderaAPI.Data.Interfaces
{
    public interface IAuctionRepo
    {
        Task<Auction> AddAsync(Auction auction);
        Task<List<Auction>> GetOpenAuctionsAsync();
        Task<Auction?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(Auction auction);
        Task <bool> UpdateAsync (Auction auction);
    }
}
