﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Test.Pages;

namespace Test
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LinkPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public LinkPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<string>
            {
                "Shopping Items",
                "Daily Specials",
                "Loyalty Card",
                "History"
            };
			
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            switch (e.Item)
            {
                case "Shopping Items":
                    await Navigation.PushAsync(new ShoppingItemsPage());
                    break;
                case "Daily Specials":
                    await Navigation.PushAsync(new DailySpecialsPage());
                    break;
                case "Loyalty Card":
                    await Navigation.PushAsync(new LoyaltyCardPage());
                    break;
                case "History":
                    await Navigation.PushAsync(new HistoryPage());
                    break;
            }

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}