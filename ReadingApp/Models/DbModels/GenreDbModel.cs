using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels
{
    [Table("genres")]
    public class GenreDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
