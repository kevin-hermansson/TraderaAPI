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
                EndDate = dto.EndDate,
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
                EndDate = created.EndDate,
                UserId = created.UserId
            };
        }

        public async Task<AuctionDto?> GetByIdAsync(int id)
        {
            var auction = await _auctionRepo.GetByIdAsync(id);

            if (auction == null)
                return null;

            decimal currentPrice;

            if (auction.Bids != null && auction.Bids.Count > 0)
            {
                var highest = auction.Bids
                    .OrderByDescending(b => b.Amount)
                    .First();

                currentPrice = highest.Amount;
            }
            else
            {
                currentPrice = auction.StartPrice;
            }

            return new AuctionDto
            {
                Id = auction.Id,
                Title = auction.Title,
                Description = auction.Description,
                StartPrice = auction.StartPrice,
                CurrentPrice = currentPrice,
                StartDate = auction.StartDate,
                EndDate = auction.EndDate,
                UserId = auction.UserId
            };
        }

        public async Task<List<AuctionDto>> GetOpenAsync()
        {
            var auctions = await _auctionRepo.GetOpenAuctionsAsync();

            var result = new List<AuctionDto>();

            foreach (var auction in auctions)
            {
                decimal currentPrice;

                if (auction.Bids != null && auction.Bids.Count > 0)
                {
                    var highest = auction.Bids.OrderByDescending(b => b.Amount).First();

                    currentPrice = highest.Amount;
                }
                else
                {
                    currentPrice = auction.StartPrice;
                }


                var dto = new AuctionDto
                {
                    Id = auction.Id,
                    Title = auction.Title,
                    Description = auction.Description,
                    StartPrice = auction.StartPrice,
                    CurrentPrice = currentPrice,
                    StartDate = auction.StartDate,
                    EndDate = auction.EndDate,
                    UserId = auction.UserId
                };

                result.Add(dto);
            }
            return result;

        }

        public async Task<bool> DeleteAsync(int auctionId, int userId)
        {
            var auction = await _auctionRepo.GetByIdAsync(auctionId);

            if (auction == null)
                return false;

            if (auction.UserId != userId)
                return false;

            if (auction.Bids != null && auction.Bids.Count > 0)
                return false;

            return await _auctionRepo.DeleteAsync(auction);
        }

        public async Task<bool> UpdateAsync(int auctionId, AuctionUpdateDto dto)
        {
            var auction = await _auctionRepo.GetByIdAsync(auctionId);

            if (auction == null)
                return false;
            if (auction.UserId != dto.UserId)
                return false;

            auction.Title = dto.Title;
            auction.Description = dto.Description;
            auction.EndDate = dto.EndDate;

            if (auction.Bids == null || auction.Bids.Count == 0)
            {
                auction.StartPrice = dto.StartPrice;
            }

            return await _auctionRepo.UpdateAsync(auction);
        }

    }
}
