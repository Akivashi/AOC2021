using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Utils;

namespace Day06
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

        public static long Assignment1()
        {
            return SimulateDays(80, ReadInput("input1.txt")).FishCountPerDayTillMitosis.Sum();
        }


        public static long Assignment2()
        {
            return SimulateDays(256, ReadInput("input1.txt")).FishCountPerDayTillMitosis.Sum();
        }

        private static Day06_1Object SimulateDays(int daysToSimulate, Day06_1Object fishInformation)
        {
            for (var i = 0; i < daysToSimulate; i++)
            {
                var newFishInformation = new Day06_1Object(new List<long> { 0, 0, 0, 0, 0, 0, 0, 0, 0 });
                for (var mitosisIndex = 0; mitosisIndex < 9; mitosisIndex++)
                {
                    if (mitosisIndex == 0)
                    {
                        newFishInformation.FishCountPerDayTillMitosis[8] +=
                            fishInformation.FishCountPerDayTillMitosis[mitosisIndex];
                        newFishInformation.FishCountPerDayTillMitosis[6] +=
                            fishInformation.FishCountPerDayTillMitosis[mitosisIndex];
                    }
                    else
                    {
                        newFishInformation.FishCountPerDayTillMitosis[mitosisIndex - 1] +=
                            fishInformation.FishCountPerDayTillMitosis[mitosisIndex];
                    }
                }

                fishInformation = newFishInformation;
            }

            return fishInformation;
        }

        private static Day06_1Object ReadInput(string fileName)
        {
            var file = new StreamReader(FileReader.GetCurrentPath() + fileName);
            string? line;
            List<long> daysTillMitosis = new List<long>();

            while ((line = file.ReadLine()) != null)
            {
                daysTillMitosis = line.Split(',').Select(f => f.Trim()).Select(long.Parse).ToList();
            }

            file.Close();

            var daysTillMitosisResult = new List<long>();

            for (var dayTillMitosis = 0; dayTillMitosis < 9; dayTillMitosis++)
            {
                daysTillMitosisResult.Add(daysTillMitosis.Count(d => d == dayTillMitosis));
            }

            return new Day06_1Object(daysTillMitosisResult);
        }
    }
}