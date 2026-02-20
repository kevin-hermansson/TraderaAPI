using System.Runtime.InteropServices.Marshalling;

namespace TraderaAPI.DTOs
{
    public class BidDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int AuctionId { get; set; }

    }
}
