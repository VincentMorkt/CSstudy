// See https://aka.ms/new-console-template for more information
using static System.Console;
namespace Debugging
{
    class Program
    {
        static double Add(double a, double b)
        {
            return a + b; // преднамеренная ошибка!
        }
        static void Main(string[] args)
        {


            double a = 4.5; // или используйте var
            double b = 2.5;
            double answer = Add(a, b);
            WriteLine($"{a} + {b} = {answer}");
            ReadLine(); // ожидание нажатия клавиши Enter
        }
    }
}
