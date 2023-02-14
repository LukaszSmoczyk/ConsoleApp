using System;

namespace ConsoleApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new DataReader();
            var objects = reader.ImportAndOrganizeData("data.csv");

            var printer = new DataPrinter();
            printer.PrintData(objects);
            Console.ReadLine();
        }
    }
}
