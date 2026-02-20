using Microsoft.AspNetCore.Mvc;
using TraderaAPI.Core.Interfaces;
using TraderaAPI.DTOs;

[ApiController]
[Route("api/[controller]")]
public class AuctionController : ControllerBase
{
    private readonly IAuctionService _auctionService;

    public AuctionController(IAuctionService auctionService)
    {
        _auctionService = auctionService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(AuctionCreateDto dto)
    {
        var result = await _auctionService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpGet("open")]
    public async Task<IActionResult> GetOpen()
    {
        var result = await _auctionService.GetOpenAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _auctionService.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}