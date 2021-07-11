using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencija.Model;

namespace TuristickaAgencija.MobileApp.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        public Korisnici Korisnik { get; set; }
        string _korisnickoIme = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoIme; }
            set { SetProperty(ref _korisnickoIme, value); }
        }

        string _lozinka = string.Empty;
        public string Lozinka
        {
            get { return _lozinka; }
            set { SetProperty(ref _lozinka, value); }
        }
    }
}
