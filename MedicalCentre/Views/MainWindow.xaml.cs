﻿using MedicalCentre.ViewModels;
using System;
using System.Windows;
using MedicalCentre.ViewModels.MainPagesViewModels;

namespace MedicalCentre.Views;

public partial class MainWindow : Window
{
    public MainWindow(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        DataContext = new MainViewModel(this, serviceProvider);
    }
}