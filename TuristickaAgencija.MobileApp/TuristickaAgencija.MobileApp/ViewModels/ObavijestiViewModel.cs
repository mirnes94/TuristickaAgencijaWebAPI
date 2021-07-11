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
    
    public class ObavijestiViewModel:BaseViewModel
    {
        private readonly APIService _obavijestiService = new APIService("Obavijesti");
        public ObavijestiViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Obavijesti> ObavijestiList { get; set; } = new ObservableCollection<Obavijesti>();

        public ICommand InitCommand { get; set; }
        public Korisnici Korisnik { get; set; }

        public async Task Init()
        {
            
                ObavijestiSearchRequest search = new ObavijestiSearchRequest();
                search.KorisnikId = LoggedInUser.ActiveUser.Id;

                var list = await _obavijestiService.Get<List<Obavijesti>>(search);

                ObavijestiList.Clear();

                foreach (var item in list)
                {
                    ObavijestiList.Add(item);
                }
            


        }
    }
}
