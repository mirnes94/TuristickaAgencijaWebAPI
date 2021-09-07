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
    public class ListaZeljaViewModel : BaseViewModel
    {
        private readonly APIService _listaZeljaService = new APIService("ListaZelja");
        private readonly APIService _putovanjaService = new APIService("Putovanja");
        public ListaZeljaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<ListaZelja> ListaZeljaList { get; set; } = new ObservableCollection<ListaZelja>();
        public ObservableCollection<Putovanja> PutovanjaList { get; set; } = new ObservableCollection<Putovanja>();
        public ICommand InitCommand { get; set; }
        public Korisnici Korisnik { get; set; }

        public async Task Obrisi(int putovanjeId)
        {

            IEnumerable<ListaZelja> listaZelja = await _listaZeljaService.Get<IEnumerable<ListaZelja>>(null);
         
            foreach (var i in listaZelja)
            {
                if(i.PutovanjeId==putovanjeId)
                await _listaZeljaService.Delete<Model.ListaZelja>(i.Id);
               
            }

               await Application.Current.MainPage.DisplayAlert("Success", "Obrisali ste putovanje iz favorita", "OK");
        

        }
        public async Task Init()
        {
            ListaZeljaSearchRequest search = new ListaZeljaSearchRequest();
            search.KorisnikId = LoggedInUser.ActiveUser.Id;

            var list = await _listaZeljaService.Get<List<ListaZelja>>(search);
            var putovanja = await _putovanjaService.Get<List<Putovanja>>(null);
            ListaZeljaList.Clear();
            PutovanjaList.Clear();
            foreach (var item in list)
            {
                foreach (var p in putovanja)
                {
                    if (item.PutovanjeId == p.Id)
                    {
                        PutovanjaList.Add(p);
                    }
                }

            }
        }
    }
}
