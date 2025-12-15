namespace SlownikProjekt
{
    public class TranslationManager
    {
        private Translator _translator;

        private List<TranslationRecord> _history = new();

        public event Action<string> OnError;

        public TranslationManager(Translator translator)
        {
            _translator = translator;
        }

        public void TranslateForClient(Client client, string inputPath, string outputPath)
        {
            try
            {
                string text = File.ReadAllText(inputPath);
                string translated = _translator.TranslateText(text);

                File.WriteAllText(outputPath, translated);

                _history.Add(new TranslationRecord(client, text, translated));
                
            }
            catch (TranslationException ex)
            {
                OnError?.Invoke(ex.Message);
            }
        }
        
        public List<TranslationRecord> GetHistory()
        {
            return _history;
        }


    }
}