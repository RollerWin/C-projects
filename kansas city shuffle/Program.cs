class Program
{
    static void Main(string[] args)
    {        
        bool isFind = false;

        int guessedNumber;
        int cellNumber;

        Console.WriteLine("<---Игра-Угадайка--->");
        Console.WriteLine("Введите количество чисел в выборке: ");
        int sampleSize = TakeCorrectInputNumber();
        Console.WriteLine();

        int[] numbers = new int[sampleSize];
        FillArray(numbers);
        
        Console.WriteLine($"Теперь у нас есть {sampleSize} чисел по возрастанию\nОт {numbers[0]} до {numbers[numbers.Length - 1]}");

        while(isFind == false)
        {
            Shuffle(numbers);
            ShowHiddenList(numbers.Length);

            Console.Write("Выберите число, которое хотите угадать: ");
            guessedNumber = TakeCorrectInputNumber();
            
            Console.Write("\nА теперь укажите номер ячейки, в котором находится это число: ");
            cellNumber = TakeCorrectInputNumber();
            Console.WriteLine();

            if(cellNumber < numbers.Length && numbers[cellNumber - 1] == guessedNumber)
            {
                Console.WriteLine("Верно! Вы угадали!");
                isFind = true;
            }
            else
            {
                Console.WriteLine($"Неверно! Число {guessedNumber} находилось в ячейке {FindCorrectCell(numbers, guessedNumber) + 1}!");
                ShowArray(numbers);
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static int TakeCorrectInputNumber()
    {
        string userInput;
        bool isCorrect = false;
        int correctNumber = 0;

        while(isCorrect != true)
        {
            userInput = Console.ReadLine();

            if(int.TryParse(userInput, out correctNumber) && correctNumber > 0)
            {
                isCorrect = true;
            }
            else
            {
                Console.WriteLine("Некорректный ввод! Попробуйте ещё раз");
                Console.ReadKey();
                Console.Clear();
            }
        }

        return correctNumber;
    }

    static void FillArray(int[] numbers)
    {
        for(int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }
    }

    static void ShowArray(int[] numbers)
    {
        for(int i = 0; i < numbers.Length; i++)
        {
            Console.Write("[" + numbers[i] + "]" + " ");
        }

        Console.WriteLine();
    }

    static void ShowHiddenList(int numbers)
    {
        for(int i = 0; i < numbers; i++)
        {
            Console.Write("[] ");
        }

        Console.WriteLine();
    }

    static void Shuffle(int[] numbers)
    {
        Random random = new Random();

        for (int i = 0; i < numbers.Length - 1; i++)
        {
            int j = random.Next(i + 1, numbers.Length);

            int temp = numbers[i];
            numbers[i] = numbers[j];
            numbers[j] = temp;
        }
    }

    static int FindCorrectCell(int[] numbers, int guessedNumber)
    {
        int correctIndex = 0;

        for(int i = 0; i < numbers.Length; i++)
        {
            if(numbers[i] == guessedNumber)
            {
                correctIndex = i;
            }
        }

        return correctIndex;
    }
}