using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels
{
    [Table("session_actions")]
    public class SessionActionDbModel
    {
        public int Id { get; set; }
        public int SessionId { get; set; }
        public string Status { get; set; } // started, finished
        public DateTime Started { get; set; }
        public DateTime? Finished { set; get; }

        public SessionDbModel Session { get; set; }
    }
}
