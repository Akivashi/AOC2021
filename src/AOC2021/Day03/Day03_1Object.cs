using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    public class Day03_1Object
    {
        public Day03_1Object(string binarynumbers)
        {
            Binarynumbers = binarynumbers.ToCharArray().Select(c => c.Equals('1')).ToList();
        }

        private Day03_1Object(List<bool> binarynumbers)
        {
            Binarynumbers = binarynumbers;
        }

        public List<bool> Binarynumbers { get; set; }



        public Day03_1Object Clone()
        {
            return new Day03_1Object(Binarynumbers);
        }
    }
}
