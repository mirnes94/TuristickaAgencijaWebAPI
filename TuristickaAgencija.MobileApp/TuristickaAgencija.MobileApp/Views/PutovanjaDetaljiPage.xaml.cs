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
    public partial class PutovanjaDetaljiPage : ContentPage
    {
        private PutovanjaDetaljiViewModel model = null;
        public PutovanjaDetaljiPage(Putovanja putovanje, Korisnici korisnik)
        {
            InitializeComponent();
            BindingContext = model = new PutovanjaDetaljiViewModel()
            {
                Putovanje = putovanje,
                Korisnik=korisnik
            };
        }
           protected override async void OnAppearing()
        {
            base.OnAppearing();
            model.InitCommand.Execute(null);
            await model.Recommender();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RezervacijaPage(model.Korisnik,model.Putovanje));
            Navigation.RemovePage(this);
        }

        private async void KomentarButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(model.SadrzajKomentara))
            {
                model.InitCommand.Execute(null);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Greska", "Komentar ne smije biti prazan", "OK");
            }
        }
        private async void Switch_ListaZelja(object sender, ToggledEventArgs e)
        {
          
         
            var item = e.Value;
            if (!model.prviPut)
                await model.DodajUListuZelja(item);
            model.prviPut = false;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var putovanje = e.SelectedItem as Model.Putovanja;
            await Navigation.PushAsync(new PutovanjaDetaljiPage(putovanje,LoggedInUser.ActiveUser));
        }
    }
    }
