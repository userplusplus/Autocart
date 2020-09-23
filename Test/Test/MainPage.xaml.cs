using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Test.Pages;
using Test.Models;
using Test.DataAccess;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        UserDataAccess dataAccess;
        private string email;
        private string password;

        public MainPage()
        {
            InitializeComponent();
            dataAccess = new UserDataAccess();
            this.BindingContext = dataAccess;
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            email = this.emailInput.Text;
            password = this.passwordInput.Text;

            try
            {
                //use email to check for user
                User user = this.dataAccess.GetUser(email);

                if (user == null)
                {
                    //user doesnt exist error
                    await DisplayAlert("Login Error", "No user was found with that email.", "OK");
                    return;
                }

                else if (user.Password == password)
                {
                    //Go to next page
                    Application.Current.MainPage = new NavigationPage(new LinkPage());
                }
            }
            catch
            {
                await DisplayAlert("Login Error", "An unknown error has occured.", "OK");
            }
        }

        private async void RegisterButtonClicked(object sender, EventArgs e)
        {
            email = this.emailInput.Text;
            password = this.passwordInput.Text;

            try
            {
                //check for blanks
                if (password == "" || email == "" || password == null || email == null)
                {
                    await DisplayAlert("Registration Error", "No input was found for one or more of the fields required.", "OK");
                }
                //check for bad passwords
                else if (password.Length <= 6)
                {
                    await DisplayAlert("Registration Error", "Password needs to be longer than 6 characters long.", "OK");
                }
                //check for taken email
                else if(this.dataAccess.GetUser(email).Email != null)
                {
                    await DisplayAlert("Registration Error", "This email is already in use, please log in.", "OK");
                }
                else
                {
                    this.dataAccess.AddNewUser(email, password);
                    await DisplayAlert("Registration Success", "email:" + email + "/npassword:" + password, "OK");
                }
                
            }
            catch
            {
                await DisplayAlert("Registration Error", "An error has occured during the account creation process.", "OK");
                Console.Write("An error occured trying to register a new user");
            }
        }
    }
}
