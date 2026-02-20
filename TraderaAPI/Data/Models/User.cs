namespace TraderaAPI.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;

        public ICollection<Auction> Auctions { get; set; } = new List<Auction>();
        public ICollection<Bid> Bids { get; set; } = new List<Bid>();
    }
}
