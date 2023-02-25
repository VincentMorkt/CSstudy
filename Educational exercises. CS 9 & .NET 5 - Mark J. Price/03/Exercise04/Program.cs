// See https://aka.ms/new-console-template for more information
using static System.Console;

#nullable disable
Write("Enter a number between 0 and 255: ");
try
{
    byte x = byte.Parse(ReadLine());
    Write("Enter another number between 0 and 255: ");
    byte y = byte.Parse(ReadLine());
    WriteLine($"{x} divided by {y} is {x / y}");
}
catch (OverflowException)
{
    WriteLine("ERROR!  Value was either too large or too small for an unsigned byte!");
}
catch (FormatException)
{
    WriteLine("ERROR! Incorrect input format!");
}
catch (DivideByZeroException)
{
    WriteLine("ERROR! Attempted to divide by zero!");
}
catch (Exception ex)
{
    WriteLine($"{ex.GetType()} says {ex.Message}");
}