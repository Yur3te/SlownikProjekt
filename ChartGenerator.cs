using ScottPlot;

namespace SlownikProjekt
{
    public static class ChartGenerator
    {
        public static void GenerateMonthlyTranslationsChart(
            List<MonthlyTranslationStats> stats,
            string outputPath)
        {
            if (stats.Count == 0)
                return;

            double[] values = stats.Select(s => (double)s.Count).ToArray();
            string[] labels = stats.Select(s => s.Label).ToArray();

            var plot = new Plot();

            var bars = plot.Add.Bars(values);

            plot.Axes.Bottom.SetTicks(
                Enumerable.Range(0, labels.Length).Select(i => (double)i).ToArray(),
                labels
            );

            plot.Title("Liczba tłumaczeń w miesiącu");
            plot.Axes.Left.Label.Text = "Liczba tłumaczeń";
            plot.Axes.Bottom.Label.Text = "Miesiąc";

            plot.SavePng(outputPath, 900, 500);
        }
    }
}
