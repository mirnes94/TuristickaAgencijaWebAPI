using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.MobileApp.ViewModels;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Request;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristickaAgencija.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RezervacijaPage : ContentPage
    {
        RezervacijaViewModel model = null;
        APIService _service = new APIService("Rezervacije");
        public RezervacijaPage(Korisnici korisnik, Putovanja putovanje)
        {
            InitializeComponent();
            BindingContext = model = new RezervacijaViewModel() {
                Korisnik = korisnik,
                Putovanje=putovanje
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.Init();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            
            await Navigation.PushModalAsync(new NavigationPage(new PutovanjaPage(model.Korisnik)));
            //Navigation.RemovePage(this);
            await this.Navigation.PopAsync();

        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new NavigationPage(new RezervacijaDetaljiPage(model.Korisnik, model.Putovanje)));
        }
    }
}