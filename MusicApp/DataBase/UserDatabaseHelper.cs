using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.DataBase
{
   public class UserDatabaseHelper
    {
      

        public async void AddUser(UserTable user)
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("user.db");
            await connection.InsertAsync(user);
        }

        public async Task<bool> CheckLogin(string email, string pass)
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("user.db");
            var resul = await connection.Table<UserTable>().Where(x => x.EmailID == email && x.Password == pass).FirstOrDefaultAsync();
            if (resul != null)
                return true;
            return false;
        }

        public async Task<bool> CheckAvailable(string email)
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("user.db");
            var resul = await connection.Table<UserTable>().Where(x => x.EmailID == email).FirstOrDefaultAsync();
            if (resul != null)
                return true;
            return false;
        }

        public async Task DropDatabase()
        {
            SQLiteAsyncConnection connection = new SQLiteAsyncConnection("user.db");
            await connection.DropTableAsync<UserTable>();
            await connection.CreateTableAsync<UserTable>();
        }
    }
}
