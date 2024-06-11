﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ReadingApp.Models.DbModels
{
    [Table("users")]
    public class UserDbModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Locale { get; set; }
    }
}
