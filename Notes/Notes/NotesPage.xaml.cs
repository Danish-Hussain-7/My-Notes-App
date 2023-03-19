using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Notes.Models;
using Notes.Login;

namespace Notes
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
            UpdateNotesList();


        }
        async void UpdateNotesList()
        {
            List<Note> notes = await App.Database.GetNotesAsync();
            listView.ItemsSource = notes;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetNotesAsync();
            UpdateNotesList();

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
        async void OnSearchBarButtonPressed(object sender, EventArgs e)
        {
            string searchText = searchBar.Text;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                List<Note> searchResults = await App.Database.SearchNotesAsync(searchText);
                listView.ItemsSource = searchResults;
            }
            else
            {
                UpdateNotesList();
            }
        }
        private void OnEditProfileButtonClicked(object sender, EventArgs e)
        {
            // Handle the "Edit Profile" button click event
            Navigation.PushAsync(new EditProfilePage());
        }
        private async void OnNavigationPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                // Navigate to the selected page
                switch (selectedIndex)
                {
                    case 0:
                        await Navigation.PushAsync(new EditProfilePage());
                        break;
                    case 1:
                        await Navigation.PushAsync(new ProfilePage());
                        break;
                    case 2:
                        await Navigation.PushAsync(new LoginPage());
                        break;
                }
                // Reset the picker to avoid unintended navigation
                picker.SelectedIndex = -1;
            }
        }

    }
}