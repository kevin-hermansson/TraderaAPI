using TraderaAPI.Core.Interfaces;
using TraderaAPI.Data.Interfaces;
using TraderaAPI.Data.Models;
using TraderaAPI.DTOs;

namespace TraderaAPI.Core.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepo _auctionRepo;

        public AuctionService(IAuctionRepo auctionRepo)
        {
            _auctionRepo = auctionRepo;
        }

        public async Task<AuctionDto> CreateAsync(AuctionCreateDto dto)
        {
            var auction = new Auction
            {
                Title = dto.Title,
                Description = dto.Description,
                StartPrice = dto.StartPrice,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                UserId = dto.UserId
            };

            var created = await _auctionRepo.AddAsync(auction);

            return new AuctionDto 
            {
                Id = created.Id,
                Title = created.Title,
                Description = created.Description,
                StartPrice = created.StartPrice,
                StartDate = created.StartDate,
                EndDate= created.EndDate,
                UserId = created.UserId
            };
        }

        public async Task<AuctionDto?> GetByIdAsync(int id)
        {
            var auction = await _auctionRepo.GetByIdAsync(id);

            if (auction == null)
                return null;

            return new AuctionDto
            {
                Id = auction.Id,
                Title= auction.Title,
                Description= auction.Description,
                StartPrice = auction.StartPrice,
                StartDate= auction.StartDate,
                EndDate = auction.EndDate,
                UserId = auction.UserId
            };
        }

        public async Task<List<AuctionDto>> GetOpenAsync()
        {
            var auctions = await _auctionRepo.GetOpenAuctionsAsync();

            return auctions.Select(a => new AuctionDto
            {
                Id= a.Id,
                Title = a.Title,
                Description = a.Description,
                StartPrice = a.StartPrice,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                UserId= a.UserId
            }).ToList();
        }
    }
}
