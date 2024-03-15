using ForbiddenWordsSearchApp;

public static class FormUpdater
{
    public static void UpdateUI(string sourceFilePath, int totalFiles, int filesProcessed, Label currentPathLabel, ProgressBar statusProgressBar, Label statusLabel)
    {
        currentPathLabel.Text = $"Current Path: {sourceFilePath}";

        int progressPercentage = (int)(((double)filesProcessed / totalFiles) * 100);
        statusProgressBar.Value = progressPercentage;
        statusLabel.Text = $"{progressPercentage}%";
    }
    public static void UpdateReportAndUI(List<string> foundFiles, ForbiddenWordsSearcher forbiddenWordsSearcher, AppConfig appConfig, ListBox reportListBox)
    {
        ReportGenerator.GenerateReport(foundFiles, forbiddenWordsSearcher.ForbiddenWords, appConfig.DataFolder.ReportLogFilePath);
        UpdateReportListBox(appConfig, reportListBox);
    }
    public static void UpdateReportListBox(AppConfig appConfig, ListBox reportListBox)
    {
        List<string> reportLines = ReportGenerator.ReadReportLogFile(appConfig.DataFolder.ReportLogFilePath);
        reportListBox.Items.Clear();
        reportListBox.Items.AddRange(reportLines.ToArray());
    }
    public static void DisplayForbiddenWords(DataFolderPaths dataFolderPaths, ListBox listBox)
    {
        string filePath = dataFolderPaths.GetSearchWordsFileEnsureCreated();

        string[] forbiddenWords = File.ReadAllLines(filePath);

        listBox.Items.Clear();

        foreach (string word in forbiddenWords)
        {
            listBox.Items.Add(word);
        }
    }
}
