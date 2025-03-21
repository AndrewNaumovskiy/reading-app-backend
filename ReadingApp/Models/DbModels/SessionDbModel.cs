﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels
{
    [Table("sessions")]
    public class SessionDbModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public string Status { get; set; } // started, paused, finished

        public UserDbModel User { get; set; }
        public List<SessionActionDbModel> Actions { get; set; } = [];
    }
}
