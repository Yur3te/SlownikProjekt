namespace SlownikProjekt
{
    public class TranslationRecord
    {
        public string OriginalText { get; set; }
        public string TranslatedText { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; }


        public TranslationRecord(Client client, string original, string translated)
        {
            OriginalText = original;
            TranslatedText = translated;
            Client = client;
            Date = DateTime.Now;
        }
   
    }
}