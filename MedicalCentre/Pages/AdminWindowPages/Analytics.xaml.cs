using ScottPlot.Styles;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages
{
    public partial class AnalyticsPage : Page
    {
        public AnalyticsPage()
        {
            InitializeComponent();
            double[] x = { 200000, 294949, 10000, 455, 12444 };
            double[] y = { 0, 1, 2, 3, 4 };

            MainChart.Plot.Title("Доходы/Развитие ");
            MainChart.Plot.AddScatter(y, x);
            MainChart.Plot.Style(new Blue1());
            MainChart.Refresh();
        }
    }
}