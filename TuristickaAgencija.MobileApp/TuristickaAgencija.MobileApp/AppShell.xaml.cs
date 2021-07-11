using System;
using System.Collections.Generic;
using TuristickaAgencija.MobileApp.ViewModels;
using TuristickaAgencija.MobileApp.Views;
using Xamarin.Forms;

namespace TuristickaAgencija.MobileApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(PutovanjaPage), typeof(PutovanjaPage));
            Routing.RegisterRoute(nameof(RezervacijaPage), typeof(RezervacijaPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
