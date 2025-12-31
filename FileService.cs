using System.IO;

namespace SlownikProjekt
{
    public static class FileService
    {
        public static readonly string FilesToTranslateDir = "FilesToTranslate";
        public static readonly string TranslationsDir = "Translations";

        public static void SaveText(string filename, string text)
        {
            string path = Path.Combine(TranslationsDir, filename);
            File.WriteAllText(path, text);
        }

        public static string LoadText(string filename)
        {
            string path = Path.Combine(FilesToTranslateDir, filename);
            return File.ReadAllText(path);
        }

        public static List<string> GetPossibleFiles()
        {
            if (!Directory.Exists(FilesToTranslateDir))
            {
                Directory.CreateDirectory(FilesToTranslateDir);
            }

            string[] files = Directory.GetFiles(FilesToTranslateDir);
            List<string> fileNames = new();

            foreach (var f in files)
            {
                fileNames.Add(Path.GetFileName(f));
            }

            return fileNames;
        }

    }
}
