class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        ConsoleColor healthColor = ConsoleColor.Red;
        ConsoleColor manaColor = ConsoleColor.Blue;
        int maxHealth = 100;
        int maxMana = 100;

        int userHealthPosition = 1;
        int userManaPosition = 3;


        string healthBarName = "жизней";
        string manaBarName = "маны";

        while(true)
        {
            Console.Clear();
            InputData(maxHealth, healthColor, userHealthPosition, healthBarName);
            InputData(maxMana, manaColor, userManaPosition, manaBarName);
            Console.ReadKey();
        }
    }

    static void InputData(int maxValue, ConsoleColor color, int position, string barName)
    {
        int userData;

        Console.Write($"Введите, сколько у игрока сейчас {barName} (в процентах): ");
        string userInput = Console.ReadLine();
        Console.WriteLine();
        
        if(int.TryParse(userInput, out userData) && userData <= maxValue)
        {
            DrawBar(userData, maxValue, color, position);
        }
        else
        {
            Console.WriteLine("неверный ввод!");
        }
    }

    static void DrawBar(int value, int maxValue, ConsoleColor color, int position)
    {
        ConsoleColor defaultColor = Console.BackgroundColor;
        string bar = "";
        char barSymbol = '_';
        int percentPerBar = 10;

        value /= percentPerBar;
        maxValue /= percentPerBar;

        for(int i = 0; i < value; i++)
        {
            bar += barSymbol;
        }

        Console.SetCursorPosition(0, position);
        Console.Write("[");
        Console.BackgroundColor = color;
        Console.Write(bar);
        Console.BackgroundColor = defaultColor;
        
        bar = "";

        for(int i = value; i < maxValue; i++)
        {
            bar += barSymbol;
        }

        Console.Write(bar + "]\n");
    }
}