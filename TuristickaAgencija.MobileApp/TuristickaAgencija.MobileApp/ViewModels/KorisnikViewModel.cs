using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.Model;
using Xamarin.Forms;

namespace TuristickaAgencija.MobileApp.ViewModels
{
   public class KorisnikViewModel:BaseViewModel
    {
        private readonly APIService _korisniciService = new APIService("Korisnici");
        private readonly APIService _obavijestiService = new APIService("Obavijesti");
        private readonly APIService _komentariService = new APIService("Komentar");
        private readonly APIService _rezervacijeService = new APIService("Rezervacija");
        public KorisnikViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Korisnici> KorisniciList { get; set; } = new ObservableCollection<Korisnici>();
       
        public ICommand InitCommand { get; set; }
        public Korisnici Korisnik { get; set; }

        public async Task Obrisi(Korisnici korisnik)
        {

            IEnumerable<Korisnici> listaKorisnika = await _korisniciService.Get<IEnumerable<Korisnici>>(null);
            IEnumerable<Obavijesti> listaObavijesti = await _obavijestiService.Get<IEnumerable<Obavijesti>>(null);
            IEnumerable<Komentar> listaKomentara = await _komentariService.Get<IEnumerable<Komentar>>(null);
            IEnumerable<Rezervacija> listaRezervacija = await _rezervacijeService.Get<IEnumerable<Rezervacija>>(null);
          
                foreach (var o in listaObavijesti)
                {
                    if(o.KorisnikId==LoggedInUser.ActiveUser.Id)
                        await _obavijestiService.Delete<Model.Obavijesti>(o.Id);
                }
            foreach (var o in listaKomentara)
            {
                if (o.KorisnikId == LoggedInUser.ActiveUser.Id)
                    await _komentariService.Delete<Model.Komentar>(o.Id);
            }
            foreach (var o in listaRezervacija)
            {
                if (o.KorisnikId == LoggedInUser.ActiveUser.Id)
                    await _rezervacijeService.Delete<Model.Rezervacija>(o.Id);
            }



            foreach (var i in listaKorisnika)
            {            
                if (i.KorisnickoIme == korisnik.KorisnickoIme)
                {

                    await _korisniciService.Delete<Model.Korisnici>(i.Id);
                }
            }

            await Application.Current.MainPage.DisplayAlert("Success", "Obrisali ste Vas racun", "OK");


        }
        public async Task Init()
        {
                  
            var korisnici = await _korisniciService.Get<List<Korisnici>>(null);
            KorisniciList.Clear();
          
            foreach (var item in korisnici)
            {
                if (item.KorisnickoIme == LoggedInUser.ActiveUser.KorisnickoIme)
                    KorisniciList.Add(item);
            }
        }
    }
}

