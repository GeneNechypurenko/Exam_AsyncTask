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
            InitializeAppConfig();
            InitializeForbiddenWordsSearcher();
            EnableControls();
            FormUpdater.UpdateReportListBox(appConfig, reportListBox);
        }
        private void InitializeAppConfig()
        {
            appConfig = new AppConfig();
            appConfig.DataFolder = new DataFolderPaths();
            appConfig.DataFolder.BuildPathsRelativeToApplication();
            appConfig.DataFolder.DataFoldersEnsureCreated();
            FormUpdater.DisplayForbiddenWords(appConfig.DataFolder, searchWordsListBox);
        }
        private void InitializeForbiddenWordsSearcher()
        {
            forbiddenWordsSearcher = new ForbiddenWordsSearcher(appConfig);
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
                List<string> foundFiles = await SearchFilesAsync(cancellationTokenSource.Token);

                FormUpdater.UpdateReportAndUI(foundFiles, forbiddenWordsSearcher, appConfig, reportListBox);

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
        private async Task<List<string>> SearchFilesAsync(CancellationToken cancellationToken)
        {
            List<string> foundFiles = await FileSearcher.SearchFilesByForbiddenWords(appConfig.DataFolder, cancellationToken);

            int totalFiles = foundFiles.Count;
            int filesProcessed = 0;

            foreach (string sourceFilePath in foundFiles)
            {
                while (isPaused)
                {
                    await Task.Delay(50);
                    cancellationToken.ThrowIfCancellationRequested();

                    if (isPaused)
                    {
                        continue;
                    }
                }
                cancellationToken.ThrowIfCancellationRequested();

                FormUpdater.UpdateUI(sourceFilePath, totalFiles, filesProcessed, currentPathLabel, statusProgressBar, statusLabel);

                cancellationToken = new CancellationTokenSource().Token;

                await forbiddenWordsSearcher.CopyAndRenameFoundFilesAsync(forbiddenWordsSearcher.ForbiddenWords, cancellationToken);

                filesProcessed++;
            }
            return foundFiles;
        }
        private async void pauseButton_Click(object sender, EventArgs e)
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

                if (cancellationTokenSource != null)
                {
                    cancellationTokenSource.Cancel();
                }
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
