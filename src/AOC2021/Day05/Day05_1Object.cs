using System;
using System.Collections.Generic;

namespace Day05
{
    public class Day05_1Object
    {
        public Day05_1Object(int height, int width, List<Day05_1Vector> vectors)
        {
            var board = new List<List<int>>();
            for (var y = 0; y <= height; y++)
            {
                var row = new List<int>();
                for (var x = 0; x <= width; x++)
                {
                    row.Add(0);
                }
                board.Add(row);
            }

            Board = board;
            Vectors = vectors;
        }

        public List<List<int>> Board { get; set; }
        public List<Day05_1Vector> Vectors { get; set; }

        public void TryDrawHorizontalLine(Day05_1Vector vector)
        {
            if (vector.X1 == vector.X2 || (vector.X1 != vector.X2 && vector.Y1 != vector.Y2))
            {
                return;
            }

            var lower = Math.Min(vector.X1, vector.X2);
            var upper = Math.Max(vector.X1, vector.X2);
            for (var x = lower; x <= upper; x++)
            {
                Board[vector.Y1][x]++;
            }
        }

        public void TryDrawVerticalLine(Day05_1Vector vector)
        {
            if (vector.Y1 == vector.Y2 || (vector.X1 != vector.X2 && vector.Y1 != vector.Y2))
            {
                return;
            }

            var lower = Math.Min(vector.Y1, vector.Y2);
            var upper = Math.Max(vector.Y1, vector.Y2);
            for (var y = lower; y <= upper; y++)
            {
                Board[y][vector.X1]++;
            }
        }

        public void TryDrawDiagonal(Day05_1Vector vector)
        {
            if (vector.X1 == vector.X2 || vector.Y1 == vector.Y2)
            {
                return;
            }

            if (vector.X1 < vector.X2 && vector.Y1 < vector.Y2)
            {
                var originalY = vector.Y1;
                for (var x = vector.X1; x <= vector.X2; x++)
                {
                    Board[originalY][x]++;
                    originalY++;
                }
            }
            else if (vector.X1 < vector.X2 && vector.Y1 > vector.Y2)
            {
                var originalY = vector.Y1;
                for (var x = vector.X1; x <= vector.X2; x++)
                {
                    Board[originalY][x]++;
                    originalY--;
                }
            }
            else if (vector.X1 > vector.X2 && vector.Y1 < vector.Y2)
            {
                var originalY = vector.Y1;
                for (var x = vector.X1; x >= vector.X2; x--)
                {
                    Board[originalY][x]++;
                    originalY++;
                }
            }
            else if (vector.X1 > vector.X2 && vector.Y1 > vector.Y2)
            {
                var originalY = vector.Y1;
                for (var x = vector.X1; x >= vector.X2; x--)
                {
                    Board[originalY][x]++;
                    originalY--;
                }
            }
        }

        public void PrintBoard()
        {
            for (var y = 0; y < Board.Count; y++)
            {
                var row = Board[y];
                for (var x = 0; x < row.Count; x++)
                {
                    if (Board[y][x] > 1)
                    {
                        Console.BackgroundColor  = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.Write(Board[y][x]);
                }
                Console.WriteLine("");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("--");
        }
    }
}
