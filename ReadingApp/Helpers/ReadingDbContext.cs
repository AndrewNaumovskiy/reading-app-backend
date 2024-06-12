using ReadingApp.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using ReadingApp.Models.DbModels.Relationships;

namespace ReadingApp.Helpers
{
    public class ReadingDbContext : DbContext
    {
        public DbSet<UserDbModel> Users { get; set; }


        public DbSet<BookDbModel> Books { get; set; }
        public DbSet<AuthorDbModel> Authors { get; set; }
        public DbSet<CategorieDbModel> Categories { get; set; }
        //public DbSet<GenreDbModel> Genres { get; set; }

        
        public DbSet<SessionDbModel> Sessions { get; set; }

        public ReadingDbContext(DbContextOptions<ReadingDbContext> options) : base(options) { }

        protected override async void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDbModel>()
                .HasMany(x => x.Authors)
                .WithMany(x => x.Books)
                .UsingEntity<BookAuthor>
                (
                    l => l.HasOne<AuthorDbModel>().WithMany().HasForeignKey(x => x.AuthorId),
                    r => r.HasOne<BookDbModel>().WithMany().HasForeignKey(x => x.BookId)
                );

            modelBuilder.Entity<BookDbModel>()
                .HasMany(x => x.Categories)
                .WithMany(x => x.Books)
                .UsingEntity<BookCategory>
                (
                    l => l.HasOne<CategorieDbModel>().WithMany().HasForeignKey(x => x.CategoryId),
                    r => r.HasOne<BookDbModel>().WithMany().HasForeignKey(x => x.BookId)
                );
        }
    }
}
