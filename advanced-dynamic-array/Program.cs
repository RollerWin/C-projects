class Program
{
    static void Main(string[] args)
    {
        string commandSumNumbers = "sum";
        string commandExit = "exit";

        List<int> numbers = new List<int>();

        bool isRun = true;
        int addedNumber;
        
        while(isRun)
        {
            string userInput = Console.ReadLine();

            if(int.TryParse(userInput, out addedNumber))
            {
                numbers.Add(addedNumber);
            }
            else if(userInput == commandSumNumbers)
            {
                SumNumbers(numbers);
            }
            else if(userInput == commandExit)
            {
                isRun = false;
            }
            else
            {
                Console.WriteLine("Неверная команда");
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