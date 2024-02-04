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

        bool isRun = true;

        while(isRun)
        {
            Console.Clear();
            InputData(maxHealth, healthColor, userHealthPosition, healthBarName, ref isRun);

            if(isRun)
            {
                InputData(maxMana, manaColor, userManaPosition, manaBarName, ref isRun);
            }

            Console.ReadKey();
        }
    }

    static void InputData(int maxValue, ConsoleColor color, int position, string barName, ref bool isRun)
    {
        int userData;
        string commandExit = "exit";

        Console.Write($"Введите, сколько у игрока сейчас {barName} (в процентах): ");
        string userInput = Console.ReadLine();
        Console.WriteLine();
        
        if(userInput == commandExit)
        {
            isRun = false;
        }
        else if(int.TryParse(userInput, out userData) && userData <= maxValue)
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
        char barSymbol = '_';
        int percentPerBar = 10;
        int startValue = 0;

        value /= percentPerBar;
        maxValue /= percentPerBar;

        Console.SetCursorPosition(0, position);
        Console.Write("[");
        Console.BackgroundColor = color;
        DrawCells(startValue, value, barSymbol);
        Console.BackgroundColor = defaultColor;
        DrawCells(value, maxValue, barSymbol);
        Console.Write("]\n");
    }

    static void DrawCells(int firstCell, int lastCell, char barSymbol)
    {
        string bar = "";

        for(int i = firstCell; i < lastCell; i++)
        {
            bar += barSymbol;
        }

        Console.Write(bar);
    }
}
