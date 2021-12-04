using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Day03
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
            List<bool> gammaRateBitCount = new ();
            List<bool> epsilonRateBitCount = new ();

            var binaryNumbersList = FileReader.ReadFile<Day03_1Object>("input1.txt", ' ');
            var readings = binaryNumbersList.Count;
            for (var i = 0; i < binaryNumbersList[0].Binarynumbers.Count; i++)
            {
                var count = binaryNumbersList.Count(b => b.Binarynumbers[i]);
                gammaRateBitCount.Add(count >= readings/2);
                epsilonRateBitCount.Add(count < readings/2);
            }

            var gammaRate = Convert.ToInt32(string.Join("", gammaRateBitCount.Select(bit => bit ? "1" : "0")), 2);
            var epsilonRate = Convert.ToInt32(string.Join("", epsilonRateBitCount.Select(bit => bit ? "1" : "0")), 2);
            return gammaRate * epsilonRate;
        }

        public static int Assignment2()
        {
            var binaryNumbersList = FileReader.ReadFile<Day03_1Object>("input1.txt", ' ');
            List<Day03_1Object> oxygenRating = binaryNumbersList.Select(item => item.Clone()).ToList();

            for (var bitIndex = 0; bitIndex < oxygenRating[0].Binarynumbers.Count; bitIndex++)
            {
                var readings = oxygenRating.Count;
                List<bool> gammaRateBitCount = new ();
                for (var j = 0; j < oxygenRating[0].Binarynumbers.Count; j++)
                {
                    var count = oxygenRating.Count(b => b.Binarynumbers[j]);
                    gammaRateBitCount.Add(count >= readings / 2.0m);
                }
                for (var i = oxygenRating.Count-1; i >= 0; i--)
                {
                    if (oxygenRating.Count == 1)
                    {
                        break;
                    }

                    if (oxygenRating[i].Binarynumbers[bitIndex] != gammaRateBitCount[bitIndex])
                    {
                        oxygenRating.RemoveAt(i);
                    }
                }
            }

            List<Day03_1Object> co2ScrubberRating = binaryNumbersList.Select(item => item.Clone()).ToList();

            for (var bitIndex = 0; bitIndex < co2ScrubberRating[0].Binarynumbers.Count; bitIndex++)
            {
                var readings = co2ScrubberRating.Count;
                List<bool> epsilonRateBitCount = new ();

                for (var j = 0; j < co2ScrubberRating[0].Binarynumbers.Count; j++)
                {
                    var count = co2ScrubberRating.Count(b => b.Binarynumbers[j]);
                    epsilonRateBitCount.Add(count < readings / 2.0m);
                }

                for (var i = co2ScrubberRating.Count-1; i >= 0; i--)
                {
                    if (co2ScrubberRating.Count == 1)
                    {
                        break;
                    }

                    if (co2ScrubberRating[i].Binarynumbers[bitIndex] != epsilonRateBitCount[bitIndex])
                    {
                        co2ScrubberRating.RemoveAt(i);
                    }
                }

                if (co2ScrubberRating.Count == 1)
                {
                    break;
                }
            }

            var oxygenRate = Convert.ToInt32(string.Join("", oxygenRating[0].Binarynumbers.Select(bit => bit ? "1" : "0")), 2);
            var co2ScrubberRate = Convert.ToInt32(string.Join("", co2ScrubberRating[0].Binarynumbers.Select(bit => bit ? "1" : "0")), 2);

            return oxygenRate * co2ScrubberRate;
        }
    }
}