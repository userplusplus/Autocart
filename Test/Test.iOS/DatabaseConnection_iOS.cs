using SQLite;
using System;
using System.IO;

namespace Test.iOS
{
    internal class DatabaseConnection_iOS : DatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            //var dbName = "AutocartDB.db3";
            var dbName = "AutocartDB.db";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", dbName);
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}