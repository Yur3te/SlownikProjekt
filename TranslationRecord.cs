namespace SlownikProjekt
{
    public class TranslationRecord
    {
        public string OriginalText { get; set; }
        public string TranslatedText { get; set; }
        public DateTime Date { get; set; }
        public string ClientName { get; set; }

        public TranslationRecord() {}

        public TranslationRecord(Client client, string original, string translated)
        {
            OriginalText = original;
            TranslatedText = translated;
            ClientName = client.Name;
            Date = DateTime.Now;
        }
   
    }
}