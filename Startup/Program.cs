using BusinessLogicLayer.Service;

namespace Startup;

class Program
{
    public static void Main(string[] args)
    {
        Console.InputEncoding = System.Text.Encoding.Unicode;
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        var menu = new MenuHandler();
        menu.Start();
    }
}