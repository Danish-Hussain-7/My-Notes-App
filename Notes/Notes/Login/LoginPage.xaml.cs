using Notes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Login
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}
      
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Check if the user has already created an account
            if (Xamarin.Essentials.Preferences.ContainsKey("Username") && Xamarin.Essentials.Preferences.ContainsKey("Password"))
            {
                // Hide the "Create Account" button
                SignInButton.IsVisible = true;

            }
            else
            {
                // Hide the "Sign In" button

                CreateAccountButton.IsVisible = true;

            }

        }
        private void OnSignInButtonClicked(object sender, EventArgs e)
        {
            // Get the entered username and password
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            // Check if the username and password match the saved details
            if (Xamarin.Essentials.Preferences.Get("Username", "") == username && Xamarin.Essentials.Preferences.Get("Password", "") == password)
            {
                // Display a message to the user
                DisplayAlert("Login Successful", "You have been signed in successfully", "ok");
                Navigation.PushAsync(new NotesPage());
            }
            else
            {
                // Display an error message to the user
                DisplayAlert("Login Failed", "Invalid username or password", "OK");
            }
        }

        private void OnCreateAccountButtonClicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new RegisterAccount());


        }
    }
}