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

        public string TranslateText(string text, TranslationDirection direction)
        {
            var words = text.Split(' ');
            List<string> output = new();

            foreach (var w in words)
            {
                try
                {
                    string? translated;

                    if (direction == TranslationDirection.PolishToEnglish)
                    {
                        translated = _dictionary.TranslateWordPolishToEnglish(w);
                    }
                    else
                    {
                        translated = _dictionary.TranslateWordEnglishToPolish(w);
                    }

                    if (translated == null)
                    {
                        throw new TranslationException(w);
                    }

                    output.Add(translated);
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