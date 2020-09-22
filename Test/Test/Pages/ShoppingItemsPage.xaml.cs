using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingItemsPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public ShoppingItemsPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Bread",
                "Milk",
                "Cornflakes"
            };
			
			ShoppingItems.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
