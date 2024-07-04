using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels
{
    [Table("user_rates")]
    public class UserRateDbModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int Score { get; set; }
        public int StatusId { get; set; }
        public int PagesRead { get; set; }
        public int PagesCount { get; set; }
        public int Rereads { get; set; }
        public string Thoughts { get; set; }

        public UserDbModel User { get; set; }
        public BookDbModel Book { get; set; }
        public ReadStatusDbModel ReadStatus { get; set; }
    }
}
