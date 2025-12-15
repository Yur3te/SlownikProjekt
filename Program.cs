// See https://aka.ms/new-console-template for more information
// Projekt 6. 
// Program automatycznie tłumaczący teksty z polskiego na angielski
// funkcjonalność: program ma rozumieć tylko 8 (słownik) słów i tłumaczyć słowa 1:1, bez żadnej gramatyki, Zakładamy, że tylko te 8 słów wystąpi w tłumaczonym tekście. Zlecenia przychodzą od klientów.
// 1. Zaprojektować odpowiednią strukturę klas - zastanowić się jakie klasy i jakie relacje między nimi będą potrzebne 
//   (słowo, słownik, tekst, klient, inne ???)
// 2. Zaimplementować w odpowiednich klasach metody umożliwiające tłumaczenie tekstów i wyszukiwanie informacji o już przetłumaczonych tekstach przy pomocy zapytań LINQ , w tym ile przetłumaczono tekstów zleconych przez każdego klienta oraz jaka była średnia długość tekstów zlecanych przez każdego z klientów.
// 3. Odczytujemy teksty do tłumaczenia z plików tekstowych i do plików tekstowych zapisujemy przetłumaczone teksty.
// 4. Za pomocą eventów wykonać powiadamianie klasy nadrzędnej o błędzie, jeśli w tekście będzie słowo spoza słownika.

// klasa tłumaczienie, tekst oryginalne, przetłumaczony i data do historii
// druga lista słów w słowniku pol ang - ang pol

using System;

namespace SlownikProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DictionaryTranslator dictionary = new DictionaryTranslator();
            Translator translator = new Translator(dictionary);
            TranslationManager manager = new TranslationManager(translator);
            
            Console.WriteLine("=== TŁUMACZ ===");

            
            while(true)
            {
                Console.WriteLine("1 - Tłumacz tekst");
                Console.WriteLine("2 - Pokaż historię tłumaczeń");
                Console.WriteLine("0 - Wyjście");
                Console.Write("Wybierz opcję: ");
                string input = Console.ReadLine();
                
                switch(input)
                {
                    case "1":
                        Console.Write("Podaj nazwę klienta: ");
                        string clientName = Console.ReadLine();
                        Client client = new Client(clientName);

                        Console.Write("Podaj ścieżkę pliku do tłumaczenia: ");
                        string inputPath = Console.ReadLine();
                        
                        if (!System.IO.File.Exists(inputPath))
                        {
                            Console.WriteLine("Plik nie istnieje!");
                            return;
                        }

                        Console.Write("Podaj ścieżkę docelowego pliku: ");
                        string outputPath = Console.ReadLine();

                        manager.TranslateForClient(client, inputPath, outputPath);
                        break;
                    
                    case "2":
                        List<TranslationRecord> history = manager.GetHistory();
                        if (history.Count == 0)
                        {
                            Console.WriteLine("Brak historii tłumaczeń.");
                        }
                        else
                        {
                            Console.WriteLine("Historia tłumaczeń:");
                            foreach (var record in history)
                            {
                                Console.WriteLine($"Klient: {record.Client.Name}, Oryginał: {record.OriginalText}, Tłumaczenie: {record.TranslatedText}");
                            }
                        }
                        break;
                    case "0":
                        return;


                }
            }


        }
    }

}


