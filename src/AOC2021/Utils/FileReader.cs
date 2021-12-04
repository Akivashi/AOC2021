using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Utils
{
    public static class FileReader
    {
        public static List<T> ReadFile<T>(string fileName, char delimiter)
        {
            var listOfObjects = new List<T>();

            var file = new StreamReader(GetCurrentPath() + fileName);
            var lineCount = 0;
            List<string> firstLineItems = new List<string>();

            string? line;
            while ((line = file.ReadLine()) != null)
            {
                var lineItems = line.Split(delimiter).ToList();

                if (lineCount == 0)
                {
                    firstLineItems = lineItems;
                    lineCount++;
                    continue;
                }

                var obj = new Dictionary<string, object>();
                for (var index = 0; index < lineItems.Count; index++)
                {
                    obj.Add(firstLineItems[index], lineItems[index]);
                }

                var item = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(obj));

                if(item != null) {
                    listOfObjects.Add(item);
                }
                else
                {
                    throw new Exception("item was empty");
                }

                lineCount++;
            }

            file.Close();
            return listOfObjects;
        }

        public static string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory() + "\\";
        }
    }
}