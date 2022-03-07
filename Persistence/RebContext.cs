using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class RebContext : DbContext
{
    public RebContext(DbContextOptions options): base(options){

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>()
        .HasMany(c=>c.Products)
        .WithOne(p=> p.Category)
        .OnDelete(DeleteBehavior.Cascade);
    }
    public DbSet<Category> Categories {get; set; }
    public DbSet<Product> Products {get; set; }
    public DbSet<Client> Clients {get; set; }
    public DbSet<DetailsBill> DetailsBills {get; set; }
    public DbSet<Bill> Bills { get; set; }

}
