class Program
{
    static void Main(string[] args)
    {
        const string CommandSumNumbers = "sum";
        const string CommandExit = "exit";

        List<int> numbers = new List<int>();

        bool isRun = true;
        
        while(isRun)
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case CommandSumNumbers:
                    SumNumbers(numbers);
                break;

                case CommandExit:
                    isRun = false;
                break;

                default:
                    TryAddNumber(numbers, userInput);
                break;
            }
        }
    }

    static void SumNumbers(List<int> numbers)
    {
        int sumNumbers = 0;

        foreach (var number in numbers)
        {
            sumNumbers += number;
        }

        Console.WriteLine($"Сумма чисел: {sumNumbers}");
    }

    static void TryAddNumber(List<int> numbers, string userInput)
    {
        if(int.TryParse(userInput, out int addedNumber))
        {
            numbers.Add(addedNumber);
        }
        else
        {
            Console.WriteLine("Неверная команда");
        }
    }
}