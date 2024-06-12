using ReadingApp.Models.DbModels.Relationships;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels
{
    [Table("authors")]
    public class AuthorDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BookDbModel> Books { get; set; } = [];
    }
}
