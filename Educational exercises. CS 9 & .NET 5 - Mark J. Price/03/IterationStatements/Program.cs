// See https://aka.ms/new-console-template for more information
using static System.Console;

// int x = 0;
// while (x < 10)
// {
//     WriteLine(x);
//     x++;
// }

// string? password = string.Empty;
// int tryes = 0;
// do
// {
//     Write("Enter your password: ");
//     password = ReadLine();
//     tryes++;
// }
// while ((password != " Pa$$w0rd") & (tryes < 10));

// if (password != " Pa$$w0rd")
// {
//     WriteLine("ERROR! Input tryes limit!");
// }
// else
// {
//     WriteLine("Correct!");
// }

// for (int y = 1; y <= 10; y++)
// {
//     WriteLine(y);
// }

string[] names = { "Adam", "Barry", "Charlie" };
foreach (string name in names)
{
    WriteLine($"{name} has {name.Length} characters.");
}