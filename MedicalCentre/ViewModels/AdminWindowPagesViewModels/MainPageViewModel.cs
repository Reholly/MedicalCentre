using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels
{
    internal class MainPageViewModel
    {
        private MainPage currentPage;
        public SeriesCollection SeriesCollection { get; set; }
        public ICommand? OpenNewFeaturesCommand { get; set; }
        public ICommand? OpenManageCommand { get; set; }
        public ICommand? OpenNewsCommand { get; set; }

        public MainPageViewModel(MainPage page)
        {
            currentPage = page;

            OpenNewsCommand = new RelayCommand(OpenNews);
            OpenManageCommand = new RelayCommand(OpenMail);
            OpenNewFeaturesCommand = new RelayCommand(OpenNewFeatures);

            DrawMainChart();
            DrawPieChart();
        }

        public void DrawMainChart()
        {
            var tranactionDb = new ContextRepository<Transaction>();

            List<Transaction> transactions = tranactionDb.GetTable();

            var minusTransaction = new ChartValues<double>();
            var plusTransaction = new ChartValues<double>();

            List<DateTime> dates = new List<DateTime>();

            foreach (var i in transactions)
            {
                if (i.Type == TransactionType.SalaryTransaction || i.Type == TransactionType.ItemAddTransaction)
                {
                    minusTransaction.Add(i.Price);
                    dates.Add(i.TransactionDate);
                }
                else if (i.Type == TransactionType.AppointmentTransaction || i.Type == TransactionType.ExaminationTransaction)
                {
                    plusTransaction.Add(i.Price);
                    dates.Add(i.TransactionDate);
                }
            }

            dates.Sort();

            List<string> lines = new List<string>();

            foreach (var i in dates)
            {
                lines.Add(i.ToString());
            }

            currentPage.series.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Доходы",

                    Values = plusTransaction
                },
                new LineSeries
                {
                    Title = "Расходы",
                    Values = minusTransaction,
                    PointGeometry = null
                },
            };

            currentPage.labels.Labels = lines.ToArray();
            currentPage.labelFormatter.LabelFormatter = value => value.ToString("C");
            currentPage.series.Series[1].Values.Add(20d);
        }

        public async void DrawPieChart()
        {
            var transactionDb = new ContextRepository<Transaction>();
            List<Transaction> transactions = await transactionDb.GetTableAsync();

            double examsTrans = 0;
            double appontmentsTrans = 0;
            double salaryTrans = 0;
            double addItemTrans = 0;

            foreach (Transaction item in transactions)
            {
                if (item.Type == TransactionType.SalaryTransaction) salaryTrans += item.Price;
                if (item.Type == TransactionType.AppointmentTransaction) appontmentsTrans += item.Price;
                if (item.Type == TransactionType.ExaminationTransaction) examsTrans += item.Price;
                if (item.Type == TransactionType.ItemAddTransaction) addItemTrans += item.Price;
            }

            currentPage.Chart.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Зарплаты",
                    Values =  new ChartValues<ObservableValue> { new ObservableValue(salaryTrans) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Приёмы",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(appontmentsTrans) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Услуги",

                    Values =  new ChartValues<ObservableValue> { new ObservableValue(examsTrans) },
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Расходники",
                    Values =  new ChartValues<ObservableValue> { new ObservableValue(addItemTrans) },
                    DataLabels = true
                }
            };
        }

        public void OpenNewFeatures()
        {
            OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.NewFeatures);
        }

        public void OpenNews()
        {
            OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.OpenHealthNews);
        }

        public void OpenMail()
        {
            OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.MainMail);
        }
    }
}