using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Request;
using Xamarin.Forms;

namespace TuristickaAgencija.MobileApp.ViewModels
{
    public class RezervacijaViewModel:BaseViewModel
    {
        public ObservableCollection<PutovanjaDetaljiViewModel> PutovanjaList { get; set; } = new ObservableCollection<PutovanjaDetaljiViewModel>();
        //private readonly APIService _service = new APIService("Rezervacija");
        
       public Korisnici Korisnik{ get; set; }
       public Putovanja Putovanje { get; set; }
        /*
        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }


        int _brojOsoba = 0;
        public int BrojOsoba
        {
            get { return _brojOsoba; }
            set { SetProperty(ref _brojOsoba, value); }
        }

        string _status = string.Empty;
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        string _napomena = string.Empty;
        public string Napomena
        {
            get { return _napomena; }
            set { SetProperty(ref _napomena, value); }
        }

      */

        public void Init()
        {
            PutovanjaList.Clear();

            foreach(var item in RezervacijaService.Service.Values)
            {
                PutovanjaList.Add(item);
            }

           
        }
    }
}
