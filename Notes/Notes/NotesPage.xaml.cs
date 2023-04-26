using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Notes.Models;
using Notes.Login;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Notes
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
            UpdateNotesList();


        }
        private async void OnShareClicked(object sender, EventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                // Get the selected note
                Note selectedNote = (Note)listView.SelectedItem;

                // Share the note's text
                await Share.RequestAsync(new ShareTextRequest
                {
                    Text = selectedNote.Text,
                    Title = "Share Note"
                });
            }
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
        private async void OnLogoImageTapped(object sender, EventArgs e)
        {
            // Get the image element
            var image = (Image)sender;

            // Rotate the image 360 degrees clockwise
            await image.RotateTo(360, 1000);
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
        private async void OnPickerTapped(object sender, EventArgs e)
        {
            var pickerLayout = (StackLayout)sender;

            // Scale up the Picker
            await pickerLayout.ScaleTo(1.1, 100, Easing.Linear);

            // Open the Picker
            navigationPicker.Focus();

            // Scale down the Picker
            await pickerLayout.ScaleTo(1, 100, Easing.Linear);
        }
    }
}