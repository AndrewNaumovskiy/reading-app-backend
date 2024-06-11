using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels.Relationships
{
    [Table("book_category")]
    public class BookCategory
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }
    }
}
