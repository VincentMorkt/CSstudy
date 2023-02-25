// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;
namespace Instrumenting
{
    class Program
    {
        static void Main(string[] args)
        {
            // запись в текстовый файл, расположенный в файле проекта
            Trace.Listeners.Add(new TextWriterTraceListener(
            File.CreateText("log.txt")));
            // модуль записи текста буферизируется, поэтому данная опция
            // вызывает функцию Flush() для всех прослушивателей после записи
            Trace.AutoFlush = true;
            Debug.WriteLine("Debug says, I am watching!");
            Trace.WriteLine("Trace says, I am watching!");
            
            
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            
            IConfigurationRoot configuration = builder.Build();
            
            var ts = new TraceSwitch(
                displayName: "PacktSwitch",
                description: "This switch is set via a JSON config.");
            
            configuration.GetSection("PacktSwitch").Bind(ts);
            
            Trace.WriteLineIf(ts.TraceError, "Trace error");
            Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
            Trace.WriteLineIf(ts.TraceInfo, "Trace information");
            Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
        }
    }
}