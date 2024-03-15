public static class ReportGenerator
{
    public static void GenerateReport(List<string> foundFiles, List<string> forbiddenWords, string reportLogFilePath)
    {
        using (StreamWriter writer = new StreamWriter(reportLogFilePath, true))
        {
            WriteReportHeader(writer);
            WriteFoundFiles(writer, foundFiles);
            WriteTopForbiddenWords(writer, foundFiles, forbiddenWords);
        }
    }
    private static void WriteReportHeader(StreamWriter writer)
    {
        writer.WriteLine("Report generated at: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        writer.WriteLine("===============================================");
    }
    private static void WriteFoundFiles(StreamWriter writer, List<string> foundFiles)
    {
        writer.WriteLine("Found Files:");
        foreach (string file in foundFiles)
        {
            writer.WriteLine($"- File: {file}");
        }
        writer.WriteLine("===============================================");
    }
    private static void WriteTopForbiddenWords(StreamWriter writer, List<string> foundFiles, List<string> forbiddenWords)
    {
        writer.WriteLine("Top 10 Forbidden Words:");

        var wordCounts = CountForbiddenWords(foundFiles, forbiddenWords);
        var top10Words = GetTop10Words(wordCounts);

        foreach (var pair in top10Words)
        {
            writer.WriteLine($"- {pair.Key}: {pair.Value} occurrences");
        }
        writer.WriteLine();
    }
    private static Dictionary<string, int> CountForbiddenWords(List<string> foundFiles, List<string> forbiddenWords)
    {
        var wordCounts = new Dictionary<string, int>();

        foreach (var file in foundFiles)
        {
            foreach (var word in forbiddenWords)
            {
                if (file.Contains(word))
                {
                    if (!wordCounts.ContainsKey(word))
                    {
                        wordCounts[word] = 0;
                    }
                    wordCounts[word]++;
                }
            }
        }
        return wordCounts;
    }
    private static IEnumerable<KeyValuePair<string, int>> GetTop10Words(Dictionary<string, int> wordCounts)
    {
        return wordCounts.OrderByDescending(pair => pair.Value).Take(10);
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