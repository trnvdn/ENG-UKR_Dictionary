using Dapper;
using System.Data.SQLite;

namespace DatabaseLayer;

public class AccountRepository
{
    public bool Retrieve(string login)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            var result = connection.Query<Account>("SELECT * FROM Account WHERE Login = @login", new { login }).FirstOrDefault();
            return result != null;
        }
    }

    public int GetPin(string login)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            var result = connection.Query<Account>("SELECT PIN FROM Account WHERE Login = @login", new { login }).FirstOrDefault();
            return result.PIN;
        }
    }
    public Account? Retrieve(Account account)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            Account result = connection.Query<Account>("SELECT * FROM Account WHERE Login = @Login AND Password = @Password", account).FirstOrDefault();
            return result;
        }
    }
    public bool Insert(Account account)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            var rowsAffected = connection.Execute("INSERT INTO Account (ID, Login, Password, PIN) VALUES (@ID, @Login, @Password, @PIN)", account);
            return rowsAffected == 1;
        }
    }
    public bool Update(Account account)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            var rowsAffected = connection.Execute("UPDATE Account SET Login = @Login, Password = @Password, PIN = @PIN WHERE Login = @Login", account);
            return rowsAffected == 1;
        }
    }
}