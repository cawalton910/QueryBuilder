using QueryBuilder.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace QueryBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new QueryBuilder(GetProjectRoot() + $"{Path.DirectorySeparatorChar}Data{Path.DirectorySeparatorChar}Library.sqlite");
            
            var read = new Author();
            read = builder.Read<Author>(1);
            Console.WriteLine(read.Information());
            Console.WriteLine("Read from Author where Id = 1, press enter to continue");
            Console.ReadLine();

            Console.WriteLine("\n");
            var readall = new List<Author>();
            readall = builder.ReadAll<Author>();
            foreach (var item in readall)
            {
                Console.WriteLine(item.Information());
            }
            Console.WriteLine("Read all from Author, press enter to continue");
            Console.ReadLine();

            Console.WriteLine("\n");
            var a = new Author(5, "Chase", "Walton");
            builder.Create<Author>(a);
            Console.WriteLine("Created entry in Author, press enter to continue");
            Console.ReadLine();

            Console.WriteLine("\n");
            a.FirstName = "Doug";
            builder.Update<Author>(a);
            Console.WriteLine("Updated the entry from Author, press enter to continue");
            Console.ReadLine();

            Console.WriteLine("\n");
            builder.Delete<Author>(a);
            Console.WriteLine("Deleted entry from Author, press enter to exit");
            Console.ReadLine();

            builder.Dispose();
            Environment.Exit(0);
        }


        public static string GetProjectRoot()
        {
            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
        }
    }
}
