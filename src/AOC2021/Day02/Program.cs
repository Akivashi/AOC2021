using System;
using System.Linq;
using Utils;

namespace Day02
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
            var horizontalPosition = 0;
            var depth = 0;

            var movementList = FileReader.ReadFile<Day02_1Object>("input1.txt", ' ');

            foreach (var movement in movementList)
            {
                switch (movement.Movement)
                {
                    case "forward":
                        horizontalPosition +=  movement.Amount;
                        break;
                    case "down":
                        depth +=  movement.Amount;
                        break;
                    case "up":
                        depth -=  movement.Amount;
                        break;
                }
            }

            return horizontalPosition * depth;
        }

        public static int Assignment2()
        {
            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;

            var movementList = FileReader.ReadFile<Day02_1Object>("input1.txt", ' ');

            foreach (var movement in movementList)
            {
                switch (movement.Movement)
                {
                    case "forward":
                        horizontalPosition +=  movement.Amount;
                        depth += (aim * movement.Amount);
                        break;
                    case "down":
                        aim +=  movement.Amount;
                        break;
                    case "up":
                        aim -=  movement.Amount;
                        break;
                }
            }

            return horizontalPosition * depth;
        }
    }
}