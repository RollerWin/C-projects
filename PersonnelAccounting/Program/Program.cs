class Program
{
    static void Main(string[] args)
    {
        const string CommandAddEmployee = "add";
        const string CommandShowEmployees = "show";
        const string CommandDeleteEmployee = "delete";
        const string CommandExit = "exit";

        bool isRun = true;

        Dictionary<string, string> employees = new Dictionary<string, string>();
        
        while(isRun == true)
        {
            Console.WriteLine("<---Кадровый-учёт--->");
            Console.WriteLine($"{CommandAddEmployee} - добавить досье\n" +
                $"{CommandShowEmployees} - показать все досье\n" +
                $"{CommandDeleteEmployee} - удалить досье\n" +
                $"{CommandExit} - Выход");

            switch(Console.ReadLine())
            {
                case CommandAddEmployee:
                    AddEmployee(employees);
                break;

                case CommandShowEmployees:
                    ShowEmployees(employees);
                break;

                case CommandDeleteEmployee:
                    DeleteEmployee(employees);
                break;

                case CommandExit:
                    isRun = false;
                break;

                default:
                    Console.WriteLine("Некорректная команда");
                break;
            }

            Console.ReadKey();
            Console.Clear();
        }
    }

    static void AddEmployee(Dictionary<string, string> employees)
    {
        Console.Write("Введите имя сотрудника: ");
        string employeeName = Console.ReadLine();

        Console.Write("Введите его должность: ");
        string employeePosition = Console.ReadLine();

        employees.Add(employeeName, employeePosition);
    }

    static void ShowEmployees(Dictionary<string, string> employees)
    {
        int i = 1;

        foreach(var employee in employees)
        {
            Console.WriteLine($"{i++}. {employee.Key} - {employee.Value}");
        }
    }

    static void DeleteEmployee(Dictionary<string, string> employees)
    {
        Console.Write("Введите номер сотрудника: ");
                    
        if(int.TryParse(Console.ReadLine(), out int employeeNumber) && (employeeNumber >= 1 && employeeNumber <= employees.Count))
        {
            employees.Remove(employees.ElementAt(employeeNumber - 1).Key);
        }
        else
        {
            Console.WriteLine("Некорректный ввод");
        }
    }
}