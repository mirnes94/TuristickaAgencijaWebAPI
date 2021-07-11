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
    public partial class PutovanjaPage : ContentPage
    {
        PutovanjaViewModel model = null;
        public PutovanjaPage(Korisnici korisnik)
        {
            InitializeComponent();
            BindingContext = model = new PutovanjaViewModel() { Korisnik=korisnik};
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Putovanja;
            await Navigation.PushModalAsync(new NavigationPage(new PutovanjaDetaljiPage(item, model.Korisnik)));
         
        }
    }
}