using System.Collections.Generic;

namespace Day01
{
    public class InfiToyObject
    {
        public InfiToyObject(string toyName, List<KeyValuePair<string, int>> components)
        {
            ToyName = toyName;
            Components = components;
        }

        public string ToyName { get; set; }
        public List<KeyValuePair<string, int>> Components { get; set; }
    }
}
