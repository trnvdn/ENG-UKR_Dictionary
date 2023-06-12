using BusinessLogicLayer.Service;
using DatabaseLayer;
using System.Text.RegularExpressions;

namespace BusinessLogicLayer;

public class Dictionary
{
    Account _account;
    public Word _word { get; internal set; }
    private WordRepository _wordRepository;

    public Dictionary(Account account)
    {
        _wordRepository = new WordRepository();
        _word = new Word();
        _account = account;
    }


    public void AddNewWord()
    {
        _word.AcountID = _account.ID;
        _word.ENG = eng();
        _word.UKR = ukr();
        _word.Level = levelOfWord(_word.ENG);
        _wordRepository.Insert(_word);
        _account.Words.Add(_word);
    }

    private string eng()
    {
        var input = Validation.StringValidation("english word");
        while (!IsEnglishText(input))
        {
            Console.WriteLine("Error");
            input = Validation.StringValidation("english word");
        }
        return input;
    }
    private string ukr()
    {
        var input = Validation.StringValidation("ukrainian word");
        while (!IsUkrainianText(input))
        {
            Console.WriteLine("Error");
            input = Validation.StringValidation("ukrainian word");
        }
        return input;
    }

    private bool IsEnglishText(string text)
    {
        string cleanedText = new string(text.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray());

        bool isEnglish = cleanedText.All(c => char.IsLetter(c) && c <= 127);

        return isEnglish;
    }
    public static bool IsUkrainianText(string text)
    {
        string cleanedText = new string(text.Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray());

        bool isUkrainian = Regex.IsMatch(cleanedText, @"\p{IsCyrillic}");

        return isUkrainian;
    }

    private int levelOfWord(string word)
    {
        int count = word.Count();
        if (count <= 3)
        {
            return 1;
        }
        else if (count >= 4 && count <= 5) 
        {
            return 2;
        }
        else if (count >= 6 && count <= 7)
        {
            return 3;
        }
        else if (count >= 8 && count <= 9)
        {
            return 4;
        }
        else
        {
            return 5;
        }
    }
}
