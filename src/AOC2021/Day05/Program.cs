using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utils;

namespace Day05
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
            var day05_1Input = ReadInput("input1.txt", true);
            foreach (var vector in day05_1Input.Vectors)
            {
                day05_1Input.TryDrawHorizontalLine(vector);
                day05_1Input.TryDrawVerticalLine(vector);
            }

            // day05_1Input.PrintBoard();

            return day05_1Input.Board.Sum(row => row.Count(value => value > 1));
        }

        public static int Assignment2()
        {
            var day05_1Input = ReadInput("input1.txt", false);
            foreach (var vector in day05_1Input.Vectors)
            {
                day05_1Input.TryDrawHorizontalLine(vector);
                day05_1Input.TryDrawVerticalLine(vector);
                day05_1Input.TryDrawDiagonal(vector);
            }

            // day05_1Input.PrintBoard();

            return day05_1Input.Board.Sum(row => row.Count(value => value > 1));
        }

        private static Day05_1Object ReadInput(string fileName, bool ignoreDiagonals)
        {
            var file = new StreamReader(FileReader.GetCurrentPath() + fileName);
            string? line;
            var vectors = new List<Day05_1Vector>();

            var maxWidth = 0;
            var maxHeight = 0;
            while ((line = file.ReadLine()) != null)
            {
                var coordinates = line.Split("->").Select(i => i.Trim()).ToList();

                var origin = coordinates[0].Split(',').Select(int.Parse).ToList();
                var destination = coordinates[1].Split(',').Select(int.Parse).ToList();

                maxHeight =  Math.Max(Math.Max(maxHeight, origin[1]), destination[1]);
                maxWidth =  Math.Max(Math.Max(maxWidth, origin[0]), destination[0]);
                if (!ignoreDiagonals || origin[0] == destination[0] || origin[1] == destination[1])
                {
                    vectors.Add(new Day05_1Vector(origin[0], origin[1], destination[0], destination[1]));
                }
            }

            file.Close();

            return new Day05_1Object(maxHeight, maxWidth, vectors);
        }
    }
}