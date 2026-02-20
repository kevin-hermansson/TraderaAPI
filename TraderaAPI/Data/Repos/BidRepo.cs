using TraderaAPI.Data.Interfaces;
using TraderaAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TraderaAPI.Data.Repos
{
    public class BidRepo : IBidRepo
    {
        private readonly TraderaDbContext _db;

        public BidRepo(TraderaDbContext db)
        {
            _db = db;
        }

        public async Task<Bid> AddAsync(Bid bid)
        {
            _db.Bids.Add(bid);
            await _db.SaveChangesAsync();
            return bid;
        }

        public async Task<List<Bid>> GetByAuctionIdAsync(int auctionId)
        {
            return await _db.Bids
                .Where(b => b.AuctionId == auctionId)
                .OrderByDescending(b=> b.Amount)
                .ToListAsync();
        }

        public async Task<Bid?> GetHighestBidAsync(int auctionId)
        {
            return await _db.Bids
                .Where(b => b.AuctionId == auctionId)
                .OrderByDescending(b => b.Amount)
                .FirstOrDefaultAsync();
        }
    }
}
