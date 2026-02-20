namespace TraderaAPI.DTOs
{
    public class AuctionCreateDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal StartPrice { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
    }
}
