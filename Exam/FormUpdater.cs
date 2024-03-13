using System;
using System.IO;
using System.Windows.Forms;

namespace ForbiddenWordsSearchApp
{
    public class FormUpdater
    {
        private readonly AppConfig appConfig;

        public FormUpdater(AppConfig config)
        {
            appConfig = config;
        }

        public void DisplayForbiddenWords(ListBox listBox)
        {
            string searchWordsPath = Path.Combine(appConfig.DataFolder.Data, "SearchWords");
            string filePath = Path.Combine(searchWordsPath, "ForbiddenWords.txt");

            try
            {
                if (File.Exists(filePath))
                {
                    string[] forbiddenWords = File.ReadAllLines(filePath);
                    listBox.Items.Clear();
                    foreach (string word in forbiddenWords)
                    {
                        listBox.Items.Add(word);
                    }
                }
                else
                {
                    MessageBox.Show("Файл ForbiddenWords.txt не существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}