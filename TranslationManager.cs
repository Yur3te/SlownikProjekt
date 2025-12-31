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

        public void TranslateForClient(Client client, string inputFileName, string outputFileName)
        {
            try
            {
                string text = FileService.LoadText(inputFileName);
                string translated = _translator.TranslateText(text);

                FileService.SaveText(outputFileName, translated);
                
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