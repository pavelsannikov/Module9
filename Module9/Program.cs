
class Program
{
    /// <summary>
    /// Данная программа запрашивает путь до файла, в котором должно быть число от -100 до 100.
    /// Затем 100 делится на это число, и результат выводится в консоль.
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введите полный путь до файла");
            string path = Console.ReadLine();
            string[] readText = File.ReadAllLines(path);
            int my_number = Int32.Parse(readText.FirstOrDefault());
            if ((readText.Length != 1) ||
                (my_number < -100) || (my_number > 100))
                throw new MyException("неправильный файл");
            Console.WriteLine("Успешное завершение программы. Результат: {0}",100/my_number);
        }
        catch (System.DivideByZeroException)
        {
            Console.WriteLine("На ноль делить нельзя!");
        }
        catch (System.ArgumentException)
        {
            Console.WriteLine("Некорректный путь до файла, либо файл пустой");
        }
        catch (MyException)
        {
            Console.WriteLine("Недопустимое значение числа в файле");
        }
        catch (System.FormatException)
        {
            Console.WriteLine("Содержимое файла некорректно");
        }
        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("Файл не найден");
        }
    }
    public class MyException : Exception
    {
        public MyException(string _exceptionMessage) : base(_exceptionMessage) { }
    }
}
   