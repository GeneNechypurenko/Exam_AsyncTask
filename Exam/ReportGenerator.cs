public static class ReportGenerator
{
    public static void GenerateReport(List<string> foundFiles, List<string> forbiddenWords, string reportLogFilePath)
    {
        using (StreamWriter writer = new StreamWriter(reportLogFilePath, true))
        {
            writer.WriteLine("Report generated at: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            writer.WriteLine("===============================================");
            writer.WriteLine("Found Files:");

            foreach (string file in foundFiles)
            {
                writer.WriteLine($"- File: {file}");
            }

            writer.WriteLine("===============================================");
            writer.WriteLine("Top 10 Forbidden Words:");

            var wordCounts = new Dictionary<string, int>();

            foreach (var word in forbiddenWords)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            var top10Words = wordCounts.OrderByDescending(pair => pair.Value).Take(10);

            foreach (var pair in top10Words)
            {
                writer.WriteLine($"- {pair.Key}: {pair.Value} occurrences");
            }
            writer.WriteLine();
        }
    }
    private static int CountWordOccurrencesInFile(string filePath, string word)
    {
        int count = 0;

        string text = File.ReadAllText(filePath);
        int index = text.IndexOf(word, StringComparison.OrdinalIgnoreCase);
        while (index != -1)
        {
            count++;
            index = text.IndexOf(word, index + word.Length, StringComparison.OrdinalIgnoreCase);
        }
        return count;
    }
    public static List<string> ReadReportLogFile(string reportLogFilePath)
    {
        List<string> lines = new List<string>();

        if (File.Exists(reportLogFilePath))
        {
            lines = File.ReadAllLines(reportLogFilePath).ToList();
        }

        return lines;
    }
}