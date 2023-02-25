// See https://aka.ms/new-console-template for more information
using static System.Console;
class Programm
{
    static void Main(string[] args)
    {
        int a = 10; // 0000 1010
        int b = 6; // 0000 0110
        WriteLine($"a = {a}");
        WriteLine($"b = {b}");
        WriteLine($"a & b = {a & b}"); // только столбец 2-го бита
        WriteLine($"a | b = {a | b}"); // столбцы 8, 4 и 2-го битов
        WriteLine($"a ^ b = {a ^ b}"); // столбцы 8-го и 4-го битов

        // 0101 0000 — сдвиг влево а на три битовых столбца
        WriteLine($"a << 3 = {a << 3}");
        // умножение на 8
        WriteLine($"a * 8 = {a * 8}");
        // 0000 0011 сдвиг вправо b на один битовый столбец
        WriteLine($"b >> 1 = {b >> 1}");

    }
}
