class Program
{
    static void Main(string[] args)
    {
        bool isCorrect = false;

        while(isCorrect != true)
        {
            Console.Write("Введите число: ");
            string userInput = Console.ReadLine();

            if(int.TryParse(userInput, out int correctNumber))
            {
                isCorrect = true;
                Console.WriteLine($"Ввод успешно преобразован в число {correctNumber}");
            }
            else
            {
                Console.WriteLine("Некорректный ввод! Попробуйте ещё раз");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}