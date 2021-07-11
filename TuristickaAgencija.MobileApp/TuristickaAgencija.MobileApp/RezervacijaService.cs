using System;
using System.Collections.Generic;
using System.Text;
using TuristickaAgencija.MobileApp.ViewModels;

namespace TuristickaAgencija.MobileApp
{
    public static class RezervacijaService
    {
        public static Dictionary<int, PutovanjaDetaljiViewModel> Service { get; set; } = new Dictionary<int, PutovanjaDetaljiViewModel>();
    }
}
