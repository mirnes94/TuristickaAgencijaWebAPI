﻿using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.MobileApp.Views;
using TuristickaAgencija.Model.Request;
using Xamarin.Forms;

namespace TuristickaAgencija.MobileApp.ViewModels
{
    public class RegistrationViewModel:BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");

        public RegistrationViewModel()
        {

        }

        string _ime = string.Empty;
        public string Ime
        {
            get { return _ime; }
            set { SetProperty(ref _ime, value); }
        }

        string _prezime = string.Empty;
        public string Prezime
        {
            get { return _prezime; }
            set { SetProperty(ref _prezime, value); }
        }

        string _email = string.Empty;
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        string _telefon = string.Empty;
        public string Telefon
        {
            get { return _telefon; }
            set { SetProperty(ref _telefon, value); }
        }

        string _korisnickoime = string.Empty;
        public string KorisnickoIme
        {
            get { return _korisnickoime; }
            set { SetProperty(ref _korisnickoime, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        string _passwordpotvrda = string.Empty;
        public string PasswordPotvrda
        {
            get { return _passwordpotvrda; }
            set { SetProperty(ref _passwordpotvrda, value); }
        }

        public async Task Registracija()
        {
            KorisniciInsertUpdateRequest request = new KorisniciInsertUpdateRequest
            {
                Email = Email,
                Ime = Ime,
                KorisnickoIme = KorisnickoIme,
                Password = Password,
                PasswordConfirmation = PasswordPotvrda,
                Prezime = Prezime,
                Status = true,
                Telefon = Telefon,

            };
            

            await _service.Insert<Model.Korisnici>(request);
            await Application.Current.MainPage.DisplayAlert("Success", "Uspješna registracija", "OK");
            Application.Current.MainPage = new AppShell();
           

        }
    }
}
