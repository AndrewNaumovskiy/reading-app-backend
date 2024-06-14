using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels
{
    [Table("categories")]
    public class CategoryDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<BookDbModel> Books { get; set; } = [];
    }
}
