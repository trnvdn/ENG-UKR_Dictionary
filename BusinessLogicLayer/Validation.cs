namespace BusinessLogicLayer;

public static class Validation
{
    public static string StringValidation(string text = null)
    {
        if(!string.IsNullOrEmpty(text))
        {
            Console.WriteLine($"Enter {text}");
        }
        string input = Console.ReadLine();
        while (string.IsNullOrEmpty(input))
        {
            Console.WriteLine("Error");
            input = Console.ReadLine();
        }

        return input;
    }
    public static int IntValidation(string text = null)
    {
        if (!string.IsNullOrEmpty(text))
        {
            Console.WriteLine($"Enter {text}");
        }
        string input = Console.ReadLine();
        int number;
        while (!int.TryParse(input, out number))
        {
            Console.WriteLine("Error");
            input = Console.ReadLine();
        }

        return number;
    }

    public static int PinValidation()
    {
        Console.WriteLine("Enter PIN");
        var pin = IntValidation();
        while (pin is > 9999 or < 1000)
        {
            Console.WriteLine("Error");
            pin = IntValidation();
        }

        return pin;
    }
}