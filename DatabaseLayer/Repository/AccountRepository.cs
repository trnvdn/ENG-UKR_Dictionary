using Dapper;
using System.Data.SQLite;

namespace DatabaseLayer;

public class AccountRepository
{
    public bool IsAccountExists(string login)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            var result = connection.Query<Account>("SELECT * FROM Account WHERE Login = @login", new { login })
                .FirstOrDefault();
            return result != null;
        }
    }

    public int? GetPin(string login)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            int? result =
                connection.QueryFirstOrDefault<int?>("SELECT PIN FROM Account WHERE Login = @login", new { login });
            return result;
        }
    }

    public Account? Retrieve(Account account)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            Account result = connection
                .Query<Account>("SELECT * FROM Account WHERE Login = @Login AND Password = @Password", account)
                .FirstOrDefault();
            return result;
        }
    }

    public bool Insert(Account account)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            var rowsAffected =
                connection.Execute(
                    "INSERT INTO Account (ID, Login, Password, PIN, LearnedWords) VALUES (@ID, @Login, @Password, @PIN, @LearnedWords)",
                    account);
            return rowsAffected == 1;
        }
    }

    public bool Update(Account account)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();

            var query = @"UPDATE Account 
                      SET Login = @Login, Password = @Password, PIN = @PIN, LearnedWords = @LearnedWords 
                      WHERE ID = @ID";

            var parameters = new
            {
                account.Login,
                account.Password,
                account.PIN,
                account.LearnedWords,
                account.ID
            };

            var rowsAffected = connection.Execute(query, parameters);
            return rowsAffected == 1;
        }
    }
}