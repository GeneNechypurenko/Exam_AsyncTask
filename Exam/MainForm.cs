using ForbiddenWordsSearchApp;
using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam
{
    public partial class MainForm : Form
    {
        private AppConfig appConfig;
        private FormUpdater formUpdater;
        private ForbiddenWordsSearcher forbiddenWordsSearcher;

        public MainForm()
        {
            InitializeComponent();

            appConfig = new AppConfig();
            appConfig.DataFolder = new DataFolderPaths();
            appConfig.DataFolder.BuildPathsRelativeToApplication();

            formUpdater = new FormUpdater(appConfig);
            formUpdater.DisplayForbiddenWords(searchWordsListBox);

            forbiddenWordsSearcher = new ForbiddenWordsSearcher(appConfig);
        }

        private async void browseButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { appConfig.DataFolder.OpenDataFolder(); });
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            //await Task.Run(() => { forbiddenWordsSearcher.SearchAndCopyFiles(infoLabel, statusProgressBar); });
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
                await Task.Run(() =>
                {
                    string enteredWord = inputTextBox.Text.Trim();

                    if (!string.IsNullOrEmpty(enteredWord))
                    {
                        forbiddenWordsSearcher.AddForbiddenWord(enteredWord);
                        formUpdater.DisplayForbiddenWords(searchWordsListBox);
                    }
                });
                inputTextBox.Clear();
            }
        }
        private async void searchWordsListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                await Task.Run(() =>
                {
                    forbiddenWordsSearcher.RemoveSelectedWords(searchWordsListBox);
                    formUpdater.DisplayForbiddenWords(searchWordsListBox);
                });
            }
        }
    }
}
