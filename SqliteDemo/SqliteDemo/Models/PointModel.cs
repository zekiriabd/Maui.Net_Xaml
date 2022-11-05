using SQLite;

namespace SqliteDemo.Models
{
    public class PointModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal Point { get; set; }
    }
}
