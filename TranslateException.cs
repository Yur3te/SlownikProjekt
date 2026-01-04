namespace SlownikProjekt
{
    public class TranslationException : Exception
    {
        public string Word { get; }

        public TranslationException(string word)
            : base($"Nieznane słowo: {word}")
        {
            Word = word;
        }
    }

}