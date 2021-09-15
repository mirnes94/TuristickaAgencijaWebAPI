using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Mail;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.MobileApp.Views;
using TuristickaAgencija.Model;
using TuristickaAgencija.Model.Request;
using Xamarin.Forms;

namespace TuristickaAgencija.MobileApp.ViewModels
{
    public class KorisnikUpdateViewModel:BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");

        public KorisnikUpdateViewModel()
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

        public ObservableCollection<Korisnici> UplateList { get; set; } = new ObservableCollection<Korisnici>();

        public async Task Update()
        {
            

            Model.Korisnici korisnik = await _service.GetById<Korisnici>(LoggedInUser.ActiveUser.Id);
            KorisniciInsertUpdateRequest request;
            if (korisnik != null)
            {
                request = new KorisniciInsertUpdateRequest
                {
                    Email = korisnik.Email,
                    Ime = Ime,
                    KorisnickoIme = KorisnickoIme,
                    Password = Password,
                    PasswordConfirmation = PasswordPotvrda,
                    Prezime = Prezime,
                    Status = false,
                    Telefon = Telefon,
                };
            
         
            MailAddress from = new MailAddress("turisticka.agencija@mail.com", "Turisticka agencija");
            MailAddress to = new MailAddress("mirnest10@gmail.com", korisnik.Ime + " " + korisnik.Prezime);////Korisnicki podaci za slanje konfirmacijskog emaila.
                                                                                                         //Koristio sam svoj email radi testiranja.

            MailMessage mm = new MailMessage(from, to)
            {
                Subject = "Confirmation email",
                Body = "Confirm your update. Go to"+ " http://localhost:43791/api/Korisnici/Potvrdi/"+korisnik.KorisnickoIme,
                IsBodyHtml = false
            };

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;


            NetworkCredential nc = new NetworkCredential("mirnest10@gmail.com", "mirnes12345*");//Podaci turisticke agencija za potvrdu.
                                                                                                //Koristio sam svoje podatke radi testiranja.
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;

            smtp.Send(mm);

            await _service.Update<Model.Korisnici>(korisnik.Id,request);


            await Application.Current.MainPage.DisplayAlert("Success", "Confirmation mail is sent", "OK");
            Application.Current.MainPage = new LoginPage();

                }
        }
    }
}
