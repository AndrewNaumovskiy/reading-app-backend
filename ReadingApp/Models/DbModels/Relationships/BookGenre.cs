using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels.Relationships
{
    [Table("book_genre")]
    public class BookGenre
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int GenreId { get; set; }
    }
}
