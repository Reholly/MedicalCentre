﻿using MedicalCentre.Authentification;
using MedicalCentre.Models;
using MedicalCentre.Pages.GeneralPages;
using MedicalCentre.Windows;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MedicalCentre.ViewModels
{
    public class JuniorPersonalViewModel
    {
        private readonly JuniorPersonalWindow _window;
        private readonly Account _account;
        public ICommand ShowStorageItemsCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public JuniorPersonalViewModel(JuniorPersonalWindow window, Account account)
        {
            this._window = window;
            this._account = account;
            ShowStorageItemsCommand = new RelayCommand(ShowStorageItems);
            LogoutCommand = new RelayCommandAsync(Close);
        }

        private void ShowStorageItems() => _window.frame.Content = new StoragePage();

        private async Task Close()
        {
            AuthentificationService authentification = new();
            await authentification.LogOut(_window, _account);
        }
    }
}