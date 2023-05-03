using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.PagesViewModels.AdminWindowPagesViewModels;

public class MainPageViewModel
{
    public SeriesCollection SeriesCollection { get; set; } = null!;
    public ICommand? OpenNewFeaturesCommand { get; set; }
    public ICommand? OpenManageCommand { get; set; }
    public ICommand? OpenNewsCommand { get; set; }

    private readonly MainPage currentPage;
    private readonly IRepository<Transaction> transactionRepository;

    public MainPageViewModel(MainPage page, IServiceProvider serviceProvider)
    {
        currentPage = page;
        transactionRepository = serviceProvider.GetRequiredService<IRepository<Transaction>>();

        OpenNewsCommand = new RelayCommand(OpenNews);
        OpenManageCommand = new RelayCommand(OpenMail);
        OpenNewFeaturesCommand = new RelayCommand(OpenNewFeatures);

        CreateAllCharts();
    }

    private async Task CreateAllCharts()
    {
        List<Transaction> transactions = await Task.Run(() => transactionRepository.GetTableAsync());

        await CreateMainChart(transactions);
        await CreatePieChart(transactions);
    }
    private async Task CreateMainChart(List<Transaction> transactions)
    {
        DistributeTransactions(transactions, out ChartValues<double> minusTransaction, out ChartValues<double> plusTransaction, out List<DateTime> dates);
        DrawMainChart(minusTransaction, plusTransaction, dates);
    }

    private async Task CreatePieChart(List<Transaction> transactions)
    {
        SortTransactionByTrans(transactions, out double examsTrans, out double appontmentsTrans, out double salaryTrans, out double addItemTrans);
        DrawPieChart(examsTrans, appontmentsTrans, salaryTrans, addItemTrans);
    }

    private void SortTransactionByTrans(List<Transaction> transactions, out double examsTrans, out double appontmentsTrans, out double salaryTrans, out double addItemTrans)
    {
        examsTrans = 0;
        appontmentsTrans = 0;
        salaryTrans = 0;
        addItemTrans = 0;
        foreach (Transaction item in transactions)
        {
            if (item.Type == TransactionType.SalaryTransaction) salaryTrans += item.Price;
            if (item.Type == TransactionType.AppointmentTransaction) appontmentsTrans += item.Price;
            if (item.Type == TransactionType.ExaminationTransaction) examsTrans += item.Price;
            if (item.Type == TransactionType.ItemAddTransaction) addItemTrans += item.Price;
        }
    }

    private void DistributeTransactions(List<Transaction> transactions, out ChartValues<double> minusTransaction, out ChartValues<double> plusTransaction, out List<DateTime> dates)
    {
        minusTransaction = new ChartValues<double>();
        plusTransaction = new ChartValues<double>();
        dates = new List<DateTime>();
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
    }

    private void DrawMainChart(ChartValues<double> minusTransaction, ChartValues<double> plusTransaction, List<DateTime> dates)
    {
        List<string> lines = new List<string>();

        foreach (var i in dates)
            lines.Add(i.ToString(CultureInfo.InvariantCulture));

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

    private void DrawPieChart(double examsTrans, double appontmentsTrans, double salaryTrans, double addItemTrans)
    {
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

    private void OpenNewFeatures() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.NewFeatures);
    
    private void OpenNews() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.OpenHealthNews);

    private void OpenMail() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.MainMail);
}