using System.ComponentModel;
using TuristickaAgencija.MobileApp.ViewModels;
using Xamarin.Forms;

namespace TuristickaAgencija.MobileApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}