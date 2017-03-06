using Cats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cats.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatsPage : ContentPage
    {
        public CatsPage()
        {
            InitializeComponent();
            LvCats.ItemSelected += LvCats_ItemSelected;
        }

        private async void LvCats_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCat = e.SelectedItem as Cat;

            if(selectedCat != null)
            {
                await Navigation.PushAsync(new DetailsPage(selectedCat));
                LvCats.SelectedItem = null;
            }
        }
    }
}
