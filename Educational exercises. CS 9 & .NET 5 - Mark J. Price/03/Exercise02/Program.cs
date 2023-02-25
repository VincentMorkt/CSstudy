// See https://aka.ms/new-console-template for more information
using static System.Console;

int max = 500;
try
{
    checked
    {
        for (byte i = 0; i < max; i++)
        {
            WriteLine(i);
        }
    }
}
catch (OverflowException)
{
    WriteLine("The code overflowed but I caught the exception.");
}