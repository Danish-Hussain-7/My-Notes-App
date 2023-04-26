using System;
using SQLite;

namespace Notes.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string ImagePath { get; set; }

        public byte[] Image { get; set; }
        public string ImageName { get; set; }
    }
}
