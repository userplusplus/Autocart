﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoyaltyCardPage : ContentPage
	{
		public LoyaltyCardPage ()
		{
			InitializeComponent ();
		}

        private void AddCardClicked(object sender, EventArgs e)
        {

        }

        private void RemoveCardClicked(object sender, EventArgs e)
        {

        }
    }
}