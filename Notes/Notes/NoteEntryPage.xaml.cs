using System;
using System.IO;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
        private void OnSignOutClicked(object sender, EventArgs e)
        {

            // Redirect the user to the login page
            Navigation.PushAsync(new Login.LoginPage());



        }
        private void OnProfileButtonClicked(object sender, EventArgs e)
        {

            // Redirect the user to the login page
            Navigation.PushAsync(new Login.LoginPage());



        }

    }

}