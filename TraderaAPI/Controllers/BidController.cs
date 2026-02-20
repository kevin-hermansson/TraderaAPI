using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraderaAPI.Core.Interfaces;
using TraderaAPI.DTOs;

namespace TraderaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(BidCreateDto dto)
        {
            var result = await _bidService.CreateAsync(dto);

            if (result == null)
                return BadRequest("Invalid bid");

            return Ok(result);
        }

        [HttpGet("{auctionId}")]
        public async Task<IActionResult> GetByAuction(int auctionId)
        {
            var result = await _bidService.GetByAuctionAsync(auctionId);
            return Ok(result);
        }

    }
}
