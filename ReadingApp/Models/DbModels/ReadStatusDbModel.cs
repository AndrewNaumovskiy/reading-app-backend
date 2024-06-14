using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels
{
    [Table("read_statuses")]
    public class ReadStatusDbModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
