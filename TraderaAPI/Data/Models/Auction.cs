namespace TraderaAPI.Data.Models
{
    public class Auction
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal StartPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Bid> Bids { get; set; } = new List<Bid>();


    }
}
