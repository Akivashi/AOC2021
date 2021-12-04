namespace Day04
{
    public class Day04_1BingoNumber
    {
        public Day04_1BingoNumber(int number)
        {
            Number = number;
            IsMarked = false;
        }

        public int Number { get; set; }
        public bool IsMarked { get; set; }
    }
}
