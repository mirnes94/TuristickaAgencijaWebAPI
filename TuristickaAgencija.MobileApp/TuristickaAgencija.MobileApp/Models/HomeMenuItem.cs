using System;
using System.Collections.Generic;
using System.Text;

namespace TuristickaAgencija.MobileApp.Models
{
    public enum MenuItemType
    {
        Welcome,
        AboutUs,
        Obavijesti, 
        Putovanja,
        Rezervacije,
        Uplate,
        Favoriti
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
