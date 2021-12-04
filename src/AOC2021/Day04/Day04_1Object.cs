using System.Collections.Generic;

namespace Day04
{
    public class Day04_1Object
    {

        public Day04_1Object(List<int> numberDraws, List<Day04_1BingoCard> bingoCards)
        {
            NumberDraws = numberDraws;
            BingoCards = bingoCards;
        }

        public List<int> NumberDraws { get; set; }
        public List<Day04_1BingoCard> BingoCards { get; set; }
    }
}
