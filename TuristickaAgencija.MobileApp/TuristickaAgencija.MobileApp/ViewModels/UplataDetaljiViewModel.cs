using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.MobileApp.Views;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Request;
using Xamarin.Forms;

namespace TuristickaAgencija.MobileApp.ViewModels
{
    class UplataDetaljiViewModel:BaseViewModel
    {
        private readonly APIService _rezervacijaService = new APIService("Rezervacija");
        private readonly APIService _uplateService = new APIService("Uplate");
        public UplataDetaljiViewModel()
        {
            InitCommand = new Command(async () => await Init());
            IzvrsiUplatuCommand = new Command(async () => await IzvrsiUplatu());

        }

      

        double _iznosUplate = 0;
        public double IznosUplate
        {
            get { return _iznosUplate; }
            set { SetProperty(ref _iznosUplate, value); }
        }
        int _rezervacijaId = 0;
        public int RezervacijaId
        {
            get { return _rezervacijaId; }
            set { SetProperty(ref _rezervacijaId, value); }
        }


        public Korisnici Korisnik { get; set; }
        public Rezervacija Rezervacija { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand IzvrsiUplatuCommand { get; set; }


        public ObservableCollection<Rezervacija> detaljiRezervacije { get; set; } = new ObservableCollection<Rezervacija>();
       
        public async Task Init()
        {
            var list = await _rezervacijaService.Get<List<Rezervacija>>(null);

            detaljiRezervacije.Clear();

            foreach (var item in list)
            {
                detaljiRezervacije.Add(item);
            }

        }

        public async Task IzvrsiUplatu()
        {

            DateTime datum = DateTime.Now;
            try
            {
                UplateInsertUpdateRequest uplataInsert = new UplateInsertUpdateRequest
                {
                    Datum = datum,
                    Iznos = IznosUplate,
                    RezervacijaId = RezervacijaId,
                    KorisnikId = LoggedInUser.ActiveUser.Id
                };
                if (uplataInsert.Iznos != 0 && uplataInsert.RezervacijaId != 0)
                {
                    await _uplateService.Insert<Model.Uplate>(uplataInsert);
                    Application.Current.MainPage = new MainPage(LoggedInUser.ActiveUser);
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Neuspješna uplata", "OK");
            }
            
        }
    }
}
