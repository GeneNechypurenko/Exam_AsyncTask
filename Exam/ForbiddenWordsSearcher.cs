using System;
using System.IO;
using System.Windows.Forms;

namespace ForbiddenWordsSearchApp
{
    public class ForbiddenWordsSearcher
    {
        private readonly AppConfig appConfig;
        public ForbiddenWordsSearcher(AppConfig config)
        {
            appConfig = config;
        }

        public void AddForbiddenWord(string enteredWord)
        {
            try
            {
                string filePath = appConfig.DataFolder.GetSearchWordsFileEnsureCreated();
                File.AppendAllText(filePath, enteredWord + "\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RemoveSelectedWords(ListBox listBox)
        {
            try
            {
                string filePath = appConfig.DataFolder.GetSearchWordsFileEnsureCreated();

                List<string> selectedWords = new List<string>();
                foreach (var item in listBox.SelectedItems)
                {
                    selectedWords.Add(item.ToString());
                }

                string[] allLines = File.ReadAllLines(filePath);
                List<string> updatedLines = new List<string>(allLines);

                foreach (var word in selectedWords)
                {
                    updatedLines.Remove(word);
                }

                File.WriteAllLines(filePath, updatedLines);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении из файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
