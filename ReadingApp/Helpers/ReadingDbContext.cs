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
        //public DbSet<GenreDbModel> Genres { get; set; }
        //public DbSet<CategorieDbModel> Categories { get; set; }


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

            //modelBuilder.Entity<BookDbModel>()
            //    .HasOne(b => b.Genre)
            //    .WithMany(g => g.Books)
            //    .HasForeignKey(b => b.GenreId);
            //
            //modelBuilder.Entity<BookDbModel>()
            //    .HasOne(b => b.Category)
            //    .WithMany(c => c.Books)
            //    .HasForeignKey(b => b.CategoryId);
        }
    }
}
