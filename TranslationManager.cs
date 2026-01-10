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
            _history = HistoryStorage.Load();
        }

        private void OnTranslationError(object? sender, TranslationException e)
        {
            Console.WriteLine(e.Message);
        }


        public void TranslateForClient(Client client, string inputFileName, string outputFileName, TranslationDirection direction)
        {

            string text = FileService.LoadText(inputFileName);
            string translated = _translator.TranslateText(text, direction);

            FileService.SaveText(outputFileName, translated);
            
            _history.Add(new TranslationRecord(client, text, translated));
            HistoryStorage.Save(_history);
            

        }
        
        public List<TranslationRecord> GetHistory()
        {
            return _history;
        }

        public List<ClientStatistics> GetClientStatistics()
        {
            return _history
                .GroupBy(record => record.ClientName)
                .Select(group => new ClientStatistics
                {
                    ClientName = group.Key,
                    TranslationsCount = group.Count(),
                    AverageTextLength = group.Average(record => record.OriginalText.Length)
                })
                .ToList();
        }

    }
}