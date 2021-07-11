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
    public partial class ListaRezervacijaPage : ContentPage
    {
        ListaRezervacijaViewModel model = null;
        public ListaRezervacijaPage(Korisnici korisnik)
        {
            InitializeComponent();
            BindingContext = model = new ListaRezervacijaViewModel() { Korisnik = korisnik };
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Rezervacija;
            await model.OtkaziRezervaciju(item.Id);
            await Navigation.PushAsync(new PutovanjaPage(model.Korisnik));
        }
    }
}