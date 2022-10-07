class Program
{
    public delegate void Notify(int i);
    static event Notify CorrectData;
    static String[] Names = { "Иванов", "Сидоров", "Петров", "Сакмиов", "Козлов" };
    static void Main(string[] args)
    {
        CorrectData += Order;
        try
        {
            int command;
            if (!Int32.TryParse(Console.ReadLine(), out command))
            {
                throw new MyException();
            }
            switch (command)
            {
                case 1:
                case 2:
                    CorrectData.Invoke(command);
                    break;
                default:
                    throw new MyException();
            }
            Console.WriteLine("Успешное завершение программы.");
        }
        catch (MyException)
        {
            Console.WriteLine("Допустимы значение \"1\"и \"2\"");
        }

    }
    public class MyException : Exception
    {
        public MyException() : base() { }
    }
    static public void Order(int i)
    {
        IOrderedEnumerable<string> res;
        if (i == 1)
        {
            res = from n in Names orderby n select n;
        }
        else
        {
            res = Names.OrderByDescending(n => n);

        }
        foreach (var s in res){
            Console.WriteLine(s);
        }
    }
}