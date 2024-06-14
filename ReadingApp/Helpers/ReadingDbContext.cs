using ReadingApp.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using ReadingApp.Models.DbModels.Relationships;

namespace ReadingApp.Helpers
{
    public class ReadingDbContext : DbContext
    {
        public DbSet<UserDbModel> Users { get; set; }

        public DbSet<UserRateDbModel> UserRates { get; set; }

        public DbSet<BookDbModel> Books { get; set; }
        public DbSet<AuthorDbModel> Authors { get; set; }
        public DbSet<CategoryDbModel> Categories { get; set; }
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
                    l => l.HasOne<CategoryDbModel>().WithMany().HasForeignKey(x => x.CategoryId),
                    r => r.HasOne<BookDbModel>().WithMany().HasForeignKey(x => x.BookId)
                );

            modelBuilder.Entity<BookDbModel>()
                .HasMany(x => x.Genres)
                .WithMany(x => x.Books)
                .UsingEntity<BookCategory>
                (
                    l => l.HasOne<GenreDbModel>().WithMany().HasForeignKey(x => x.CategoryId),
                    r => r.HasOne<BookDbModel>().WithMany().HasForeignKey(x => x.BookId)
                );

            modelBuilder.Entity<BookDbModel>()
                .HasOne(x => x.Rating)
                .WithMany()
                .HasForeignKey(x => x.RatingId);

            modelBuilder.Entity<BookDbModel>()
                .HasMany(x => x.UserRates)
                .WithOne(x => x.Book)
                .HasForeignKey(x => x.BookId);



            modelBuilder.Entity<UserDbModel>()
                .HasMany(x => x.UserRates)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);



            modelBuilder.Entity<UserRateDbModel>()
                .HasOne(x => x.ReadStatus)
                .WithMany()
                .HasForeignKey(x => x.StatusId);



            modelBuilder.Entity<SessionDbModel>()
                .HasOne(x => x.User)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<SessionDbModel>()
                .HasMany(x => x.Actions)
                .WithOne(x => x.Session)
                .HasForeignKey(x => x.SessionId);
        }
    }
}
