public static class FileSearcher
{
    public static async Task<List<string>> SearchFilesByForbiddenWords(DataFolderPaths dataFolderPaths)
    {
        List<string> foundFiles = new List<string>();

        dataFolderPaths.GetSearchWordsFileEnsureCreated();

        string[] forbiddenWords = File.ReadAllLines(dataFolderPaths.ForbiddenWordsFilePath);

        DriveInfo[] removableDrives = DriveInfo.GetDrives()
            .Where(drive => drive.DriveType == DriveType.Removable)
            .ToArray();

        foreach (DriveInfo removableDrive in removableDrives)
        {
            string driveRoot = removableDrive.RootDirectory.FullName;

            foreach (string forbiddenWord in forbiddenWords)
            {
                string[] files = Directory.GetFiles(driveRoot, $"*{forbiddenWord.Trim()}*.*", SearchOption.AllDirectories);
                foundFiles.AddRange(files);
            }
        }
        return foundFiles.Distinct().ToList();
    }
}