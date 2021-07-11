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
    public class RezervacijaDetaljiViewModel:BaseViewModel
    {
        private readonly APIService _rezervacijaService = new APIService("Rezervacija");
        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _putovanjaService = new APIService("Putovanja");
        private readonly APIService _uplateService = new APIService("Uplate");
        public ObservableCollection<PutovanjaDetaljiViewModel> PutovanjaList { get; set; } = new ObservableCollection<PutovanjaDetaljiViewModel>();
        //public ObservableCollection<KorisniciDetaljiViewModel> KorisniciList { get; set; } = new ObservableCollection<KorisniciDetaljiViewModel>();

        public RezervacijaDetaljiViewModel()
        {
            InitCommand = new Command(async () => await Init());
            
            SacuvajRezervacijuCommand = new Command(async () => await SacuvajRezervaciju());
        }

    
        int _brojOsoba = 1;
        public int BrojOsoba
        {
            get { return _brojOsoba; }
            set { SetProperty(ref _brojOsoba, value); }
        }

        double _iznosUplate = 0;
        public double IznosUplate
        {
            get { return _iznosUplate; }
            set { SetProperty(ref _iznosUplate, value); }
        }

        string _napomena = string.Empty;
        public string Napomena
        {
            get { return _napomena; }
            set { SetProperty(ref _napomena, value); }
        }
        public Korisnici Korisnik { get; set; }
        public Putovanja Putovanje { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand SacuvajRezervacijuCommand { get; set; }
        public ICommand OtkaziRezervacijuCommand { get; set; }


        public async Task Init()
        {
            var korisnik = await _korisniciService.GetById<Model.Korisnici>(Korisnik.Id);
           

            PutovanjaList.Clear();
            foreach (var item in RezervacijaService.Service)
            {
                PutovanjaList.Add(item.Value);
            }
           
        
        }

        
        public async Task SacuvajRezervaciju()
        {
            var korisnik = await _korisniciService.GetById<Model.Korisnici>(Korisnik.Id);
            var putovanje = await _putovanjaService.GetById<Model.Putovanja>(Putovanje.Id);
            if (BrojOsoba<= putovanje.BrojMjesta)
            { 
                RezervacijaInsertUpdateRequest rezervacijaInsert = new RezervacijaInsertUpdateRequest
                {
                    DatumRezervacije = DateTime.Now,
                    Status = "Rezervisano",
                    BrojOsoba = BrojOsoba,
                    Ime = korisnik.KorisnickoIme,
                    KorisnikId = korisnik.Id,
                    Napomena = Napomena,
                    PutovanjeId = putovanje.Id
                };

                try
                {
                    var rezervacija = await _rezervacijaService.Insert<Model.Rezervacija>(rezervacijaInsert);

                    var minIznosUplate = (double)((float)(rezervacija.BrojOsoba * putovanje.CijenaPutovanja) / 2);


                    UplateInsertUpdateRequest uplataInsert = new UplateInsertUpdateRequest
                    {
                        DatumUplate = DateTime.Now,
                        Iznos = IznosUplate,
                        RezervacijaId = rezervacija.Id
                    };
                    var uplata = await _uplateService.Insert<Model.Uplate>(uplataInsert);

                    PutovanjaList.Clear();
                    RezervacijaService.Service.Clear();
                    await Application.Current.MainPage.DisplayAlert("Success", "Rezervacija je kreirana", "OK");


                    if (uplata.Iznos < minIznosUplate)
                    {
                        await Application.Current.MainPage.DisplayAlert("Warning", "Potrebno izvrsiti uplatu dodatnih " + (double)(minIznosUplate - uplata.Iznos) + "KM", "OK"); await Application.Current.MainPage.DisplayAlert("Success", "Potrebno izvrsiti uplatu dodatnih " + (double)(minIznosUplate - uplata.Iznos) + "KM", "OK");
                    }

                    int brojMjesta = putovanje.BrojMjesta - BrojOsoba;

                    PutovanjaInsertUpdateRequest putovanjaUpdate = new PutovanjaInsertUpdateRequest
                    {
                        BrojMjesta = brojMjesta,
                        CijenaPutovanja = putovanje.CijenaPutovanja,
                        DatumDolaska = putovanje.DatumDolaska,
                        DatumPolaska = putovanje.DatumPolaska,
                        GradId = putovanje.GradId,
                        NazivPutovanja = putovanje.NazivPutovanja,
                        OpisPutovanja = putovanje.OpisPutovanja,
                        PrevozId = putovanje.PrevozId,
                        Slika = putovanje.Slika,
                        SmjestajId = putovanje.SmjestajId
                    };
                    await _putovanjaService.Update<Model.Putovanja>(putovanje.Id, putovanjaUpdate);
                } catch(Exception ex) { 
                    await Application.Current.MainPage.DisplayAlert("Error","Neuspješna rezervacija", "OK");
                }

            
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Nije moguce izvrsiti rezervaciju zbog ograničenog broj mjesta", "OK");
                return;
            }
           
           
            }
           
        }
    }

