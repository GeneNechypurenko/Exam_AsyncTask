using ForbiddenWordsSearchApp;

namespace Exam
{
    public partial class MainForm : Form
    {
        private AppConfig appConfig;
        private ForbiddenWordsSearcher forbiddenWordsSearcher;

        public MainForm()
        {
            InitializeComponent();

            appConfig = new AppConfig();
            appConfig.DataFolder = new DataFolderPaths();
            appConfig.DataFolder.BuildPathsRelativeToApplication();
            appConfig.DataFolder.DataFoldersEnsureCreated();
            forbiddenWordsSearcher = new ForbiddenWordsSearcher(appConfig);
            FormUpdater.DisplayForbiddenWords(appConfig.DataFolder, searchWordsListBox);
        }
        private async void browseButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { appConfig.DataFolder.OpenDataFolder(); });
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            statusProgressBar.Value = 0;
            statusLabel.Text = "0%";
            currentPathLabel.Text = "Searching...";

            List<string> foundFiles = await FileSearcher.SearchFilesByForbiddenWords(appConfig.DataFolder);

            int totalFiles = foundFiles.Count;
            int filesProcessed = 0;

            foreach (string sourceFilePath in foundFiles)
            {
                currentPathLabel.Text = $"Current Path: {sourceFilePath}";

                int progressPercentage = (int)(((double)filesProcessed / totalFiles) * 100);
                statusProgressBar.Value = progressPercentage;
                statusLabel.Text = $"{progressPercentage}%";

                await forbiddenWordsSearcher.CopyAndRenameFoundFilesAsync(forbiddenWordsSearcher.ForbiddenWords);

                filesProcessed++;
            }
            statusProgressBar.Value = 100;
            statusLabel.Text = "100%";
            currentPathLabel.Text = "Search Completed!";
        }

        private async void pauseButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                // Ваш код для кнопки "Pause"
            });
        }

        private async void cancelButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                // Ваш код для кнопки "Cancel"
            });
        }
        private async void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string enteredWord = inputTextBox.Text.Trim();

                if (!string.IsNullOrEmpty(enteredWord))
                {
                    await forbiddenWordsSearcher.AddForbiddenWordAsync(enteredWord);
                    FormUpdater.DisplayForbiddenWords(appConfig.DataFolder, searchWordsListBox);
                }
                inputTextBox.Clear();
            }
        }
        private async void searchWordsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                await forbiddenWordsSearcher.RemoveSelectedWordsAsync(searchWordsListBox);
                FormUpdater.DisplayForbiddenWords(appConfig.DataFolder, searchWordsListBox);
            }
        }
    }
}
