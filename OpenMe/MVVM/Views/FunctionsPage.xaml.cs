namespace OpenMe.MVVM.Views;

public partial class FunctionsPage : ContentPage
{
    public FunctionsPage()
    {
        InitializeComponent();
        _ = SetBackgroundImageAsync();
    }

    private async Task SetBackgroundImageAsync()
    {
        await Task.Delay(500);
        var backgroundImage = (Image)this.FindByName("BackgroundImage");
        backgroundImage.Source = "felix_stairs.png";
        await backgroundImage.FadeTo(1, 1000);
    }
}
