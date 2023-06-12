using System;
using System.Data.SQLite;
using System.Threading.Channels;
using BusinessLogicLayer;
using DatabaseLayer;

namespace Startup;

class Program
{
    public static void Main(string[] args)
    {
        AccountService accountService = new AccountService();
        Console.WriteLine($"{accountService.SignIn()}");
    }
}