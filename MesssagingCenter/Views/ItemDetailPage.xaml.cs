using MesssagingCenter.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MesssagingCenter.Views
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