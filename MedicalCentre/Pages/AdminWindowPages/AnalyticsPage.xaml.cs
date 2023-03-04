using ScottPlot;
using ScottPlot.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalCentre.Pages.AdminWindowPages
{
    /// <summary>
    /// Логика взаимодействия для Analytics.xaml
    /// </summary>
    public partial class AnalyticsPage : Page
    {
        public AnalyticsPage()
        {
            InitializeComponent();
            double[] x = { 200000, 294949, 10000, 455, 12444 };
            double[] y = { 0, 1, 2, 3 ,4 };


            MainChart.Plot.Title("Доходы/Развитие ");
            MainChart.Plot.AddScatter(y, x);
            MainChart.Plot.Style(new Blue1());
            MainChart.Refresh();
        }
    }
}
