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

        int defaultPlayerX = map.GetLength(0) / 2;
        int defaultPlayerY = map.GetLength(1) / 2;
        int playerX = defaultPlayerX;
        int playerY = defaultPlayerY;


        ConsoleColor borderColor = ConsoleColor.Red;
        ConsoleColor scoreColor = ConsoleColor.White;
        ConsoleColor playerColor = ConsoleColor.Blue;

        ConsoleKeyInfo userInput;

        Console.CursorVisible = false;

        while(currentCoins != maxCoins)
        {
            
            UpdateScreen(currentCoins, maxCoins, scorePositionX, scorePositionY, scoreColor, playerSymbol, playerX, playerY, playerColor, map, borderColor);
            userInput = Console.ReadKey(true);
            HandleInput(userInput, ref playerX, ref playerY, map, wallSymbol);
            CheckCollisionWithCoin(map, coinSymbol, ref currentCoins, emptyFieldSymbol, playerX, playerY);
        }

        UpdateScreen(currentCoins, maxCoins, scorePositionX, scorePositionY, scoreColor, playerSymbol, playerX, playerY, playerColor, map, borderColor);
    }

    static void DrawPlayer(char playerSymbol, int playerX, int playerY, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(playerX, playerY);
        Console.Write(playerSymbol);
    }

    static void DrawScore(int currentCoins, int maxCoins, int scorePositionX, int scorePositionY, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(scorePositionX, scorePositionY);
        Console.WriteLine($"\nСобрано {currentCoins} из {maxCoins}");
    }

    static void UpdateScreen(int currentCoins, int maxCoins, int scorePositionX, int scorePositionY, ConsoleColor scoreColor, char playerSymbol, int playerX, int playerY, ConsoleColor playerColor, char[,] map, ConsoleColor borderColor)
    {
        Console.Clear();
        DrawMap(map, borderColor);
        DrawPlayer(playerSymbol, playerX, playerY, playerColor);
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

    static void HandleInput(ConsoleKeyInfo userInput, ref int playerX, ref int playerY, char[,] map, char wallSymbol)
    {
        int indexDirectionX = 0;
        int indexDirectionY = 1;

        int[] playerDirection = GetDirection(userInput, indexDirectionX, indexDirectionY);

        int nextPlayerX = playerX + playerDirection[indexDirectionX];
        int nextPlayerY = playerY + playerDirection[indexDirectionY];

        if(map[nextPlayerX, nextPlayerY] != wallSymbol)
        {
            playerX = nextPlayerX;
            playerY = nextPlayerY;
        }
    }

    static int[] GetDirection(ConsoleKeyInfo userInput, int indexDirectionX, int indexDirectionY)
    {
        const ConsoleKey commandShiftLeftArrow = ConsoleKey.LeftArrow;
        const ConsoleKey commandShiftLeftBoard = ConsoleKey.A;

        const ConsoleKey commandShiftRightArrow = ConsoleKey.RightArrow;
        const ConsoleKey commandShiftRightBoard = ConsoleKey.D;

        const ConsoleKey commandShiftUpArrow = ConsoleKey.UpArrow;
        const ConsoleKey commandShiftUpBoard = ConsoleKey.W;

        const ConsoleKey commandShiftDownArrow = ConsoleKey.DownArrow;
        const ConsoleKey commandShiftDownBoard = ConsoleKey.S;

        int[] playerDirection = {0, 0};

        switch(userInput.Key)
        {
            case commandShiftLeftArrow:
            case commandShiftLeftBoard:
                playerDirection[indexDirectionX] = -1;
            break;

            case commandShiftRightArrow:
            case commandShiftRightBoard:
                playerDirection[indexDirectionX] = 1;
            break;

            case commandShiftUpArrow:
            case commandShiftUpBoard:
                playerDirection[indexDirectionY] = -1;
            break;

            case commandShiftDownArrow:
            case commandShiftDownBoard:
                playerDirection[indexDirectionY] = 1;
            break;
        }

        return playerDirection;
    }

    static void CheckCollisionWithCoin(char[,] map, char coinSymbol, ref int currentCoins, char emptyFieldSymbol, int playerX, int playerY)
    {
        if(map[playerX, playerY] == coinSymbol)
        {
            currentCoins++;
            map[playerX, playerY] = emptyFieldSymbol;
        }
    }
}