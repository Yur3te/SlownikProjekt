namespace SlownikProjekt
{
    public class TextTask
    {
        public Client Client { get; }
        public string SourceText { get; }
        public string TranslatedText { get; set; }

        public TextTask(Client client, string sourceText)
        {
            Client = client;
            SourceText = sourceText;
        }
    }
}