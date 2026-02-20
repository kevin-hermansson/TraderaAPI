using Microsoft.EntityFrameworkCore;
using TraderaAPI.Data.Interfaces;
using TraderaAPI.Data.Models;

namespace TraderaAPI.Data.Repos
{
    public class AuctionRepo : IAuctionRepo
    {
        private readonly TraderaDbContext _db;

        public AuctionRepo(TraderaDbContext db)
        {
            _db = db;
        }

        public async Task<Auction> AddAsync(Auction auction)
        {
            _db.Auctions.Add(auction);
            await _db.SaveChangesAsync();
            return auction;
        }

        public async Task<Auction?> GetByIdAsync(int id)
        {
            return await _db.Auctions
                .Include(a => a.Bids)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Auction>> GetOpenAuctionsAsync()
        {
            return await _db.Auctions
                .Where(a => a.EndDate > DateTime.Now)
                .ToListAsync();
        }
    }
}
