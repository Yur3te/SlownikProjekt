namespace SlownikProjekt
{
    public class Translator
    {
        private DictionaryTranslator _dictionary;

        public Translator(DictionaryTranslator dictionary)
        {
            _dictionary = dictionary;
        }

        public string TranslateText(string text)
        {
            var words = text.Split(' ');
            List<string> output = new();

            foreach (var w in words)
            {
                var t = _dictionary.TranslateWordEnglishToPolish(w) ?? throw new TranslationException(w);
                output.Add(t);
            }

            return string.Join(" ", output);
        }
    }
}