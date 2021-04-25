using RateChecker.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RateChecker.Views
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