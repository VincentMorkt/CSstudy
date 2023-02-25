// See https://aka.ms/new-console-template for more information

using static System.Console;
using System.IO;

if (args.Length == 0)
{
    WriteLine("There are no arguments.");
}
else
{
    WriteLine("There is at least one argument.");
}

// добавьте или удалите "" в следующей строке чтобы изменить поведение
object o = "3";
int j = 4;
if (o is int i)
{
    WriteLine($"{i} x {j} = {i * j}");
}
else
{
    WriteLine("o is not an int so it cannot multiply!");
}

A_label:
var number = (new Random()).Next(1, 7);
WriteLine($"My random number is {number}");
switch (number)
{
    case 1:
        WriteLine("One");
        break; // переход в конец оператора switch
    case 2:
        WriteLine("Two");
        goto case 1;
    case 3:
    case 4:
        WriteLine("Three or four");
        goto case 1;
    case 5:
        // заснуть на полсекунды
        System.Threading.Thread.Sleep(500);
        goto A_label;
    default:
        WriteLine("Default");
        break;
} // конец оператора switch

// string path = "/Users/markjprice/Code/Chapter03";
string path = @"D:\Documents\Projects\Study & practice CS\Educational exercises. CS 9 & .NET 5 - Mark J. Price\03";
Write("Press R for readonly or W for write: ");
ConsoleKeyInfo key = ReadKey();
WriteLine();
Stream? s = null;
if (key.Key == ConsoleKey.R)
{
    s = File.Open(
    Path.Combine(path, "file.txt"),
    FileMode.OpenOrCreate,
    FileAccess.Read);
}
else
{
    s = File.Open(
    Path.Combine(path, "file.txt"),
    FileMode.OpenOrCreate,
    FileAccess.Write);
}
string message = string.Empty;
switch (s)
{
    case FileStream writeableFile when s.CanWrite:
        message = "The stream is a file that I can write to.";
        break;
    case FileStream readOnlyFile:
        message = "The stream is a read-only file.";
        break;
    case MemoryStream ms:
        message = "The stream is a memory address.";
        break;

    default: // всегда выполняется последним, несмотря на текущее положение
        message = "The stream is some other type.";
        break;
    case null:
        message = "The stream is null.";
        break;
}
WriteLine(message);
