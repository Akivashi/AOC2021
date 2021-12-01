using System;
using System.Linq;
using Utils;

namespace Day01
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
            var sweeps = FileReader.ReadFile<Day01_1Object>("input1.txt", ',');
            for (var i = 0; i < sweeps.Count-1; i++)
            {
                if (sweeps[i + 1].Depth - sweeps[i].Depth > 0)
                {
                    sweeps[i + 1].HasIncreased = true;
                }
            }

            return sweeps.Count(sweep => sweep.HasIncreased);
        }

        public static int Assignment2()
        {
            var sweeps = FileReader.ReadFile<Day01_1Object>("input1.txt", ',');
            for (var i = 0; i < sweeps.Count-3; i++)
            {
                var middleCount = sweeps[i + 1].Depth + sweeps[i + 2].Depth;
                var threeCount1 = sweeps[i].Depth + middleCount;
                var threeCount2 = middleCount + sweeps[i + 3].Depth;
                if (threeCount2 - threeCount1 > 0)
                {
                    sweeps[i + 1].HasIncreased = true;
                }
            }

            return sweeps.Count(sweep => sweep.HasIncreased);
        }
    }
}