using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
        }
        private async void OnSearchButtonPressed(object sender, EventArgs e)
        {
        }

        async void OnNoteAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NoteEntryPage
            {
                BindingContext = new Note()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new NoteEntryPage
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
        private void OnSignOutClicked(object sender, EventArgs e)
        {

            // Redirect the user to the login page
            Navigation.PushAsync(new Login.LoginPage());
        }
        private void OnProfileButtonClicked(object sender, EventArgs e)
        {
            // Handle the "Profile" button click event
            Navigation.PushAsync(new ProfilePage());
        }

        private void OnEditProfileButtonClicked(object sender, EventArgs e)
        {
            // Handle the "Edit Profile" button click event
            Navigation.PushAsync(new EditProfilePage());
        }
    }
}