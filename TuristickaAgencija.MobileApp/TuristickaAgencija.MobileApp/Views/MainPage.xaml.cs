using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.MobileApp.Models;
using TuristickaAgencija.MobileApp.ViewModels;
using TuristickaAgencija.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristickaAgencija.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainViewModel model = null;
        public MainPage(Model.Korisnici korisnik)
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            BindingContext = model = new MainViewModel() { Korisnik=korisnik };

        }

        public async Task NavigateFromMenu(int id,Korisnici korisnik)
        {
            korisnik = model.Korisnik;
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Putovanja:
                        MenuPages.Add(id, new NavigationPage(new PutovanjaPage(korisnik)));
                        break;
                    case (int)MenuItemType.Welcome:
                        MenuPages.Add(id, new NavigationPage(new MainPageDetail()));
                        break;
                    case (int)MenuItemType.AboutUs:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;   
                    case (int)MenuItemType.Obavijesti:
                        MenuPages.Add(id, new NavigationPage(new ObavijestiPage()));
                        break;
                    case (int)MenuItemType.Uplate:
                        MenuPages.Add(id, new NavigationPage(new ListaUplataPage(korisnik)));
                        break;
                    case (int)MenuItemType.Rezervacije:
                        MenuPages.Add(id, new NavigationPage(new ListaRezervacijaPage(korisnik)));
                        break;
                    case (int)MenuItemType.Favoriti:
                        MenuPages.Add(id, new NavigationPage(new ListaZeljaPage(korisnik)));
                        break;

                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}