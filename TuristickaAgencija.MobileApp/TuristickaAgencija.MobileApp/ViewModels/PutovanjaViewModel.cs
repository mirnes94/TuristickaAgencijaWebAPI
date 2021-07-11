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
    public class PutovanjaViewModel:BaseViewModel
    {
        private readonly APIService _putovanjaService = new APIService("Putovanja");
        private readonly APIService _gradoviService = new APIService("Gradovi");
        public PutovanjaViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }
        public ObservableCollection<Putovanja> PutovanjaList { get; set; } = new ObservableCollection<Putovanja>();
        public ObservableCollection<Gradovi> GradoviList { get; set; } = new ObservableCollection<Gradovi>();

        Gradovi _selectedGrad = null;
        public Gradovi SelectedGrad
        {
            get { return _selectedGrad; }
            set { 
                SetProperty(ref _selectedGrad, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
               
            }
        }


        public ICommand InitCommand { get; set; }
        public Korisnici Korisnik { get; set; }

        public async Task Init()
        {
            if (GradoviList.Count == 0)
            {
                var gradovi = await _gradoviService.Get<List<Gradovi>>(null);

                foreach (var grad in gradovi)
                {
                    GradoviList.Add(grad);
                }
            }

            if (SelectedGrad != null)
            {
                PutovanjaSearchRequest search = new PutovanjaSearchRequest();
                search.GradId = SelectedGrad.Id;

                var list = await _putovanjaService.Get<List<Putovanja>>(search);

                PutovanjaList.Clear();

                foreach (var item in list)
                {
                    PutovanjaList.Add(item);
                }
            }

            
        }
    }
}
