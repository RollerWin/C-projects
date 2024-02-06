class Program
{
    static void Main(string[] args)
    {
        int[] firstCollection = FillArray();
        int[] secondCollection = FillArray();

        Console.WriteLine("Изначальные массивы: ");
        ShowArray(firstCollection);
        ShowArray(secondCollection);

        List<int> generalCollection = new List<int>();

        TransferUniqueElements(generalCollection, firstCollection);
        TransferUniqueElements(generalCollection, secondCollection);

        Console.WriteLine("Итоговая коллекция: ");
        ShowList(generalCollection);
    }

    static int[] FillArray()
    {
        Random random = new Random();
        int minSize = 2;
        int maxSize = 10;

        int minValue = 1;
        int maxValue = 15;

        int[] collection = new int[random.Next(minSize, maxSize + 1)];
        
        for(int i = 0; i < collection.Length; i++)
        {
            collection[i] = random.Next(minValue, maxValue);
        }

        return collection;
    }

    static void ShowArray(int[] collection)
    {
        for(int i = 0; i < collection.Length; i++)
        {
            Console.Write(collection[i] + " ");
        }

        Console.WriteLine();
    }

    static void TransferUniqueElements(List<int> generalCollection, int[] collection)
    {
        for(int i = 0; i < collection.Length; i++)
        {
            if(generalCollection.Contains(collection[i]) == false)
            {
                generalCollection.Add(collection[i]);
            }
        }
    }

    static void ShowList(List<int> collection)
    {
        foreach(var element in collection)
        {
            Console.Write(element + " ");
        }
    }
}