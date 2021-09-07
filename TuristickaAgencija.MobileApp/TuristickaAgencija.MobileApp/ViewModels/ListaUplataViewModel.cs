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
    public class ListaUplataViewModel : BaseViewModel
    {
        private readonly APIService _uplateService = new APIService("Uplate");
        private readonly APIService _rezervacjijeService = new APIService("Rezervacija");
        public ListaUplataViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<Uplate> UplateList { get; set; } = new ObservableCollection<Uplate>();
        public ObservableCollection<Rezervacija> RezervacijaList { get; set; } = new ObservableCollection<Rezervacija>();
        public ICommand InitCommand { get; set; }
        public Korisnici Korisnik { get; set; }

        public async Task Init()
        {
            UplateSearchRequest search = new UplateSearchRequest { KorisnikId = LoggedInUser.ActiveUser.Id };
            var list = await _uplateService.Get<List<Uplate>>(search);
            var rezervacije = await _rezervacjijeService.Get<List<Rezervacija>>(null);
            UplateList.Clear();
            RezervacijaList.Clear();
            foreach (var item in list)
            {
                foreach (var r in rezervacije)
                {
                    if (item.RezervacijaId == r.Id)
                    {
                        RezervacijaList.Add(r);
                        UplateList.Add(item);
                    }
                }

            }
        }
    }
}
