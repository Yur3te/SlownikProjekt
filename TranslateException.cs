namespace SlownikProjekt
{
    public class TranslationException : Exception
    {
        public TranslationException(string word)
            : base($"Nieznane słowo: {word}")
        {
            
        }
    }

}