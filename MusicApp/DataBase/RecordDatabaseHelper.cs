using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DataBase
{
  public  class RecordDatabaseHelper
    {
        public async Task AddRecord(RecordTable record)
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("record.db");
            await connection.InsertAsync(record);
        }

        public async Task<List<RecordTable>> GetData(string emailID)
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("record.db");
            var resul = await connection.Table<RecordTable>().Where(x => x.EmailID == emailID).ToListAsync();
            return resul;
        }

        public async Task DropDatabase()
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("record.db");
            await connection.DropTableAsync<RecordTable>();
            await connection.CreateTableAsync<RecordTable>();
        }
    }
}
