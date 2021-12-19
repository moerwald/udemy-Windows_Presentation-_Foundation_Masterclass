using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactApp.Database
{
    internal static class DbPath
    {
        public static string Get()
        {
            var dbName = "Contacts.db";
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var dbPath = System.IO.Path.Combine(filePath, dbName);
            return dbPath;
        }

    }
}
