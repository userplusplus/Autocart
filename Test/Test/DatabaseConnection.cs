namespace Test
{
    public interface DatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();

        //dont use async SQLite.SQLiteAsyncConnection DbConnection();
    }
}