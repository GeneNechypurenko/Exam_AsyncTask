public static class FormUpdater
{
    public static void DisplayForbiddenWords(DataFolderPaths dataFolderPaths, ListBox listBox)
    {
        string filePath = dataFolderPaths.GetSearchWordsFileEnsureCreated();

        string[] forbiddenWords = File.ReadAllLines(filePath);

        listBox.Items.Clear();

        foreach (string word in forbiddenWords)
        {
            listBox.Items.Add(word);
        }
    }
}