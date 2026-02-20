namespace TraderaAPI.DTOs
{
    public class BidCreateDto
    {
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public int AuctionId { get; set; }
    }
}
