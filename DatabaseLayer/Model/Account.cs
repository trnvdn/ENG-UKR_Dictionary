namespace DatabaseLayer;

public class Account
{
    public string ID { get; internal set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public int PIN { get; set; }

    public int LearnedWords { get; set; }
    
    public Account()
    {
        ID = Guid.NewGuid().ToString();
        LearnedWords = 0;
    }
}