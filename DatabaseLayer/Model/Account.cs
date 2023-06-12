using System;

namespace DatabaseLayer;

public class Account
{
    public string ID { get; internal set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public int PIN { get; set; }
    
    private List<Word> Words = new List<Word>();

    public Account()
    {
        ID = Guid.NewGuid().ToString();
    }
}