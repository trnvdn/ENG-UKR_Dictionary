using DatabaseLayer;

namespace BusinessLogicLayer.Service;

internal class AccountLogInService
{
    public Account CurrentAccount { get; internal set; }

    private AccountRepository _accountRepository;

    public AccountLogInService()
    {
        _accountRepository = new AccountRepository();
    }

    public Account Register()
    {
        var login = setLogin();
        var password = setPassword();
        var pin = setPin();
        var account = new Account()
        {
            Login = login,
            Password = Encrypting.Encrypt(password, pin),
            PIN = pin
        };
        _accountRepository.Insert(account);
        return account;
    }

    public Account? SignIn()
    {
        var login = Validation.StringValidation("login");
        var password = Validation.StringValidation("password");
        int? pin = _accountRepository.GetPin(login);
        if (pin == null)
        {
            return null;
        }
        var account = new Account()
        {
            Login = login,
            Password = Encrypting.Encrypt(password, pin.Value),
            PIN = pin.Value
        };
        var data = _accountRepository.Retrieve(account);

        if (data != null)
        {
            CurrentAccount = data;
            return data;
        }
        else
        {
            return null;
        }
    }

    private string setLogin()
    {
        string login = Validation.StringValidation("login");
        while (_accountRepository.IsAccountExists(login) == true)
        {
            Console.WriteLine("Login already exists");
            login = Validation.StringValidation("login");
        }
        return login;
    }

    private string setPassword()
    {
        string password = Validation.StringValidation("password");
        while (password.Length < 8)
        {
            Console.WriteLine("Password must be at least 8 characters long");
            password = Validation.StringValidation("password");
        }

        return password;
    }

    private int setPin()
    {
        return Validation.PinValidation();
    }
}