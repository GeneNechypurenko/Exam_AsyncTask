using ForbiddenWordsSearchApp;

namespace Exam
{
    public partial class MainForm : Form
    {
        private AppConfig appConfig;
        private ForbiddenWordsSearcher forbiddenWordsSearcher;
        private CancellationTokenSource cancellationTokenSource;
        private bool isPaused = false;
        public MainForm()
        {
            InitializeComponent();

            appConfig = new AppConfig();
            appConfig.DataFolder = new DataFolderPaths();
            appConfig.DataFolder.BuildPathsRelativeToApplication();
            appConfig.DataFolder.DataFoldersEnsureCreated();
            forbiddenWordsSearcher = new ForbiddenWordsSearcher(appConfig);
            FormUpdater.DisplayForbiddenWords(appConfig.DataFolder, searchWordsListBox);
            EnableControls();
        }
        private void EnableControls()
        {
            startButton.Enabled = true;
            pauseButton.Enabled = false;
            cancelButton.Enabled = false;
        }
        private void DisableControls()
        {
            startButton.Enabled = false;
            pauseButton.Enabled = true;
            cancelButton.Enabled = true;
        }
        private async void browseButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { appConfig.DataFolder.OpenDataFolder(); });
        }
        private async void startButton_Click(object sender, EventArgs e)
        {
            DisableControls();

            cancellationTokenSource = new CancellationTokenSource();

            statusProgressBar.Value = 0;
            statusLabel.Text = "0%";
            currentPathLabel.Text = "Searching...";

            try
            {
                List<string> foundFiles = await FileSearcher.SearchFilesByForbiddenWords(appConfig.DataFolder, cancellationTokenSource.Token);

                int totalFiles = foundFiles.Count;
                int filesProcessed = 0;

                foreach (string sourceFilePath in foundFiles)
                {
                    if (await PauseButtonPressed())

                    cancellationTokenSource.Token.ThrowIfCancellationRequested();

                    currentPathLabel.Text = $"Current Path: {sourceFilePath}";

                    int progressPercentage = (int)(((double)filesProcessed / totalFiles) * 100);
                    statusProgressBar.Value = progressPercentage;
                    statusLabel.Text = $"{progressPercentage}%";

                    await forbiddenWordsSearcher.CopyAndRenameFoundFilesAsync(forbiddenWordsSearcher.ForbiddenWords, cancellationTokenSource.Token);

                    filesProcessed++;
                }

                statusProgressBar.Value = 100;
                statusLabel.Text = "100%";
                currentPathLabel.Text = "Search Completed!";
            }
            catch (OperationCanceledException)
            {
                statusProgressBar.Value = 0;
                statusLabel.Text = "Cancelled";
                currentPathLabel.Text = "Search Cancelled!";
            }
            finally
            {
                EnableControls();
            }
        }
        private async Task<bool> PauseButtonPressed()
        {
            while (isPaused)
            {
                await Task.Delay(50);
            }
            return isPaused;
        }
        private void pauseButton_Click(object sender, EventArgs e)
        {
            if (pauseButton.Text == "PAUSE")
            {
                pauseButton.Text = "RESUME";
                isPaused = true;
            }
            else if (pauseButton.Text == "RESUME")
            {
                pauseButton.Text = "PAUSE";
                isPaused = false;
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancellationTokenSource.Cancel();
            EnableControls();
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
