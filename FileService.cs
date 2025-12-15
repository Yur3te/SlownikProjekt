using System.IO;

namespace SlownikProjekt
{
    public static class FileService
    {
        public static void SaveText(string filename, string text)
        {
            File.WriteAllText(filename, text);
        }

        public static string LoadText(string filename)
        {
            return File.ReadAllText(filename);
        }
    }
}
