namespace SlownikProjekt
{
    public class Translator
    {
        private DictionaryTranslator _dictionary;

        public event EventHandler<TranslationException>? TranslationError;

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
                try
                {
                    var t = _dictionary.TranslateWordEnglishToPolish(w) ?? throw new TranslationException(w);
                    output.Add(t);
                }
                catch (TranslationException ex)
                {
                    TranslationError?.Invoke(this, ex);

                    output.Add($"[{w}]"); 
                }
            }

            return string.Join(" ", output);
        }
    }
}