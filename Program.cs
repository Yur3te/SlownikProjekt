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
                Console.WriteLine("3 - Pokaż statystyki klientów");
                Console.WriteLine("4 - Wygeneruj wykres tłumaczeń w miesiącu");
                Console.WriteLine("0 - Wyjście");
                Console.Write("Wybierz opcję: ");
                string input = Console.ReadLine();
                
                switch(input)
                {
                    case "1":
                        Console.Write("Podaj nazwę klienta: ");
                        string clientName = Console.ReadLine();
                        Client client = new Client(clientName);

                        TranslationDirection direction;

                        while(true)
                        {
                            Console.WriteLine("Wybierz kierunek tłumaczenia:");
                            Console.WriteLine("1 - Polski --> Angielski");
                            Console.WriteLine("2 - Angielski --> Polski");

                            string directionInput = Console.ReadLine();

                            if (directionInput == "1")
                            {
                                direction = TranslationDirection.PolishToEnglish;
                                break;
                            }
                            else if (directionInput == "2")
                            {
                                direction = TranslationDirection.EnglishToPolish;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.\n");
                            }
                        }

                        var files = FileService.GetPossibleFiles();

                        if (files.Count == 0)
                        {
                            Console.WriteLine("Brak plików do tłumaczenia w folderze FilesToTranslate.");
                            break;
                        }

                        Console.WriteLine("Wybierz plik do tłumaczenia:");
                        for (int i = 0; i < files.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {files[i]}");
                        }

                        string fileNumber = Console.ReadLine();

                        bool isNumber = int.TryParse(fileNumber, out int choice);
                        bool isInRange = choice >= 1 && choice <= files.Count;

                        if (!isNumber || !isInRange)
                        {
                            Console.WriteLine("Nieprawidłowy wybór.");
                            return;
                        }


                        string inputFileName = files[choice - 1];
                        string inputPath = Path.Combine(FileService.FilesToTranslateDir, inputFileName);


                        Console.Write("Podaj nazwę pliku do zapisu tłumaczenia: ");
                        string outputFileName = Console.ReadLine();

                        manager.TranslateForClient(client, inputFileName, outputFileName, direction);
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
                                Console.WriteLine($"Klient: {record.ClientName}, Oryginał: {record.OriginalText}, Tłumaczenie: {record.TranslatedText}, Data: {record.Date}");
                            }
                        }
                        break;
                    case "3":
                        List<ClientStatistics> stats = manager.GetClientStatistics();
                        if (stats.Count == 0)
                        {
                            Console.WriteLine("Brak statystyk klientów.");
                        }
                        else
                        {
                            Console.WriteLine("Statystyki klientów:");
                            foreach (var stat in stats)
                            {
                                Console.WriteLine($"Klient: {stat.ClientName}, Liczba tłumaczeń: {stat.TranslationsCount}, Średnia długość tekstu: {stat.AverageTextLength}");
                            }
                        }
                        break;
                    case "4":
                        var monthlyStats = manager.GetMonthlyStatistics();
                        if (monthlyStats.Count == 0)
                        {
                            Console.WriteLine("Brak danych do wygenerowania wykresu.");
                        }
                        else
                        {
                            string chartPath = "translations_per_month.png";
                            ChartGenerator.GenerateMonthlyTranslationsChart(monthlyStats, chartPath);
                            Console.WriteLine($"Wykres zapisany do pliku: {chartPath}");
                        }
                        break;
                    case "0":
                        return;


                }
            }


        }
    }

}


