using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public interface DatabaseConnection
    {
        //SQLite.SQLiteConnection DbConnection();
        SQLite.SQLiteAsyncConnection DbConnection();
    }
}
