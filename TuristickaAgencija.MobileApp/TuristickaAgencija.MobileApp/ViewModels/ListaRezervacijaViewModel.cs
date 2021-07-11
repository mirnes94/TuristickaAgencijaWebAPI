using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Request;
using Xamarin.Forms;

namespace TuristickaAgencija.MobileApp.ViewModels
{
    public class ListaRezervacijaViewModel:BaseViewModel
    {
        private readonly APIService _putovanjaService = new APIService("Putovanja");
        private readonly APIService _rezervacijaService = new APIService("Rezervacija");

        public ListaRezervacijaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Rezervacija> RezervacijaList { get; set; } = new ObservableCollection<Rezervacija>();

        public ICommand InitCommand { get; set; }
        public Korisnici Korisnik { get; set; }

        public async Task OtkaziRezervaciju(int rezervacijaId)
        {
           
                var rezervacija = await _rezervacijaService.GetById<Model.Rezervacija>(rezervacijaId);
                var putovanje = await _putovanjaService.GetById<Model.Putovanja>((int)rezervacija.PutovanjeId);
            var trenutniDatumDan = DateTime.Now.Day;
            var datumPutovanjaDan = putovanje.DatumPolaska.Day;
            var trenutniDatumMjesec = DateTime.Now.Month;
            var datumPutovanjaMjesec = putovanje.DatumPolaska.Month;

            if (trenutniDatumMjesec < datumPutovanjaMjesec)
            {

                await _rezervacijaService.Delete<Model.Rezervacija>(rezervacijaId);
                await Application.Current.MainPage.DisplayAlert("Success", "Rezervacija je otkazana!", "OK");
            }
            else if (trenutniDatumMjesec == datumPutovanjaMjesec)
            {
                if ((datumPutovanjaDan - trenutniDatumDan) > 2)
                {
                    await _rezervacijaService.Delete<Model.Rezervacija>(rezervacijaId);
                    await Application.Current.MainPage.DisplayAlert("Success", "Rezervacija je otkazana!", "OK");
                }
                else
                await Application.Current.MainPage.DisplayAlert("Error", "Rezervaciju nije moguce otkazati!", "OK");
            }
                
            

        }
        public async Task Init()
        {
                       
                RezervacijaSearchRequest search = new RezervacijaSearchRequest();
                search.KorisnikId = LoggedInUser.ActiveUser.Id;

                var list = await _rezervacijaService.Get<List<Rezervacija>>(search);
           
            RezervacijaList.Clear();

                foreach (var item in list)
                {
                    RezervacijaList.Add(item);
                }
            

        }
    }
}
