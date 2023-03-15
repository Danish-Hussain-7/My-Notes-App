using System;
using SQLite;

namespace Notes.Models
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

        public DateTime Date { get; set; }
    }
}
