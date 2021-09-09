using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.MobileApp.Models;
using TuristickaAgencija.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristickaAgencija.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public ListView ListView;
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        Korisnici korisnik;
        public MenuPage()
        {
            InitializeComponent();

            ListView = MenuItemsListView;
            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Welcome, Title="Welcome" },
                new HomeMenuItem {Id = MenuItemType.Profil, Title="Profil korisnika" },
                new HomeMenuItem {Id = MenuItemType.Putovanja, Title="Putovanja" },
                new HomeMenuItem {Id = MenuItemType.Obavijesti, Title="Obavijesti" },
                new HomeMenuItem {Id = MenuItemType.Rezervacije, Title="Rezervacije" },
                new HomeMenuItem {Id = MenuItemType.ListaUplata, Title="Lista Uplata" },
                new HomeMenuItem {Id = MenuItemType.Uplata, Title="Uplata" },
                new HomeMenuItem {Id = MenuItemType.Favoriti, Title="Favoriti" },
                new HomeMenuItem {Id = MenuItemType.AboutUs, Title="About Us" },
                
            };

            MenuItemsListView.ItemsSource = menuItems;

            MenuItemsListView.SelectedItem = menuItems[0];
            MenuItemsListView.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id, korisnik);
            };
        }
    }
}