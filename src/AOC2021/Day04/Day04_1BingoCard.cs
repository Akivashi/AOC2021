using System;
using System.Collections.Generic;
using System.Text;

namespace Day04
{
    public class Day04_1BingoCard
    {
        public Day04_1BingoCard(List<List<Day04_1BingoNumber>> bingoNumbers)
        {
            BingoNumbers = bingoNumbers;
            HasWon = false;
        }

        public List<List<Day04_1BingoNumber>> BingoNumbers { get; set; }
        public bool HasWon { get; set; }

        public void PrintCard()
        {
            foreach (var row in BingoNumbers)
            {
                foreach (var number in row)
                {
                    if (number.IsMarked)
                    {
                        Console.BackgroundColor  = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor  = ConsoleColor.Black;
                    }
                    Console.Write((number.Number < 10 ? "  " : " ") + number.Number);

                }
                Console.WriteLine("");
            }
            Console.BackgroundColor  = ConsoleColor.Black;
        }
    }
}
