namespace SlownikProjekt
{
    public class MonthlyTranslationStats
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Count { get; set; }

        public string Label => $"{Month:D2}.{Year}";
    }
}
