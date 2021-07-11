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
    public partial class ListaUplataPage : ContentPage
    {
        ListaUplataViewModel model = null;
        public ListaUplataPage(Korisnici korisnik)
        {
            InitializeComponent();
            BindingContext = model = new ListaUplataViewModel() { Korisnik = korisnik };
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
    }
}