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
            // if (args.Length <= 1 || args[1] == "2")
            // {
            //     Console.WriteLine(Assignment2());
            // }
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

            var toys = lineItems.Select(item =>
            {
                var splitItem = item.Split(":");
                var toyName = splitItem[0].Trim();
                var components = splitItem[1].Trim().Split(',');
                var componentCounts = components.Select(component =>
                {
                    var componentSplit = component.Trim().Split(' ');
                    return new KeyValuePair<string, int>(componentSplit[1], int.Parse(componentSplit[0]));
                }).ToList();
                return new InfiToyObject(toyName, componentCounts);
            }).ToList();

            var maxCount = int.MinValue;
            foreach (var toy in toys)
            {
                maxCount = Math.Max(maxCount, GetComponentCount(toys, toy));
            }

            return maxCount;
        }

        private static int GetComponentCount(List<InfiToyObject> knownToys, InfiToyObject toyToCount)
        {
            var count = 0;
            foreach (var component in toyToCount.Components)
            {
                var foundToy = knownToys.FirstOrDefault(knownToy => string.Equals(knownToy.ToyName, component.Key));
                if (foundToy == null)
                {
                    count += component.Value;
                }
                else
                {
                    count += component.Value * GetComponentCount(knownToys, foundToy);
                }
            }

            return count;
        }

        public static int Assignment2()
        {
            return 2;
        }
    }
}