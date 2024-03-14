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
            await forbiddenWordsSearcher.CopyFoundFilesAsync();
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
