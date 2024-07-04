using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels
{
    [Table("book_comments")]
    public class BookCommentDbModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public BookDbModel Book { get; set; }
        public UserDbModel User { get; set; }
    }
}
