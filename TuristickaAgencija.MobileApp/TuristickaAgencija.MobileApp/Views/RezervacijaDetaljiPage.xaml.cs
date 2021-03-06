using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuristickaAgencija.MobileApp.ViewModels;
using TuristickaAgencija.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuristickaAgencija.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RezervacijaDetaljiPage : ContentPage
    {
        RezervacijaDetaljiViewModel model = null;
        public RezervacijaDetaljiPage(Korisnici korisnik,Putovanja putovanje)
        {
            InitializeComponent();
            BindingContext = model = new RezervacijaDetaljiViewModel()
            {
                Korisnik = korisnik,
                Putovanje=putovanje
            };

        }
        protected  async override void OnAppearing()
        {
            base.OnAppearing();
            await model.Init();
        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //Navigation.RemovePage(this);
            if(ValidateCard()==true)
            {
                if(ValidateRezervacija()==true)
                {
                    RezervacijaService.Service.Clear();
                    PayWithStripe();
                 
                }
                else 
                    await DisplayAlert("Error", "Rezervacija Input error", "OK");

            }
            else 
                await DisplayAlert("Error", "Card Input error", "OK");
           
        }

        public async void PayWithStripe()
        {
            StripeConfiguration.ApiKey = "sk_test_51J7fvxCQVjpUpLYrKFHiDEBGTSj8t3GIGYv91QPVqalY3HzU3qzbuQwdfPc9fl1mpnSUHGg8RrTxzisDSchpJ5aG00pEzE4mCH";


            string cardNo = brojKarticeInput.Text;
            string expMonth = mjesecIstekaInput.Text;
            string expYear = godinaIstekaInput.Text;
            string cardCvv = cvvInput.Text;


            try
            {
                //1.Create card option
                CreditCardOptions stripeOptions = new CreditCardOptions();
                stripeOptions.Number = cardNo;
                stripeOptions.ExpMonth = Convert.ToInt64(expMonth);
                stripeOptions.ExpYear = Convert.ToInt64(expYear);
                stripeOptions.Cvc = cardCvv;

                //2.Assign card to token object
                TokenCreateOptions stripeCard = new TokenCreateOptions();
                stripeCard.Card = stripeOptions;

                TokenService service = new TokenService();//needed verify phone number
                Token newToken = service.Create(stripeCard);

                //3. assign the token to the source
                var option = new SourceCreateOptions
                {
                    Type = SourceType.Card,
                    Currency = "bam",
                    Token = newToken.Id
                };

                var sourceService = new SourceService();
                Source source = sourceService.Create(option);

                //4.
                CustomerCreateOptions customer = new CustomerCreateOptions
                {
                    Name = LoggedInUser.ActiveUser.KorisnickoIme,
                    Email = LoggedInUser.ActiveUser.Email,
                    Description = "Placanje rezervacije za " + LoggedInUser.ActiveUser.Ime + " " + LoggedInUser.ActiveUser.Prezime,
                    Address = new AddressOptions { City = "Gorazde", Country = "Bosna i Hercegovina", Line1 = "Address1", Line2 = "Address2", PostalCode = "73000", State = "BPK" }
                };

                var customerService = new CustomerService();
                var cust = customerService.Create(customer);

                //5. charge option
                var chargeoption = new ChargeCreateOptions
                {
                    Amount = long.Parse(iznosUplateInput.Text) * 100,
                    Currency = "bam",
                    ReceiptEmail = "mirnest10@gmail.com",
                    Customer = cust.Id,
                    Source = source.Id,
                    Description = "Charge for " + LoggedInUser.ActiveUser.Email,
                    Capture = true
                };
                //6. charge the customer
                var chargeService = new ChargeService();
                Charge charge = chargeService.Create(chargeoption);

                if (charge.Status == "succeeded")
                {
                    //success
                    await DisplayAlert("Uspjesno izvrsena uplata", "Placanje uspjesno", "OK");
                }
                else
                {
                    //failed
                    await DisplayAlert("Oops, nesto nije uredu", "Placanje neuspjesno", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Problemi sa karticom", "OK");
            }



        }
        private bool ValidateCard()
        {
            bool valid = true;
            if (ValidateBrojKartice() == false || ValidateMjesecIsteka() == false || ValidateGodinaIsteka() == false || ValidateCvv()==false)
             
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
        private bool ValidateRezervacija()
            {
                bool valid = true;
                if (ValidateBrojOsoba() == false || ValidateNapomena() == false || ValidateIznosUplate() == false
                 )
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


        

        private bool ValidateBrojKartice()
        {
            if (string.IsNullOrWhiteSpace(brojKarticeInput.Text))
            {
                brojKarticeInputError.Text = "Obavezno polje!";
                brojKarticeInputError.IsVisible = true;
                return false;
            }
            else
            {

                brojKarticeInputError.IsVisible = false;
                brojKarticeInputError.Text = "";
                return true;
            }
        }
        private bool ValidateGodinaIsteka()
        {
            if (string.IsNullOrWhiteSpace(godinaIstekaInput.Text))
            {
                godinaIstekaInputError.Text = "Obavezno polje!";
                godinaIstekaInputError.IsVisible = true;
                return false;
            }
            else
            {

                godinaIstekaInputError.IsVisible = false;
                godinaIstekaInputError.Text = "";
                return true;
            }
        }
        private bool ValidateMjesecIsteka()
        {
            if (string.IsNullOrWhiteSpace(mjesecIstekaInput.Text))
            {
                mjesecIstekaInputError.Text = "Obavezno polje!";
                mjesecIstekaInputError.IsVisible = true;
                return false;
            }
            else
            {

                mjesecIstekaInputError.IsVisible = false;
                mjesecIstekaInputError.Text = "";
                return true;
            }
        }
        private bool ValidateCvv()
        {
            if (string.IsNullOrWhiteSpace(cvvInput.Text))
            {
                cvvInputError.Text = "Obavezno polje!";
                cvvInputError.IsVisible = true;
                return false;
            }
            else
            {

                cvvInputError.IsVisible = false;
                cvvInputError.Text = "";
                return true;
            }
        }
        private bool ValidateBrojOsoba()
        {
            if (string.IsNullOrWhiteSpace(brojOsobaInput.Text))
            {
                brojOsobaInputError.Text = "Obavezno polje!";
                brojOsobaInputError.IsVisible = true;
                return false;
            }
            else
            {

                brojOsobaInputError.IsVisible = false;
                brojOsobaInputError.Text = "";
                return true;
            }
        }

        

        private bool ValidateNapomena()
        {
            if (string.IsNullOrWhiteSpace(napomenaInput.Text))
            {
                napomenaInputError.Text = "Obavezno polje!";
                napomenaInputError.IsVisible = true;
                return false;
            }
            else
            {

                napomenaInputError.IsVisible = false;
                napomenaInputError.Text = "";
                return true;
            }
        }
        private bool ValidateIznosUplate()
        {
            if (string.IsNullOrWhiteSpace(iznosUplateInput.Text))
            {
                iznosUplateInputError.Text = "Obavezno polje!";
                iznosUplateInputError.IsVisible = true;
                return false;
            }
            else
            {

                iznosUplateInputError.IsVisible = false;
                iznosUplateInputError.Text = "";
                return true;
            }
        }





    }
}