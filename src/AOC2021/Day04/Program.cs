using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Utils;

namespace Day04
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // if (args.Length <= 1 || args[1] == "1")
            // {
            //     Console.WriteLine(Assignment1());
            // }
            if (args.Length <= 1 || args[1] == "2")
            {
                Console.WriteLine(Assignment2());
            }
        }

        public static int Assignment1()
        {
            var day04_1Input = ReadInput("input1.txt");
            List<Day04_1BingoCard> winningBingoCard = null;
            int lastNumberDrawn = 0;
            foreach (var numberDraw in day04_1Input.NumberDraws)
            {
                lastNumberDrawn = numberDraw;
                MarkDrawnNumberOnCards(day04_1Input, numberDraw);
                winningBingoCard = GetWinningBingoCards(day04_1Input);
                if (winningBingoCard.Count > 0)
                {
                    break;
                }
            }

            winningBingoCard[0].PrintCard();

            return lastNumberDrawn * winningBingoCard[0].BingoNumbers.Sum(r => r.Sum(n => n.IsMarked ? 0 : n.Number));
        }

        private static void MarkDrawnNumberOnCards(Day04_1Object day04_1Input, int numberDraw)
        {
            foreach (var bingoCard in day04_1Input.BingoCards)
            {
                foreach (var row in bingoCard.BingoNumbers)
                {
                    foreach (var number in row)
                    {
                        if (!number.IsMarked && number.Number == numberDraw)
                        {
                            number.IsMarked = true;
                        }
                    }
                }
            }
        }

        private static List<Day04_1BingoCard> GetWinningBingoCards(Day04_1Object day04_1Input)
        {
            foreach (var bingoCard in day04_1Input.BingoCards)
            {
                foreach (var rowNumber in new List<int>{0,1,2,3,4,})
                {
                    if(bingoCard.BingoNumbers.All(bn => bn[rowNumber].IsMarked))
                    {
                        bingoCard.HasWon = true;
                    }
                }

                foreach (var row in bingoCard.BingoNumbers)
                {
                    if (row.All(n => n.IsMarked))
                    {
                        bingoCard.HasWon = true;
                    }
                }
            }

            return day04_1Input.BingoCards.Where(c => c.HasWon).ToList();
        }


        public static int Assignment2()
        {
            var day04_1Input = ReadInput("input1.txt");
            List<Day04_1BingoCard> winningBingoCards = new List<Day04_1BingoCard>();
            int lastNumberDrawn = 0;
            foreach (var numberDraw in day04_1Input.NumberDraws)
            {
                lastNumberDrawn = numberDraw;
                MarkDrawnNumberOnCards(day04_1Input, numberDraw);
                winningBingoCards = GetWinningBingoCards(day04_1Input);
                if (winningBingoCards.Count > 0)
                {
                    if (day04_1Input.BingoCards.Count == 1)
                    {
                        winningBingoCards[0].PrintCard();
                        return lastNumberDrawn * winningBingoCards[0].BingoNumbers.Sum(r => r.Sum(n => n.IsMarked ? 0 : n.Number));
                    }

                    foreach (var winningBingoCard in winningBingoCards)
                    {
                        day04_1Input.BingoCards.Remove(winningBingoCard);
                    }
                }
            }

            return lastNumberDrawn * winningBingoCards[0].BingoNumbers.Sum(r => r.Sum(n => n.IsMarked ? 0 : n.Number));
        }

        public static Day04_1Object ReadInput(string fileName)
        {
            var file = new StreamReader(FileReader.GetCurrentPath() + fileName);
            var lineCount = 0;
            List<int> numberDraws = new List<int>();

            string? line;
            List<Day04_1BingoCard> cards = new List<Day04_1BingoCard>();
            List<List<Day04_1BingoNumber>> numbers = new List<List<Day04_1BingoNumber>>();

            while ((line = file.ReadLine()) != null)
            {
                if (string.IsNullOrEmpty(line))
                {
                    if (numbers.Count > 0)
                    {
                        cards.Add(new Day04_1BingoCard(numbers));
                    }
                    numbers = new List<List<Day04_1BingoNumber>>();

                    lineCount++;
                    continue;
                }
                if (lineCount == 0)
                {
                    numberDraws = line.Split(',').Select(int.Parse).ToList();
                    lineCount++;
                    continue;
                }

                var lineItems = line.Split(' ').ToList();

                var numberRow = new List<Day04_1BingoNumber>();
                for (var index = 0; index < lineItems.Count; index++)
                {
                    if (!string.IsNullOrEmpty(lineItems[index]))
                    {
                        numberRow.Add(new Day04_1BingoNumber(int.Parse(lineItems[index])));
                    }
                }
                numbers.Add(numberRow);

                lineCount++;
            }
            cards.Add(new Day04_1BingoCard(numbers));

            file.Close();

            return new Day04_1Object(numberDraws, cards);
        }
    }
}