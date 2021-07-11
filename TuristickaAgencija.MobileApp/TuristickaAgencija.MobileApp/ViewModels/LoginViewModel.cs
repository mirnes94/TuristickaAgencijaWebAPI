using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TuristickaAgencija.MobileApp.Views;
using Xamarin.Forms;

namespace TuristickaAgencija.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService service = new APIService("Korisnici");
        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await OnLoginClicked());
        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public ICommand LoginCommand { get; set; }

        

        async Task OnLoginClicked()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;
            Model.Korisnici korisnik = await service.Login<Model.Korisnici>(Username, Password);

            if (korisnik != null)
            {
                LoggedInUser.ActiveUser = korisnik;

                await Application.Current.MainPage.DisplayAlert("Success", "Dobro dosli " + korisnik.Ime + " " + korisnik.Prezime, "OK");
                //Application.Current.MainPage = new PutovanjaPage(korisnik);
                //Application.Current.MainPage = new ObavijestiPage();
                Application.Current.MainPage = new MainPage(korisnik);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Netačni pritupni podaci", "OK");
            }
        }
    }
    }

