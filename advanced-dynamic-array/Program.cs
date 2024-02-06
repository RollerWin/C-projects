class Program
{
    static void Main(string[] args)
    {
        const string CommandSumNumbers = "sum";
        const string CommandExit = "exit";

        List<int> numbers = new List<int>();

        bool isRun = true;
        int addedNumber;
        
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
                    if(int.TryParse(userInput, out addedNumber))
                    {
                        numbers.Add(addedNumber);
                    }
                    else
                    {
                        Console.WriteLine("Неверная команда");
                    }
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
}