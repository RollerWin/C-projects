class Program
{
    static void Main(string[] args)
    {
        string userInput = Console.ReadLine();
        int correctNumber = CheckCorrectInput(userInput);

        Console.WriteLine($"Вы ввели число: {correctNumber}");
    }

    static int CheckCorrectInput(string userInput)
    {
        bool isCorrect = false;
        int correctNumber = 0;

        while(isCorrect != true)
        {
            if(int.TryParse(userInput, out correctNumber))
            {
                isCorrect = true;
            }
            else
            {
                Console.WriteLine("Некорректный ввод! Попробуйте ещё раз");
                Console.ReadKey();
                Console.Clear();
                userInput = Console.ReadLine();
            }
        }

        return correctNumber;
    }
}