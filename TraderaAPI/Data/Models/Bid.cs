namespace TraderaAPI.Data.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public Decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int AuctionId { get; set; }
        public Auction Auction { get; set; } = null!;
    }
}
