using System.Drawing;
using DatabaseLayer;

namespace BusinessLogicLayer.Service;

internal class WriteAllWordsByAccount
{
    private string _accountID;
    private WordRepository _wordRepository;
    public WriteAllWordsByAccount(string acountID)
    {
        _accountID = acountID;
        _wordRepository = new WordRepository();
    }

    public void Write()
    {
        var words = getAllWords(_accountID);
        printAllWords(words);
    }
    private List<Word> getAllWords(string accountId)
    {
        return _wordRepository.Retrieve(accountId);
    }

    private void printAllWords(List<Word> allWordsByAccount)
    {
        foreach (var word in allWordsByAccount)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{word.ENG} --- ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{word.UKR} | ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(word.Level);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}