namespace CleanCodeSetup
{
    public class Program
    {
        private static readonly int untilDay = 1;

        public static void Main(string[] args)
        {
            var AOCDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()))));
            var sourceSuffix = "Day0";

            var solutionFilePath = AOCDirectory + "\\AOC2021.sln";
            var txtLines = File.ReadAllLines(solutionFilePath).ToList();
            var originalLine = txtLines.First(line => line.Contains("\"" + sourceSuffix + "\""));
            var originalIdentifier = originalLine.Split(',')[2].Trim().Replace("\"", "");

            var originalDebugLine1 = txtLines.First(line => line.Contains(originalIdentifier + ".Debug|Any CPU.ActiveCfg"));
            var originalDebugLine2 = txtLines.First(line => line.Contains(originalIdentifier + ".Debug|Any CPU.Build"));
            var originalReleaseLine1 = txtLines.First(line => line.Contains(originalIdentifier + ".Release|Any CPU.ActiveCfg"));
            var originalReleaseLine2 = txtLines.First(line => line.Contains(originalIdentifier + ".Release|Any CPU.Build"));

            for (var i = 1; i <= untilDay; i++)
            {
                var targetSuffix = (i < 10 ? "Day0" : "Day") + i;
                if (!string.IsNullOrEmpty(txtLines.FirstOrDefault(line => line.Contains("\"" + targetSuffix + "\""))))
                {
                    continue;
                }

                var targetDirectory = AOCDirectory + "\\" + targetSuffix;
                Directory.CreateDirectory(targetDirectory);
                foreach (string newPath in Directory.GetFiles(AOCDirectory + "\\Day0", "*.*", SearchOption.TopDirectoryOnly))
                {
                    File.Copy(newPath, newPath.Replace(sourceSuffix, targetSuffix), true);
                }

                var projectItems = originalLine.Split(',');
                var newIdentifier = "{" + Guid.NewGuid().ToString().ToUpper() + "}";

                projectItems[0] = projectItems[0].Replace(sourceSuffix, targetSuffix);
                projectItems[1] = projectItems[1].Replace(sourceSuffix, targetSuffix);
                projectItems[2] = " \"" + newIdentifier + "\"";
                var originalLineNumber = txtLines.IndexOf(originalLine);

                txtLines.Insert(originalLineNumber + 2 + ((i-1) * 2), string.Join(',', projectItems));
                txtLines.Insert(originalLineNumber + 3 + ((i-1) * 2), "EndProject");

                txtLines.Insert(originalLineNumber + 14 + ((i - 1) * 2), originalDebugLine1.Replace(originalIdentifier, newIdentifier));
                txtLines.Insert(originalLineNumber + 15 + ((i - 1) * 2), originalDebugLine2.Replace(originalIdentifier, newIdentifier));
                txtLines.Insert(originalLineNumber + 16 + ((i - 1) * 2), originalReleaseLine1.Replace(originalIdentifier, newIdentifier));
                txtLines.Insert(originalLineNumber + 17 + ((i - 1) * 2), originalReleaseLine2.Replace(originalIdentifier, newIdentifier));

                File.WriteAllLines(solutionFilePath, txtLines);
            }
        }
    }
}