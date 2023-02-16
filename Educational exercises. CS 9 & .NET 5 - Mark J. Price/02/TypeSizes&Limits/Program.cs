// See https://aka.ms/new-console-template for more information
using static System.Console;

// WriteLine(
//  format: "{0,-8} {1,6:N0}",
//  arg0: bananasText,
//  arg1: bananasCount);

//  typeid(x).name();
for (int i = 0; i < 33 + 33 + 8 + 2; i++)
    Write('-');
Write('\n');

WriteLine(
    format: "{0,-8}{1,-32}{2,3}{3,33}",
    "Type",
    "Byte(s) of memory",
    "Min",
    "Max");
for (int i = 0; i < 33 + 33 + 8 + 2; i++)
    Write('-');
Write('\n');

WriteLine(
    format: "{0,-8}{1,-2:D}{2,33:D}{3,33:D}",
    "sbyte",
    sizeof(sbyte),
    sbyte.MinValue,
    sbyte.MaxValue);
WriteLine(
    format: "{0,-8}{1,-2:D}{2,33:D}{3,33:D}",
    "byte",
    sizeof(byte),
    byte.MinValue,
    byte.MaxValue);
WriteLine(
    format: "{0,-8}{1,-2:D}{2,33:D}{3,33:D}",
    "short",
    sizeof(short),
    short.MinValue,
    short.MaxValue);
WriteLine(
    format: "{0,-8}{1,-2:D}{2,33:D}{3,33:D}",
    "ushort",
    sizeof(ushort),
    ushort.MinValue,
    ushort.MaxValue);
WriteLine(
    format: "{0,-8}{1,-2:D}{2,33:D}{3,33:D}",
    "int",
    sizeof(int),
    int.MinValue,
    int.MaxValue);
WriteLine(
    format: "{0,-8}{1,-2:D}{2,33:D}{3,33:D}",
    "uint",
    sizeof(uint),
    uint.MinValue,
    uint.MaxValue);
WriteLine(
    format: "{0,-8}{1,-2:D}{2,33:D}{3,33:D}",
    "long",
    sizeof(long),
    long.MinValue,
    long.MaxValue);
WriteLine(
    format: "{0,-8}{1,-2:D}{2,33:D}{3,33:D}",
    "ulong",
    sizeof(ulong),
    ulong.MinValue,
    ulong.MaxValue);
WriteLine(
    format: "{0,-8}{1,-2:D}{2,33}{3,33}",
    "float",
    sizeof(float),
    float.MinValue,
    float.MaxValue);
WriteLine(
    format: "{0,-8}{1,-2:D}{2,33}{3,33}",
    "double",
    sizeof(double),
    double.MinValue,
    double.MaxValue);
WriteLine(
    format: "{0,-8}{1,-2:D}{2,33}{3,33}",
    "decimal",
    sizeof(decimal),
    decimal.MinValue,
    decimal.MaxValue);
