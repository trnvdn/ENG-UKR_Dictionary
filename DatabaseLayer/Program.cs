using System;
using System.Data.SQLite;

namespace DatabaseLayer;

class Program
{
    public static void Main(string[] args)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
        }
    }
}