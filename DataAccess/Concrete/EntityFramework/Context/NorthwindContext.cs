using Core.Entities.Concrete;
using Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context;

public class NorthwindContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=94.73.150.5;Database=u0642966_Deneme8;user=u0642966_zeynel9;password=w02=1Em-.LRY@nx5");
    }

    public DbSet<Product>? Products { get; set; }    
    public DbSet<Category>? Categories { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
}