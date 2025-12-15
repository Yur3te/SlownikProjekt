namespace SlownikProjekt
{
    public class Word
    {
        public string Polish { get; set; }
        public string English { get; set; }

        public Word(string polish, string english)
        {
            Polish = polish;
            English = english;
        }

        public Word() {}
    }
}

