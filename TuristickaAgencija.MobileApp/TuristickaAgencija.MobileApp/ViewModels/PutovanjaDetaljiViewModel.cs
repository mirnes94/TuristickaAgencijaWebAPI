using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Request;
using Xamarin.Forms;

namespace TuristickaAgencija.MobileApp.ViewModels
{
    public class PutovanjaDetaljiViewModel:BaseViewModel
    {
        
        private readonly APIService _komentarService = new APIService("Komentar");
        private readonly APIService _ocjeneService = new APIService("Ocjene");
        private readonly APIService _listaZeljaService = new APIService("ListaZelja");
        private readonly APIService _recommenderService = new APIService("Recommender");
        public PutovanjaDetaljiViewModel()
        {
            
            InitCommand = new Command(async () => await Init());
            RezervisiCommand = new Command(async () =>await Rezervisi());
            KomentarCommand = new Command(async () => await Komentar());
            OcijenjenoSa1Command = new Command(async () => await Ocjena(1));
            OcijenjenoSa2Command = new Command(async () => await Ocjena(2));
            OcijenjenoSa3Command = new Command(async () => await Ocjena(3));
            OcijenjenoSa4Command = new Command(async () => await Ocjena(4));
            OcijenjenoSa5Command = new Command(async () => await Ocjena(5));
            RecommenderCommand = new Command(async () => await Recommender());

        }

        public Putovanja Putovanje { get; set; }
        public Korisnici Korisnik { get; set; }

        public ObservableCollection<Komentar> KomentariList { get; set; } = new ObservableCollection<Komentar>();
        public ObservableCollection<Ocjene> OcjeneList { get; set; } = new ObservableCollection<Ocjene>();
        public ObservableCollection<Putovanja> RecommenderList { get; set; } = new ObservableCollection<Putovanja>();

        public bool prviPut = false;

        string _sadrzajKomentara;
        public string SadrzajKomentara
        {
            get { return _sadrzajKomentara; }
            set { SetProperty(ref _sadrzajKomentara, value); }
        }
        double _prosjecnaOcjena;
        public double ProsjecnaOcjena
        {
            get { return _prosjecnaOcjena; }
            set { SetProperty(ref _prosjecnaOcjena, value); }
        }
        bool _ocijenjeno;
        public bool Ocijenjeno
        {
            get { return _ocijenjeno; }
            set { SetProperty(ref _ocijenjeno, value); }
        }
        bool _nijeOcijenjeno;
        public bool NijeOcijenjeno
        {
            get { return _nijeOcijenjeno; }
            set { SetProperty(ref _nijeOcijenjeno, value); }
        }

        bool _oznaceno;
        public bool Oznaceno
        {
            get { return _oznaceno; }
            set { SetProperty(ref _oznaceno, value); }
        }

      



        public ICommand RezervisiCommand { get; set; }
        public ICommand KomentarCommand { get; private set; }

