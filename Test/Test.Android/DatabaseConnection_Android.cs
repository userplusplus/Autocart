using SQLite;
using System.IO;
using Test.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]

namespace Test.Droid
{
    public class DatabaseConnection_Android : DatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            //var dbName = "AutocartDB.db3";
            var dbName = "AutocartDB.db";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}