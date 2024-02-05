class Program
{
    static void Main(string[] args)
    {
        string mapPath = "map.txt";

        char[,] map = ReadMap(mapPath);
        
        char coinSymbol = '.';
        char playerSymbol = '@';
        char wallSymbol = '#';
        char emptyFieldSymbol = ' ';

        int maxCoins = GetNumberOfCoinsInMap(map, coinSymbol);
        int currentCoins = 0;
        int scorePositionX = 0;
        int scorePositionY = map.GetLength(1);

        int defaultplayerPositionX = map.GetLength(0) / 2;
        int defaultplayerPositionY = map.GetLength(1) / 2;
        int playerPositionX = defaultplayerPositionX;
        int playerPositionY = defaultplayerPositionY;


        ConsoleColor borderColor = ConsoleColor.Red;
        ConsoleColor scoreColor = ConsoleColor.White;
        ConsoleColor playerColor = ConsoleColor.Blue;

        ConsoleKeyInfo userInput;

        Console.CursorVisible = false;

        while(currentCoins != maxCoins)
        {
            
            UpdateScreen(currentCoins, maxCoins, scorePositionX, scorePositionY, scoreColor, playerSymbol, playerPositionX, playerPositionY, playerColor, map, borderColor);
            userInput = Console.ReadKey(true);
            HandleInput(userInput, ref playerPositionX, ref playerPositionY, map, wallSymbol);
            HandleCoinCollision(map, coinSymbol, ref currentCoins, emptyFieldSymbol, playerPositionX, playerPositionY);
        }

        UpdateScreen(currentCoins, maxCoins, scorePositionX, scorePositionY, scoreColor, playerSymbol, playerPositionX, playerPositionY, playerColor, map, borderColor);
    }

    static void DrawPlayer(char playerSymbol, int playerPositionX, int playerPositionY, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(playerPositionX, playerPositionY);
        Console.Write(playerSymbol);
    }

    static void DrawScore(int currentCoins, int maxCoins, int scorePositionX, int scorePositionY, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(scorePositionX, scorePositionY);
        Console.WriteLine($"\nСобрано {currentCoins} из {maxCoins}");
    }

    static void UpdateScreen(int currentCoins, int maxCoins, int scorePositionX, int scorePositionY, ConsoleColor scoreColor, char playerSymbol, int playerPositionX, int playerPositionY, ConsoleColor playerColor, char[,] map, ConsoleColor borderColor)
    {
        Console.Clear();
        DrawMap(map, borderColor);
        DrawPlayer(playerSymbol, playerPositionX, playerPositionY, playerColor);
        DrawScore(currentCoins, maxCoins, scorePositionX, scorePositionY, scoreColor);
    }

    static char[,] ReadMap(string path)
    {
        string[] file = File.ReadAllLines(path);

        char[,] map = new char[GetMaxLengthOfLine(file), file.Length];

        for(int i = 0; i < map.GetLength(0); i++)
        {
            for(int j = 0; j < map.GetLength(1); j++)
            {
                map[i,j] = file[j][i];
            }
        }

        return map;
    } 

    static int GetMaxLengthOfLine(string[] lines)
    {
        int maxLength = lines[0].Length;

        for(int i = 0; i < lines.Length; i++)
        {
            maxLength = Math.Max(maxLength, lines[i].Length);
        }

        return maxLength;
    }

    static void DrawMap(char[,] map, ConsoleColor color)
    {
        Console.ForegroundColor = color;

        for(int y = 0; y < map.GetLength(1); y++)
        {
            for(int x = 0; x < map.GetLength(0); x++)
            {
                Console.Write(map[x,y]);
            }

            Console.WriteLine();
        }
    }

    static int GetNumberOfCoinsInMap(char[,] map, char coinSymbol)
    {
        int coinsCounter = 0;
        
        for(int i = 0; i < map.GetLength(0); i++)
        {
            for(int j = 0; j < map.GetLength(1); j++)
            {
                if(map[i,j] == coinSymbol)
                {
                    coinsCounter++;
                }
            }
        }

        return coinsCounter;
    }

    static void HandleInput(ConsoleKeyInfo userInput, ref int playerPositionX, ref int playerPositionY, char[,] map, char wallSymbol)
    {
        int indexDirectionX = 0;
        int indexDirectionY = 1;

        int[] playerDirection = GetDirection(userInput, indexDirectionX, indexDirectionY);

        int nextplayerPositionX = playerPositionX + playerDirection[indexDirectionX];
        int nextplayerPositionY = playerPositionY + playerDirection[indexDirectionY];

        if(map[nextplayerPositionX, nextplayerPositionY] != wallSymbol)
        {
            playerPositionX = nextplayerPositionX;
            playerPositionY = nextplayerPositionY;
        }
    }

    static int[] GetDirection(ConsoleKeyInfo userInput, int indexDirectionX, int indexDirectionY)
    {
        const ConsoleKey СommandShiftLeftArrowawMap = ConsoleKey.LeftArrow;
        const ConsoleKey СommandShiftLeftBoard = ConsoleKey.A;

        const ConsoleKey СommandShiftRightArrow = ConsoleKey.RightArrow;
        const ConsoleKey СommandShiftRightBoard = ConsoleKey.D;

        const ConsoleKey СommandShiftUpArrow = ConsoleKey.UpArrow;
        const ConsoleKey СommandShiftUpBoard = ConsoleKey.W;

        const ConsoleKey СommandShiftDownArrow = ConsoleKey.DownArrow;
        const ConsoleKey СommandShiftDownBoard = ConsoleKey.S;

        int[] playerDirection = {0, 0};

        switch(userInput.Key)
        {
            case СommandShiftLeftArrowawMap:
            case СommandShiftLeftBoard:
                playerDirection[indexDirectionX] = -1;
            break;

            case СommandShiftRightArrow:
            case СommandShiftRightBoard:
                playerDirection[indexDirectionX] = 1;
            break;

            case СommandShiftUpArrow:
            case СommandShiftUpBoard:
                playerDirection[indexDirectionY] = -1;
            break;

            case СommandShiftDownArrow:
            case СommandShiftDownBoard:
                playerDirection[indexDirectionY] = 1;
            break;
        }

        return playerDirection;
    }

    static void HandleCoinCollision(char[,] map, char coinSymbol, ref int currentCoins, char emptyFieldSymbol, int playerPositionX, int playerPositionY)
    {
        if(map[playerPositionX, playerPositionY] == coinSymbol)
        {
            currentCoins++;
            map[playerPositionX, playerPositionY] = emptyFieldSymbol;
        }
    }
}