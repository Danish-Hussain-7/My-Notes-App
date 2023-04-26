using Firebase.Auth;
using Newtonsoft.Json.Linq;
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
	public partial class RegisterAccount : ContentPage
	{
		public RegisterAccount ()
		{
			InitializeComponent ();
		}
        private void OnCreateAccountButtonClicked(object sender, EventArgs e)
        {

            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;
            string email = EmailEntry.Text;
            string firstName = FirstNameEntry.Text;
            string surname = SurnameEntry.Text;
            DateTime dateOfBirth = DateOfBirthEntry.Date;

            // Save the details locally using Xamarin.Essentials
            Xamarin.Essentials.Preferences.Set("Username", username);
            Xamarin.Essentials.Preferences.Set("Password", password);
            Xamarin.Essentials.Preferences.Set("Email", email);
            Xamarin.Essentials.Preferences.Set("FirstName", firstName);
            Xamarin.Essentials.Preferences.Set("Surname", surname);
            Xamarin.Essentials.Preferences.Set("DateOfBirth", dateOfBirth);

            // Display a message to the user
            DisplayAlert("Account Created", "Your account has been created successfully", "OK");
            Navigation.PushAsync(new LoginPage());

        }
    }
}