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
	public partial class EditProfilePage : ContentPage
	{
		public EditProfilePage ()
		{
			InitializeComponent ();
		}
        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Retrieve the updated user's details from the input fields
            string username = UsernameEntry.Text;
            string email = EmailEntry.Text;
            string firstName = FirstNameEntry.Text;
            string surname = SurnameEntry.Text;
            DateTime dateOfBirth = DateOfBirthEntry.Date;

            // Save the updated details back to Xamarin.Essentials.Preferences
            Xamarin.Essentials.Preferences.Set("Username", username);
            Xamarin.Essentials.Preferences.Set("Email", email);
            Xamarin.Essentials.Preferences.Set("FirstName", firstName);
            Xamarin.Essentials.Preferences.Set("Surname", surname);
            Xamarin.Essentials.Preferences.Set("DateOfBirth", dateOfBirth);

            // Display a message to the user
            DisplayAlert("Profile Updated", "Your profile has been updated successfully", "OK");

            // Navigate back to the profile page
            Navigation.PushAsync(new ProfilePage());

        }
    }
}
