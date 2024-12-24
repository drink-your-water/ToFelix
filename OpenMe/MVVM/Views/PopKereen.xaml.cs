using CommunityToolkit.Maui.Views;
using Plugin.Maui.Audio;

namespace OpenMe.MVVM.Views;

public partial class PopKereen : CommunityToolkit.Maui.Views.Popup
{
    private readonly IAudioPlayer? player;

    public PopKereen(IAudioPlayer? backgroundPlayer)
    {
        InitializeComponent();
        player = backgroundPlayer;
    }

    private async void OnPopupTapped(object sender, EventArgs e)
    {
        if (player != null)
        {
            player.Volume = 0.2; // Lower the volume of the background music
        }

        var mediaElement = new MediaElement
        {
            Source = MediaSource.FromFile("kereen_hbd.mp4"),
            ShouldAutoPlay = true,
            Aspect = Aspect.AspectFit
        };

        var popupContent = new VerticalStackLayout
        {
            Children = { mediaElement }
        };

        Content = popupContent;

        // Simulate an asynchronous operation to avoid CS1998 warning
        await Task.CompletedTask;
    }
}
