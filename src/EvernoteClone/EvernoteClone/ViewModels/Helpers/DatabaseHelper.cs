using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModels.Helpers
{
    public static class DatabaseHelper
    {
        private static readonly string _dbFile = Path.Combine(Environment.CurrentDirectory, "EvernoteClone.sqlite");
        private static readonly SQLiteConnectionString options = new(_dbFile, false);



        public static bool Insert<T>(T item)
        {
            var rowsAdded = 0;
            CallActionInDbContext<T>(c => rowsAdded = c.Insert(item));
            return rowsAdded > 0;
        }

        public static bool Update<T>(T item)
        {
            var rowsUpdated = 0;
            CallActionInDbContext<T>(c => rowsUpdated = c.Update(item));
            return rowsUpdated > 0;
        }

        public static bool Delete<T>(T item)
        {
            var rowsDeleted = 0;
            CallActionInDbContext<T>(c => rowsDeleted = c.Delete(item));
            return rowsDeleted > 0;
        }

        public static List<T> Read<T>() where T : new()
        {
            List<T> items = new();
            CallActionInDbContext<T>(c => items = c.Table<T>().ToList());
            return items;
        }

        private static void CallActionInDbContext<T>(Action<SQLiteConnection> action)
        {
            using var connection = new SQLiteConnection(options);
            connection.CreateTable<T>();
            action(connection);
        }
    }
}
