using Utils;

namespace Day0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length <= 1 || args[1] == "1")
            {
                Assignment1();
            }
            if (args.Length <= 1 || args[1] == "2")
            {
                Assignment2();
            }
        }

        public static int Assignment1()
        {
            var rule = FileReader.ReadFile<Day0_1Object>("input1.txt", ',');
            foreach (Day0_1Object o in rule)
            {
                Console.WriteLine(o.ToString());
            }
            return 1;
        }

        public static int Assignment2()
        {
            var rule = FileReader.ReadFile<Day0_2Object>("input2.txt", ';');
            foreach (Day0_2Object o in rule)
            {
                Console.WriteLine(o.ToString());
            }
            return 2;
        }
    }
}