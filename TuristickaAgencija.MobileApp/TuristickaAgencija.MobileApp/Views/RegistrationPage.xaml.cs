using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.MobileApp.ViewModels;
using TuristickaAgencija.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristickaAgencija.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        RegistrationViewModel model = null;
        APIService _service = new APIService("Korisnici");
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = model = new RegistrationViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool _username = false;
            bool _email = false;

            List<Korisnici> korisnici = await _service.Get<List<Korisnici>>(null);

            foreach (var korisnik in korisnici)
            {
                if (korisnik.KorisnickoIme.Equals(korisnickoimeInput.Text) == true)
                {
                    _username = true;
                }
                if (korisnik.Email.Equals(emailInput.Text) == true)
                {
                    _email = true;
                }
            }

            if (ValidateRegistration() == true)
            {

                if (_username == true)
                {
                    await DisplayAlert("Error", "Korisnicko ime već postoji!", "OK");
                    korisnickoimeInputError.Text = "Postojeće korisnicko ime!";
                    korisnickoimeInputError.IsVisible = true;
                }
                else if (_email == true)
                {
                    await DisplayAlert("Error", "Email vec postoji!", "OK");
                    emailInputError.Text = "Postojeći email!";
                    emailInputError.IsVisible = true;
                }
                else
                {
                    await model.Registracija();
                }

            }
            else
            {
                await DisplayAlert("Error", "Input error", "OK");

            }
        }
        private bool ValidateRegistration()
        {
            bool valid = true;
            if (ValidateIme() == false || ValidatePrezime() == false || ValidateEmail() == false || ValidateTelefon() == false || ValidateKorisnickoIme() == false || ValidatePassword() == false || ValidateConfirmPassword() == false)
                valid = false;

            if (valid == false)
            {
                return false;
            }
            else
            {
                return true;
            };
        }
        private bool ValidateIme()
        {
            if (string.IsNullOrWhiteSpace(imeInput.Text))
            {

                imeInputError.Text = "Obavezno polje!";
                imeInputError.IsVisible = true;
                return false;
            }
            else
            {

                imeInputError.IsVisible = false;
                imeInputError.Text = "";
                return true;
            }
        }

        private bool ValidatePrezime()
        {
            if (string.IsNullOrWhiteSpace(prezimeInput.Text))
            {
                prezimeInputError.Text = "Obavezno polje!";
                prezimeInputError.IsVisible = true;
                return false;
            }
            else
            {

                prezimeInputError.IsVisible = false;
                prezimeInputError.Text = "";
                return true;
            }
        }
        private bool ValidateTelefon()
        {
            if (string.IsNullOrWhiteSpace(telefonInput.Text))
            {
                telefonInputError.Text = "Obavezno polje!";
                telefonInputError.IsVisible = true;
                return false;
            }
            else
            {

                telefonInputError.IsVisible = false;
                telefonInputError.Text = "";
                return true;
            }
        }
        private bool ValidateEmail()
        {
            try
            {
                MailAddress mail = new MailAddress(emailInput.Text);

            }
            catch (Exception)
            {
                emailInputError.Text = "Nije validan format!";
                emailInputError.IsVisible = true;
                return false;
               
            }

            if (string.IsNullOrWhiteSpace(emailInput.Text))
            {

                emailInputError.Text = "Obavezno polje!";
                emailInputError.IsVisible = true;
                return false;
            }
            else
            {
                emailInputError.IsVisible = false;
                emailInputError.Text = "";
                return true;
            }

        }

        private bool ValidateKorisnickoIme()
        {
            if (string.IsNullOrWhiteSpace(korisnickoimeInput.Text))
            {
                korisnickoimeInputError.Text = "Obavezno polje!";
                korisnickoimeInputError.IsVisible = true;
                return false;
            }
            if (korisnickoimeInput.Text.Count() < 6)
            {
                korisnickoimeInputError.Text = "Korisnicko ime mora sadrzavati najmanje 6 karaktera!";
                korisnickoimeInputError.IsVisible = true;
                return false;
            }
            else
            {

                korisnickoimeInputError.IsVisible = false;
                korisnickoimeInputError.Text = "";
                return true;
            }
        }

        private bool ValidatePassword()
        {
            if (string.IsNullOrWhiteSpace(passwordInput.Text))
            {

                passwordInputError.Text = "Obavezno polje!";
                passwordInputError.IsVisible = true;
                return false;
            }
            if (passwordInput.Text == korisnickoimeInput.Text)
            {

                passwordInputError.Text = "Nije moguće koristiti korisnicko ime kao password!";
                passwordInputError.IsVisible = true;
                return false;
            }
            if (passwordInput.Text.Count() < 6)
            {

                passwordInputError.Text = "Password mora sadrzavati najmanje 6 karaktera!";
                passwordInputError.IsVisible = true;
                return false;
            }
            else
            {

                passwordInputError.IsVisible = false;
                passwordInputError.Text = "";
                return true;
            }
        }
        private bool ValidateConfirmPassword()
        {
            if (passwordInput.Text != passwordpotvrdaInput.Text)
            {

                passwordpotvrdaInputError.Text = "Passwords do not match!";
                passwordpotvrdaInputError.IsVisible = true;
                return false;
            }
            else
            {
                passwordpotvrdaInputError.Text = "";
                passwordpotvrdaInputError.IsVisible = false;
                return true;
            }
        }

    }
    }
