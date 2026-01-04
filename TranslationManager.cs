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
            _translator.TranslationError += OnTranslationError;
        }

        private void OnTranslationError(object? sender, TranslationException e)
        {
            Console.WriteLine(e.Message);
        }


        public void TranslateForClient(Client client, string inputFileName, string outputFileName)
        {

            string text = FileService.LoadText(inputFileName);
            string translated = _translator.TranslateText(text);

            FileService.SaveText(outputFileName, translated);
            
            _history.Add(new TranslationRecord(client, text, translated));
            

        }
        
        public List<TranslationRecord> GetHistory()
        {
            return _history;
        }


    }
}