// See https://aka.ms/new-console-template for more information
// #error version
using System;
using System.Linq;
using System.Reflection;
class Program
{
    static void Main(string[] args)
    {
        System.Data.DataSet ds;
        System.Net.Http.HttpClient client;
        // перебор сборок, на которые ссылается приложение
        foreach (var r in Assembly.GetEntryAssembly().GetReferencedAssemblies())
        {
            // загрузка сборки для чтения данных
            var a = Assembly.Load(new AssemblyName(r.FullName));
            // объявление переменной для подсчета методов
            int methodCount = 0;
            // перебор всех типов в сборке
            foreach (var t in a.DefinedTypes)
            {
                // добавление количества методов
                methodCount += t.GetMethods().Count();
            }
            // вывод количества типов и их методов
            Console.WriteLine(
            "{0:N0} types with {1:N0} methods in {2} assembly.",
            arg0: a.DefinedTypes.Count(),
            arg1: methodCount,
            arg2: r.Name);
        }
    }
}