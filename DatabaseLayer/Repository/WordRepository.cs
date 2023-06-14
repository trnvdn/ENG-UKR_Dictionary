using System.Data.SQLite;
using Dapper;
namespace DatabaseLayer;

public class WordRepository
{
    public List<Word> Retrieve()
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            var result = connection.Query<Word>("SELECT * FROM Word").AsList();
            return result;
        }
    }
    public List<Word> Retrieve(string word,string accountID)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            var result = connection.Query<Word>("SELECT * FROM Word WHERE (ENG = @word OR UKR = @word) and AccountID = @accountID", new { word,accountID }).AsList();
            return result;
        }
    }

    public List<Word> Retrieve(string accountID)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            var result = connection.Query<Word>("SELECT * FROM Word WHERE AccountID = @accountID", new { accountID }).AsList();
            return result;
        }
    }
    public bool Insert(Word word)
    {
        using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
        {
            connection.Open();
            var rowsAffected = connection.Execute("INSERT INTO Word (ENG, UKR, Level, AccountID) VALUES (@ENG, @UKR, @Level, @AccountID)", word);
            return rowsAffected == 1;
        }
    }
}