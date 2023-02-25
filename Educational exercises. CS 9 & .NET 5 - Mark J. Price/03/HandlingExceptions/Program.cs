// See https://aka.ms/new-console-template for more information
using static System.Console;

WriteLine("Before parsing");
Write("What is your age? ");
string input = ReadLine();
try
{
    int? age = int.Parse(input);
    WriteLine($"You are {age} years old.");
}
    catch(OverflowException) // выход за пределы типа
    {
        WriteLine("Your age is a valid number format but it is either too big or small.");
    }
    catch (FormatException) // несоответствие формата
    {
        WriteLine("The age you entered is not a valid number format.");
    }
    catch (Exception ex) // другие исключения
    {
        WriteLine($"{ex.GetType()} says {ex.Message}");
    }
WriteLine("After parsing");

