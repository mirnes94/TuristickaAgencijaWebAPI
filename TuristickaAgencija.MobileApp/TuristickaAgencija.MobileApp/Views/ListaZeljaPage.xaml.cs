using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.MobileApp.ViewModels;
using TuristickaAgencija.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristickaAgencija.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaZeljaPage : ContentPage
    {
        ListaZeljaViewModel model = null;
        public ListaZeljaPage(Korisnici korisnik)
        {
            InitializeComponent();
            BindingContext = model = new ListaZeljaViewModel() { Korisnik = korisnik };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Putovanja;
            Application.Current.MainPage = new MainPage(LoggedInUser.ActiveUser);
            await model.Obrisi(item.Id);
        }
    }
}