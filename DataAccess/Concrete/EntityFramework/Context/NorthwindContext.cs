using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Context;

public class NorthwindContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=94.73.170.5;Database=u0642966_Deneme;user=u0642966_Zeynel2;password=ZWpo83M9XUwh20X");
    }

    public DbSet<Product>? Products { get; set; }    
    public DbSet<Category>? Categories { get; set; }    
}