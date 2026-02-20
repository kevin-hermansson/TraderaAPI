using TraderaAPI.Core.Interfaces;
using TraderaAPI.Data.Interfaces;
using TraderaAPI.Data.Models;
using TraderaAPI.DTOs;

namespace TraderaAPI.Core.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepo _bidRepo;
        private readonly IAuctionRepo _auctionRepo;

        public BidService(IBidRepo bidRepo, IAuctionRepo auctionRepo)
        {
            _bidRepo = bidRepo;
            _auctionRepo = auctionRepo;
        }

        public async Task<BidDto?> CreateAsync(BidCreateDto dto)
        {
            var auction = await _auctionRepo.GetByIdAsync(dto.AuctionId);

            if (auction == null) return null; 
            if (auction.UserId == dto.UserId) return null;
            if (auction.EndDate <= DateTime.Now) return null;


            var highestBid = await _bidRepo.GetHighestBidAsync(dto.AuctionId);

            decimal minAmount;

            if (highestBid != null)
            {
                minAmount = highestBid.Amount;
            }
            else
            {
                minAmount = auction.StartPrice;
            }

            if (dto.Amount <= minAmount) return null;

            var bid = new Bid
            {
                Amount = dto.Amount,
                Date = DateTime.Now,
                UserId = dto.UserId,
                AuctionId = dto.AuctionId
            };


            var created = await _bidRepo.AddAsync(bid);

            return new BidDto
            {
                Id = created.Id,
                Amount = created.Amount,
                Date = created.Date,
                UserId= created.UserId,
                AuctionId= created.AuctionId
            };

        }

        public async Task<List<BidDto>> GetByAuctionAsync(int auctionId)
        {
            var bids = await _bidRepo.GetByAuctionIdAsync(auctionId);

            return bids.Select(b => new BidDto
            {
                Id = b.Id,
                Amount = b.Amount,
                Date = b.Date,
                UserId = b.UserId,
                AuctionId = b.AuctionId
            }).ToList();
        }
    }
}
