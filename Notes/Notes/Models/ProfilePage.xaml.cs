using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes.Models
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
		public ProfilePage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve the user's details from Xamarin.Essentials.Preferences
            string username = Xamarin.Essentials.Preferences.Get("Username", "");
            string email = Xamarin.Essentials.Preferences.Get("Email", "");
            string firstName = Xamarin.Essentials.Preferences.Get("FirstName", "");
            string surname = Xamarin.Essentials.Preferences.Get("Surname", "");
            DateTime dateOfBirth = Xamarin.Essentials.Preferences.Get("DateOfBirth", DateTime.MinValue);

            // Display the user's details in the appropriate controls
            UsernameLabel.Text = username;
            EmailLabel.Text = email;
            FirstNameLabel.Text = firstName;
            SurnameLabel.Text = surname;
            DateOfBirthLabel.Text = dateOfBirth.ToString("dd/MM/yyyy");
        }
        private async void OnEditProfileButtonClicked(object sender, EventArgs e)
        {
            // Create a new PageAnimation object with the desired animation parameters





            // Navigate to the EditProfilePage with the animation
            await Navigation.PushAsync(new EditProfilePage());
        }
    }
}
