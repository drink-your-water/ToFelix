using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Plugin.Maui.Audio;

namespace OpenMe.MVVM.Views;

public partial class FunctionsPage : ContentPage
{
    private IAudioPlayer? player;

    public FunctionsPage()
    {
        InitializeComponent();
        _ = InitializePlayerAsync();
        _ = SetBackgroundImageAsync();
    }

    private async Task InitializePlayerAsync()
    {
        await Task.Delay(29000);
        player = Plugin.Maui.Audio.AudioManager.Current.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("birthday_jazz.mp3"));
        player.Loop = true;
        player.Play();
    }

    private async Task SetBackgroundImageAsync()
    {
        await Task.Delay(500);
        var backgroundImage = (Image)this.FindByName("BackgroundImage");
        backgroundImage.Source = "felix_stairs.png";
        await backgroundImage.FadeTo(1, 1000);
    }

    private async Task FadeOutMusicAsync()
    {
        if (player != null)
        {
            for (int i = 10; i >= 0; i--)
            {
                player.Volume = i / 10.0;
                await Task.Delay(100);
            }
            player.Pause();
        }
    }

    private async Task FadeInMusicAsync()
    {
        if (player != null)
        {
            player.Play();
            for (int i = 0; i <= 10; i++)
            {
                player.Volume = i / 10.0;
                await Task.Delay(100);
            }
        }
    }

    private async void OnPopArisClicked(object sender, EventArgs e)
    {
        await FadeOutMusicAsync();
        var popup = new PopAris();
        popup.Closed += async (s, args) => await FadeInMusicAsync();
        this.ShowPopup(popup);
    }

    private async void OnPopKereenClicked(object sender, EventArgs e)
    {
        await FadeOutMusicAsync();
        var popup = new PopKereen(player);
        popup.Closed += async (s, args) => await FadeInMusicAsync();
        this.ShowPopup(popup);
    }

    private async void OnPopGianClicked(object sender, EventArgs e)
    {
        await FadeOutMusicAsync();
        var popup = new PopGian();
        popup.Closed += async (s, args) => await FadeInMusicAsync();
        this.ShowPopup(popup);
    }

    private async void OnPopValClicked(object sender, EventArgs e)
    {
        await FadeOutMusicAsync();
        var popup = new PopVal();
        popup.Closed += async (s, args) => await FadeInMusicAsync();
        this.ShowPopup(popup);
    }

    private async void OnPopZacharyClicked(object sender, EventArgs e)
    {
        await FadeOutMusicAsync();
        var popup = new PopZachary();
        popup.Closed += async (s, args) => await FadeInMusicAsync();
        this.ShowPopup(popup);
    }

    private async void OnPopArjayClicked(object sender, EventArgs e)
    {
        await FadeOutMusicAsync();
        var popup = new PopArjay();
        popup.Closed += async (s, args) => await FadeInMusicAsync();
        this.ShowPopup(popup);
    }

    private async void OnPopChienlieClicked(object sender, EventArgs e)
    {
        await FadeOutMusicAsync();
        var popup = new PopChienlie();
        popup.Closed += async (s, args) => await FadeInMusicAsync();
        this.ShowPopup(popup);
    }
}
