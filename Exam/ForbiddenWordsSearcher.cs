namespace ForbiddenWordsSearchApp
{
    public class ForbiddenWordsSearcher
    {
        private readonly AppConfig appConfig;
        public ForbiddenWordsSearcher(AppConfig config)
        {
            appConfig = config;
        }
        public async Task AddForbiddenWordAsync(string enteredWord)
        {
            string filePath = appConfig.DataFolder.GetSearchWordsFileEnsureCreated();
            await File.AppendAllTextAsync(filePath, enteredWord + "\n");
        }
        public async Task RemoveSelectedWordsAsync(ListBox listBox)
        {
            string filePath = appConfig.DataFolder.GetSearchWordsFileEnsureCreated();

            List<string> selectedWords = new List<string>();
            foreach (var item in listBox.SelectedItems)
            {
                selectedWords.Add(item.ToString());
            }

            string[] allLines = await File.ReadAllLinesAsync(filePath);
            List<string> updatedLines = new List<string>(allLines);

            foreach (var word in selectedWords)
            {
                updatedLines.Remove(word);
            }

            await File.WriteAllLinesAsync(filePath, updatedLines);
        }
        public async Task CopyFoundFilesAsync()
        {
            List<string> foundFiles = await FileSearcher.SearchFilesByForbiddenWords(appConfig.DataFolder);

            string copiedFilesDirectory = appConfig.DataFolder.CopiedFiles;

            foreach (string sourceFilePath in foundFiles)
            {
                string fileName = Path.GetFileName(sourceFilePath);
                string destinationFilePath = Path.Combine(copiedFilesDirectory, fileName);

                await Task.Run(() => File.Copy(sourceFilePath, destinationFilePath, true));
            }
        }
    }
}