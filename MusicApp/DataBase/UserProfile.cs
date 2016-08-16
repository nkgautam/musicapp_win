

using SQLite;

namespace MusicApp.DataBase
{
    [Table("UserTable")]
    public class UserTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string EmailID { get; set; }
        public string Password { get; set; }
    }


    [Table("RecordTable")]
    public class RecordTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string EmailID { get; set; }
        public string Instrument { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
    }
}
