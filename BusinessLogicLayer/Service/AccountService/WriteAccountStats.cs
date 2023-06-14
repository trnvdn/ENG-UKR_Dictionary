using DatabaseLayer;

namespace BusinessLogicLayer.Service;

internal class WriteAccountStats
{
    private Account _account;
    
    public WriteAccountStats(Account account)
    {
        _account = account;
    }

    public void Print()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{_account.Login} : {_account.LearnedWords} words learned");
        Console.ResetColor();
        Console.WriteLine();
    }
}