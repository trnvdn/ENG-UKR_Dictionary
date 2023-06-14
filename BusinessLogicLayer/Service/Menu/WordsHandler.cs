using DatabaseLayer;

namespace BusinessLogicLayer.Service;

internal class WordsHandler
{
    private InsertNewWord _insertNewWord;
    private WriteAllWordsByAccount _WriteAllWordsByAccount;
    public WordsHandler(Account account)
    {
        _insertNewWord = new InsertNewWord(account);
        _WriteAllWordsByAccount = new WriteAllWordsByAccount(account.ID);
    }

    public void Menu()
    {
        bool isActive = true;
        while (isActive)
        {
            Console.WriteLine("1. Add new word\n2. Print all words in dictionary\n3. Back to previous menu");
            var choise = Validation.IntValidation();
            Console.Clear();
            switch (choise)
            {
                case 1:
                    AddWord();
                    continue;;
                case 2:
                    WriteAll();
                    continue;;
                case 3:
                    isActive = false;
                    Console.Clear();
                    continue;;
                default:
                    Console.WriteLine("Error");
                    continue;;
            }
        }
    }
    
    public void AddWord()
    {
        _insertNewWord.AddNewWord();
    }

    public void WriteAll()
    {
        _WriteAllWordsByAccount.Write();
    }
}