// See https://aka.ms/new-console-template for more information
#nullable enable

class Address
{
    public string? Building;
    public string Street = string.Empty;
    public string City = string.Empty;
    public string Region = string.Empty;
}

class Programm
{
    static void Main(string[] args)
    {
        // int thisCannotBeNull = 4;
        // thisCannotBeNull = null; // ошибка компиляции!


        int? thisCouldBeNull = null;
        Console.WriteLine(thisCouldBeNull);
        Console.WriteLine(thisCouldBeNull.GetValueOrDefault());
        thisCouldBeNull = 7;
        Console.WriteLine(thisCouldBeNull);
        Console.WriteLine(thisCouldBeNull.GetValueOrDefault());
        var address = new Address();
        address.Building = null;
        address.Street = null;
        address.City = "London";
        address.Region = null;
    }
}