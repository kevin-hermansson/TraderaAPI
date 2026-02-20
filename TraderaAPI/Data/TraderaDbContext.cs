using Microsoft.EntityFrameworkCore;
using TraderaAPI.Data.Models;

namespace TraderaAPI.Data
{
    public class TraderaDbContext : DbContext
    {
        public TraderaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Bid> Bids { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>()
                .Property(a => a.StartPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Bid>()
                .Property(b => b.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Auction)
                .WithMany(a => a.Bids)
                .HasForeignKey(b => b.AuctionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

}
