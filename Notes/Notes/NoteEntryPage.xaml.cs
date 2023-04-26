using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;
using Notes.Models;
using Firebase.Auth;
using Newtonsoft.Json.Linq;
namespace Notes

{
    public partial class NoteEntryPage : ContentPage
    {
        private byte[] image;
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;

            if (string.IsNullOrWhiteSpace(note.Text))
            {
                await DisplayAlert("Error", "Please enter a note.", "OK");
                return;
            }


            note.Date = DateTime.UtcNow;
            note.Image = image;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();

            // Create a notification
            var notificationService = DependencyService.Get<INotificationService>();
            notificationService?.CreateNotification("Notes", "A new note has been created.");
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
        private async void ChooseImageButton_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Upload Image", "Cancel", null, "Choose from Gallery", "Take Photo");

            switch (action)
            {
                case "Choose from Gallery":
                    var pickResult = await MediaPicker.PickPhotoAsync(new MediaPickerOptions { Title = "Select a photo" });

                    if (pickResult != null)
                    {
                        using (var stream = await pickResult.OpenReadAsync())
                        {
                            var memoryStream = new MemoryStream();
                            await stream.CopyToAsync(memoryStream);

                            image = memoryStream.ToArray();
                            PostImage.Source = ImageSource.FromStream(() => memoryStream);
                        }
                    }
                    break;

                case "Take Photo":
                    var takeResult = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions { Title = "Take a photo" });

                    if (takeResult != null)
                    {
                        using (var stream = await takeResult.OpenReadAsync())
                        {
                            var memoryStream = new MemoryStream();
                            await stream.CopyToAsync(memoryStream);

                            image = memoryStream.ToArray();
                            PostImage.Source = ImageSource.FromStream(() => memoryStream);
                        }
                    }
                    break;
            }
        }

    }
}
