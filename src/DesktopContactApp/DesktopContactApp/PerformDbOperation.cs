using DesktopContactApp.Model;
using SQLite;
using System;

namespace DesktopContactApp
{
    internal static class PerformDbOperation
    {
        public static void Perform(Action<SQLiteConnection> action)
        {
            using var connection = new SQLiteConnection(Database.DbPath.Get());
            connection.CreateTable<Contact>();
            action(connection);
        }
    }
}
