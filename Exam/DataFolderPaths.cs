using Microsoft.Extensions.Configuration;
using System.Diagnostics;

public class DataFolderPaths
{
    public string Data { get; set; }
    public string CopiedFiles { get; set; }
    public string SearchLogs { get; set; }
    public string SearchWords { get; set; }
    public string ForbiddenWordsFilePath { get; set; }
    public void BuildPathsRelativeToApplication()
    {
        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("AppSettings.json");

        IConfiguration configuration = configurationBuilder.Build();

        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        Data = Path.Combine(baseDirectory, configuration["appSettings:dataDirectory"]);
        CopiedFiles = Path.Combine(baseDirectory, configuration["appSettings:copiedFilesDirectory"]);
        SearchLogs = Path.Combine(baseDirectory, configuration["appSettings:searchLogsDirectory"]);
        SearchWords = Path.Combine(baseDirectory, configuration["appSettings:searchWordsDirectory"]);
        ForbiddenWordsFilePath = Path.Combine(SearchWords, "ForbiddenWords.txt");
    }
    public string GetSearchWordsFileEnsureCreated()
    {
        if (!File.Exists(ForbiddenWordsFilePath))
        {
            File.Create(ForbiddenWordsFilePath).Close();
        }
        return ForbiddenWordsFilePath;
    }

    public void OpenDataFolder()
    {
        Process.Start("explorer.exe", Data);
    }
}