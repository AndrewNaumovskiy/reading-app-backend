using ReadingApp.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace ReadingApp.Helpers
{
    public class ReadingDbContext : DbContext
    {
        public DbSet<UserDbModel> Users { get; set; }

        public ReadingDbContext(DbContextOptions<ReadingDbContext> options) : base(options) { }
    }
}
