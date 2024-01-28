using Jop_Portal.Models;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace Jop_Portal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<Account> Account { get; set; }
        //public DbSet<AccountAndOffersFavouritList> AccountAndOffersFavouritList { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AccountAndOffersFavouritList>()
                .HasKey(a => new { a.UserId, a.OfferId });

        modelBuilder.Entity<Account>()
          .HasOne(A => A.User)
          .WithOne()
          .HasForeignKey<Account>(A => A.Id)
          .OnDelete(DeleteBehavior.Cascade);
        }*/

    }

}