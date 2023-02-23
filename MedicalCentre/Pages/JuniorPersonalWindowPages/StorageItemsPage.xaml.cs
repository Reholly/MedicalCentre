﻿using MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalCentre.Pages.JuniorPersonalWindowPages
{
    public partial class StorageItemsPage : Page
    {
        public StorageItemsPage()
        {
            InitializeComponent();
            DataContext = new StorageItemsPageViewModel();
        }
    }
}