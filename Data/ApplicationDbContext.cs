

using CRUDOperations.Models;

namespace CRUDOperations.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Books)
                .WithOne(b => b.Category)
               .HasForeignKey(b => b.CategoryId);


        modelBuilder.Entity<Category>().HasData(
      new Category { Id = 1, Name = "Electronics", IsActive = true },
      new Category { Id = 2, Name = "Books", IsActive = true },
      new Category { Id = 3, Name = "Clothing", IsActive = true },
      new Category { Id = 4, Name = "Sports", IsActive = true },
      new Category { Id = 5, Name = "Toys", IsActive = true },
      new Category { Id = 6, Name = "Furniture", IsActive = true },
      new Category { Id = 7, Name = "Beauty", IsActive = true },
      new Category { Id = 8, Name = "Food", IsActive = true },
      new Category { Id = 9, Name = "Music", IsActive = true },
      new Category { Id = 10, Name = "Movies", IsActive = true }
  );

        }


        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; } 
    }
}
