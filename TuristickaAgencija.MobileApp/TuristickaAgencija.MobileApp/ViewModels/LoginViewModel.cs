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
            try
            {
                Model.Korisnici korisnik = await service.Authentication<Model.Korisnici>(Username, Password);
                if (korisnik != null)
                {
                    if (korisnik.Status == true)
                    {
                        APIService.Username = Username;
                        APIService.Password = Password;

                        LoggedInUser.ActiveUser = korisnik;

                        await Application.Current.MainPage.DisplayAlert("Success", "Dobro dosli " + korisnik.Ime + " " + korisnik.Prezime, "OK");
                        Application.Current.MainPage = new MainPage(korisnik);
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "Potrebno je da potvrdite Vas racun", "OK");
                    }
                }
                else
                {
                    IsBusy = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "Wrong username or password", "OK");
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
           
        }
    }
    }

