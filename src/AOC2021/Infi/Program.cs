using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Day01;

namespace Infi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length <= 1 || args[1] == "1")
            {
                Console.WriteLine(Assignment1());
            }
            if (args.Length <= 1 || args[1] == "2")
            {
                Console.WriteLine(Assignment2());
            }
        }

        public static int Assignment1()
        {
            var lineItems = new List<string>();
            string? line;

            var file = new StreamReader(Directory.GetCurrentDirectory() + "\\input1.txt");
            while ((line = file.ReadLine()) != null)
            {
                lineItems.Add(line);
            }
            lineItems.RemoveAt(0);

            lineItems.Select(item =>
            {
                var splitItem = item.Split(";");
                var toyName = splitItem[0].Trim();
                var components = splitItem[0].Trim().Split(',');
                var componentCounts = components.Select(component =>
                {
                    var componentSplit = component.Split();
                    return new KeyValuePair<string, int>(componentSplit[0], int.Parse(componentSplit[1]));
                }).ToList();
                return new InfiToyObject(toyName, componentCounts);
            });

            return 1;
        }

        public static int Assignment2()
        {
            return 2;
        }
    }
}