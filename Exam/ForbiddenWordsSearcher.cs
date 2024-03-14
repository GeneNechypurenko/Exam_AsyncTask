namespace ForbiddenWordsSearchApp
{
    public class ForbiddenWordsSearcher
    {
        private readonly AppConfig appConfig;

        public ForbiddenWordsSearcher(AppConfig config)
        {
            appConfig = config;
            LoadForbiddenWords();
        }

        public List<string> ForbiddenWords { get; private set; }

        private void LoadForbiddenWords()
        {
            ForbiddenWords = new List<string>();

            if (File.Exists(appConfig.DataFolder.ForbiddenWordsFilePath))
            {
                ForbiddenWords.AddRange(File.ReadAllLines(appConfig.DataFolder.ForbiddenWordsFilePath));
            }
        }

        public async Task AddForbiddenWordAsync(string enteredWord)
        {
            string filePath = appConfig.DataFolder.GetSearchWordsFileEnsureCreated();
            await File.AppendAllTextAsync(filePath, enteredWord + "\n");
            LoadForbiddenWords(); // Обновить список запрещенных слов после добавления нового слова
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
            LoadForbiddenWords(); // Обновить список запрещенных слов после удаления слов
        }
        public async Task CopyAndRenameFoundFilesAsync(List<string> forbiddenWords)
        {
            List<string> foundFiles = await FileSearcher.SearchFilesByForbiddenWords(appConfig.DataFolder);
            foreach (string sourceFilePath in foundFiles)
            {
                string originalFileName = Path.GetFileName(sourceFilePath);

                string originalDestinationFilePath = Path.Combine(appConfig.DataFolder.CopiedFiles, originalFileName);

                Thread.Sleep(200);
                await Task.Run(() => File.Copy(sourceFilePath, originalDestinationFilePath, true));

                string renamedFileName = originalFileName;
                foreach (string word in forbiddenWords)
                {
                    if (renamedFileName.Contains(word))
                    {
                        renamedFileName = renamedFileName.Replace(word, "@@@");
                    }
                }
                string renamedDestinationFilePath = Path.Combine(appConfig.DataFolder.CopiedFiles, renamedFileName);

                await Task.Run(() => File.Copy(sourceFilePath, renamedDestinationFilePath, true));
            }
        }

    }
}