        public ICommand OcijenjenoSa1Command { get; set; }
        public ICommand OcijenjenoSa2Command { get; set; }
        public ICommand OcijenjenoSa3Command { get; set; }
        public ICommand OcijenjenoSa4Command { get; set; }
        public ICommand OcijenjenoSa5Command { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand RecommenderCommand { get; set; }


        public async Task Recommender()
        {
            RecommenderList.Clear();
            List<Putovanja> putovanjalist = new List<Putovanja>();
            putovanjalist = await _recommenderService.GetRecommendedPutovanja<List<Putovanja>>(LoggedInUser.ActiveUser.Id);

            List<Ocjene> ocjenelist = new List<Ocjene>();
            ocjenelist = await _ocjeneService.Get<List<Ocjene>>(null);

            foreach (var item in putovanjalist)
            {

                RecommenderList.Add(item);
            }       
                
              
        }

        public async Task Init()
        {
            KomentariList.Clear();
            var listaOcjena = await _ocjeneService.Get<List<Model.Ocjene>>(null);
            var search = new KomentarSearchRequest { PutovanjeId=Putovanje.Id };
            var listaKomentara = await _komentarService.Get<List<Model.Komentar>>(search);
            foreach (var item in listaKomentara)
            {
                KomentariList.Add(item);
            }
            Ocijenjeno = false;
            foreach (var item in listaOcjena)
            {
                if (item.PutovanjeId==Putovanje.Id)
                {
                    OcjeneList.Add(item);
                    if (item.KorisnikId == LoggedInUser.ActiveUser.Id)
                    {
                        Ocijenjeno = true;
                    }
                }
            }

            NijeOcijenjeno = !Ocijenjeno;
            if (OcjeneList.Count() != 0)
            {
                ProsjecnaOcjena = OcjeneList.Select(s => s.Ocjena).Average();
            }
            else
            {
                ProsjecnaOcjena = 0;
            }

            ListaZeljaSearchRequest request = new ListaZeljaSearchRequest
            {
                PutovanjeId = Putovanje.Id,
                KorisnikId = LoggedInUser.ActiveUser.Id
                
            };

            try
            {
                ICollection<ListaZelja> listaZelja = await _listaZeljaService.Get<ICollection<ListaZelja>>(request);
                if (listaZelja.Count == 0)
                    Oznaceno = false;
                else
                {
                    prviPut = true;
                    Oznaceno = true;
                }
            }
            catch (Exception ex)
            {
                Oznaceno = false;
            }

        }
        public async Task DodajUListuZelja(bool item)
        {
            if (!item)
            {
                ListaZeljaSearchRequest request = new ListaZeljaSearchRequest
                {
                    PutovanjeId = Putovanje.Id,
                    KorisnikId = LoggedInUser.ActiveUser.Id
                };
                try
                {
                    IEnumerable<ListaZelja> listaZelja = await _listaZeljaService.Get<IEnumerable<ListaZelja>>(request);
                    foreach (var i in listaZelja)
                    {
                        await _listaZeljaService.Delete<Model.ListaZelja>(i.Id);
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
            else
            {
                ListaZeljaInsertUpdateRequest insertRequest = new ListaZeljaInsertUpdateRequest
                {
                    PutovanjeId = Putovanje.Id,
                    KorisnikId = LoggedInUser.ActiveUser.Id,
                    Opis=Putovanje.OpisPutovanja
                };
                try
                {
                    await _listaZeljaService.Insert<ListaZelja>(insertRequest);
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }

        private async Task Rezervisi()
        {
          
            if (RezervacijaService.Service.ContainsKey(Putovanje.Id))
            {
                RezervacijaService.Service.Remove(Putovanje.Id);
                await Application.Current.MainPage.DisplayAlert("Success", "Putovanje " + Putovanje.NazivPutovanja + " je uklonjeno iz korpe!", "OK");
                return;
            }
            RezervacijaService.Service.Add(Putovanje.Id, this);
            await Application.Current.MainPage.DisplayAlert("Success", "Putovanje " + Putovanje.NazivPutovanja + " je dodano u korpu!", "OK");
          
        }

        async Task Komentar()
        {
            if (!string.IsNullOrWhiteSpace(SadrzajKomentara))
            {
                var request = new KomentarInsertUpdateRequest()
                {
                    PutovanjeId = Putovanje.Id,
                    KorisnikId = LoggedInUser.ActiveUser.Id,
                    Sadrzaj = SadrzajKomentara,
                    Datum = DateTime.Now
                };
                var p = await _komentarService.Insert<Model.Komentar>(request);
                var search = new KomentarSearchRequest { PutovanjeId = Putovanje.Id};
                var kom = await _komentarService.Get<List<Model.Komentar>>(search);
                KomentariList.Add(kom[kom.Count - 1]);
                
            }
        }
        public async Task Ocjena(int ocjena)
        {
            Model.Request.OcjeneInsertUpdateRequest x = new Model.Request.OcjeneInsertUpdateRequest
            {
                PutovanjeId = Putovanje.Id,
                KorisnikId = LoggedInUser.ActiveUser.Id,
                Ocjena = ocjena,
                Datum = DateTime.Now
            };

            await _ocjeneService.Insert<Model.Ocjene>(x);
            Ocijenjeno = true;
            NijeOcijenjeno = false;
            await App.Current.MainPage.DisplayAlert("Uspjesno ocijenjeno", "", "OK");

        }

    }
}
