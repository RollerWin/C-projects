class Program
{
    static void Main(string[] args)
    {   
        Queue<int> queueOfPeople = new Queue<int>();

        Console.Write("Введите количество человек в очереди: ");
        int numberOfPeople = ReadPositiveNumber();

        FillQueue(queueOfPeople, numberOfPeople);
        Console.WriteLine($"Очередь составлена! Теперь в ней {numberOfPeople} человек");
        Console.Clear();

        int amountMoney = ServeClients(queueOfPeople);

        Console.WriteLine($"Покупатели законились!\nОбщая сумма составила {amountMoney} рублей");
    }

    static void FillQueue(Queue<int> queue, int numberOfPeople)
    {
        int minValue = 10;
        int maxValue = 1000;
        Random random = new Random();

        for(int i = 0; i < numberOfPeople; i++)
        {
            queue.Enqueue(random.Next(minValue, maxValue + 1));
        }
    }

    static int ReadPositiveNumber()
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

    static int ServeClients(Queue<int> queueOfPeople)
    {
        int amountMoney = 0;

        while(queueOfPeople.Count > 0)
        {
            Console.WriteLine("На кассу пришёл покупатель");
            Console.WriteLine($"Чек составил: {queueOfPeople.Peek()} рублей");
            amountMoney += queueOfPeople.Dequeue();
            Console.WriteLine($"Общая сумма в кассе: {amountMoney} рублей");

            Console.ReadKey();
            Console.Clear();
        }

        return amountMoney;
    }
}