using System.Text.Json;

namespace SlownikProjekt
{
    public static class HistoryStorage
    {
        private static string FilePath = "history.json";

        public static List<TranslationRecord> Load()
        {
            if (!File.Exists(FilePath))
                return new List<TranslationRecord>();

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<TranslationRecord>>(json)
                   ?? new List<TranslationRecord>();
        }

        public static void Save(List<TranslationRecord> history)
        {
            string json = JsonSerializer.Serialize(history, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(FilePath, json);
        }
    }
}
