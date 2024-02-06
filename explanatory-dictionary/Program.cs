class Program
{
    static void Main(string[] args)
    {
        const string commandAddWord = "add";
        const string commandSearchWord = "search";
        const string commandExit = "exit";

        bool isRun = true;

        Dictionary<string, string> explanatoryDictionary = new Dictionary<string, string>();

        while(isRun)
        {
            Console.WriteLine("<---Толковый-словарь--->");
            Console.WriteLine($"{commandAddWord} - Добавить новое слово\n{commandSearchWord} - Найти слово\n{commandExit} - Выход");
            
            switch(Console.ReadLine())
            {
                case commandAddWord:
                    AddNewWord(explanatoryDictionary);
                break;

                case commandSearchWord:
                    SearchWord(explanatoryDictionary);
                break;

                case commandExit:
                    isRun = false;
                break;

                default:
                    Console.WriteLine("Некорректная команда");
                break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    static void AddNewWord(Dictionary<string,string> dictionary)
    {
        Console.Write("Введите новое слово: ");
        string userKeyInput = Console.ReadLine();

        if(FindMatch(userKeyInput, dictionary) == true)
        {
            Console.WriteLine("Это слово уже есть в словаре!");
        }
        else
        {
            Console.Write("Введите значение этого слова: ");
            string userValueInput = Console.ReadLine();
            dictionary.Add(userKeyInput, userValueInput);
            Console.WriteLine("Слово добавлено!");
        }
    }
    
    static bool FindMatch(string userInput, Dictionary<string,string> dictionary)
    {
        bool isFind = false;

        foreach(var key in dictionary.Keys)
        {
            if(key == userInput)
            {
                isFind = true;
            }
        }

        return isFind;
    }

    static void SearchWord(Dictionary<string,string> dictionary)
    {
        Console.Write("Введите интересующее вас слово: ");
        string userInput = Console.ReadLine();

        if(FindMatch(userInput, dictionary) == true)
        {
            Console.WriteLine($"Значение: {dictionary[userInput]}");
        }
        else
        {
            Console.WriteLine("Совпадений не найдено!");
        }
    }
}