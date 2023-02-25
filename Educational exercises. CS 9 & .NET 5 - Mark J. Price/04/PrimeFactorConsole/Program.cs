// See https://aka.ms/new-console-template for more information
using static System.Console;
using Packt1;
class Program
{
    static void Main(string[] args)
    {
        int number;
        while (true)
        {
            Write("Enter a number between 1 and 1000 to find its prime factors <q -quit>: ");
            string? input = ReadLine();
            if (input == "q" || input == "Q" || input == "-quit")
            {
                break;
            }
            if (int.TryParse(input, out number))
            {
                if (number < 0 || number > 1000)
                {
                    WriteLine("Error, number out of range!");
                }
                else
                {
                    WriteLine($"Prime factors of {number}: {Prime.Factors(number)}");
                }
            }
            else
            {
                WriteLine("Error: non-numeric input!");
            }
        }
    }

}