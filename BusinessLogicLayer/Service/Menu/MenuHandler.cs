using System.Xml;
using DatabaseLayer;

namespace BusinessLogicLayer.Service;

public class MenuHandler
{
    private AccountLogInService _accountLogInService;
    private Account _currentAccount;
    private WordsHandler _wordsHandler;
    private AccountHandler _accountHandler;
    private bool isLoggedIn;

    public MenuHandler()
    {
        _accountLogInService = new AccountLogInService();
        isLoggedIn = false;
    }

    public void Start()
    {
        while (isLoggedIn == false)
        {
            Console.WriteLine("1.Log in\n2.Register");
            var choise = Validation.IntValidation();
            _currentAccount = choise switch
            {
                1 => _accountLogInService.SignIn(),
                2 => _accountLogInService.Register(),
                _ => null
            };
            if (_currentAccount != null)
            {
                Console.Clear();
                bool isActive = true;
                while (isActive)
                {
                    Console.WriteLine("1. Words\n2. My account\n3. Exit");
                    choise = Validation.IntValidation();
                    Console.Clear();
                    switch (choise)
                    {
                        case 1:
                            _wordsHandler = new WordsHandler(_currentAccount);
                            _wordsHandler.Menu();
                            continue;
                        case 2:
                            _accountHandler = new AccountHandler(_currentAccount);
                            _accountHandler.Menu();
                            continue;
                        case 3:
                            isActive = false;
                            return;
                        default:
                            Console.WriteLine("Error");
                            continue;
                    }
                }
            }
            else
            {
                Console.WriteLine("Error! Press any key to return");
                Console.ReadKey();
            }
            Console.Clear();
        }
    }
}