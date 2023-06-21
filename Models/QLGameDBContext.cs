using System;
using Microsoft.EntityFrameworkCore;
using NetCRUD2.Models;
namespace NetCRUD2.Models
{
    public class QLGameDBContext : DbContext
    {
        public QLGameDBContext(DbContextOptions<QLGameDBContext> options) : base(options) { }

        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<LoaiGame> LoaiGames { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SanPham>().ToTable("SanPham");
            modelBuilder.Entity<Account>().ToTable("Account");
            modelBuilder.Entity<LoaiGame>().ToTable("LoaiGame");
        }
    }
}
