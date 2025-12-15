using System.Text.Json;

namespace SlownikProjekt
{
    public class DictionaryTranslator
    {
        private List<Word> dictionary;

        private void LoadDictionary()
{
            string json = File.ReadAllText("dictionary.json");
            dictionary = JsonSerializer.Deserialize<List<Word>>(json);
        }
        
        public DictionaryTranslator()
        {
            LoadDictionary();
        }
        
        public string TranslateWordPolishToEnglish(string polish)
        {
            foreach (var w in dictionary)
            {
                if (w.Polish == polish)
                    return w.English;
            }
            return null;
        }

        public string TranslateWordEnglishToPolish(string english)
        {
            foreach (var w in dictionary)
            {
                if (w.English == english)
                    return w.Polish;
            }
            return null;
        }
    }
}
