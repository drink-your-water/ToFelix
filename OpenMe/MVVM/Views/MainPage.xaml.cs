using System.ComponentModel;
using System.Runtime.CompilerServices;
using OpenMe.MVVM.Views;
using Plugin.Maui.Audio;

namespace OpenMe
{
    public partial class MainPage : ContentPage
    {
        private IAudioPlayer? player; // Make player nullable
        private bool isImageTapped = false; // Add a flag to track if the image has been tapped
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private async void OnImageTapped(object sender, EventArgs e)
        {
            if (isImageTapped) return; // If the image has already been tapped, do nothing
            isImageTapped = true; // Set the flag to true to prevent further taps

            if (sender is Image image)
            {
                if (BindingContext is MainPageViewModel viewModel)
                {
                    viewModel.IsLabelVisible = false;
                }

                // Create the audio player for the first song
                player = Plugin.Maui.Audio.AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("birthday_song.mp3"));

                // Play the first song
                player.Seek(2.0); // Start playback at 2 seconds
                player.Play();

                // Handle the end of the first song
                player.PlaybackEnded += OnFirstSongPlaybackEnded;

                // Start the animation for the image enlargement and fading
                var scaleAnimation = image.ScaleTo(6.0, 6000, Easing.CubicInOut); // Enlarge the image
                var fadeAnimation = image.FadeTo(0, 5000, Easing.CubicInOut);     // Gradually fade out

                // Wait for both animations to complete
                await Task.WhenAll(scaleAnimation, fadeAnimation);

                // Navigate to the next page while the song is playing
                await Navigation.PushAsync(new FunctionsPage(), true); // Use PushAsync with animation
            }
        }

        private async void OnFirstSongPlaybackEnded(object? sender, EventArgs e)
        {
            if (player != null)
            {
                // Unsubscribe from the event before disposing of the player
                player.PlaybackEnded -= OnFirstSongPlaybackEnded;

                // Dispose of the current player
                player.Dispose();
                player = null;
            }

            // Create and start the second audio player
            player = Plugin.Maui.Audio.AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("birthday_jazz.mp3"));
            player.Loop = true; // Set the second song to loop
            player.Play();
        }
    }

    public partial class MainPageViewModel : INotifyPropertyChanged
    {
        private bool isLabelVisible = true;

        public bool IsLabelVisible
        {
            get => isLabelVisible;
            set
            {
                if (isLabelVisible != value)
                {
                    isLabelVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}