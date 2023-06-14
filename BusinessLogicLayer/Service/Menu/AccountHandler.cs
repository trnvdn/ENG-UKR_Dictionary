using DatabaseLayer;

namespace BusinessLogicLayer.Service;

internal class AccountHandler
{
    private WriteAccountStats _accountStats;
    public AccountHandler(Account account)
    {
        _accountStats = new WriteAccountStats(account);
    }
    public void Menu()
    {
        bool isActive = true;
        while (isActive)
        {
            Console.WriteLine("1. Account stats\n2. Back to previous menu");
            var choise = Validation.IntValidation();
            switch (choise)
            {
                case 1:
                    _accountStats.Print();
                    continue;
                case 2:
                    isActive = false;
                    continue;
                default:
                    Console.WriteLine("Error");
                    continue;
            }
        }
    }    
}

