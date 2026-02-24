namespace TraderaAPI.DTOs
{
    public class AuctionUpdateDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime EndDate { get; set; }
        public decimal StartPrice { get; set; }
        public int UserId { get; set; }
    }
}
