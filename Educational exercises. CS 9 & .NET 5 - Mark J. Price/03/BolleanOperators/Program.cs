// See https://aka.ms/new-console-template for more information
using static System.Console;
class Progremm
{
    static void Main(string[] args)
    {
        bool a = true;
        bool b = false;
        WriteLine($"a = true \nb = false\n");

        WriteLine($"AND   | a     | b ");
        WriteLine($"a     | {a & a,-5} | {a & b,-5} ");
        WriteLine($"b     | {b & a,-5} | {b & b,-5} ");
        WriteLine();
        WriteLine($"OR    | a     | b ");
        WriteLine($"a     | {a | a,-5} | {a | b,-5} ");
        WriteLine($"b     | {b | a,-5} | {b | b,-5} ");
        WriteLine();
        WriteLine($"XOR   | a     | b ");
        WriteLine($"a     | {a ^ a,-5} | {a ^ b,-5} ");
        WriteLine($"b     | {b ^ a,-5} | {b ^ b,-5} ");

        WriteLine($"a && DoStuff() = {a && DoStuff()}");
        WriteLine($"b && DoStuff() = {b && DoStuff()}");
    }
    private static bool DoStuff()
    {
        WriteLine("I am doing some stuff.");
        return true;
    }
}
