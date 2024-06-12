using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels.Relationships
{
    [Table("book_author")]
    public class BookAuthor
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
    }
}
