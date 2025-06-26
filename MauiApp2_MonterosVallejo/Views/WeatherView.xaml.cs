using MauiApp2_MonterosVallejo.ViewModels;

namespace MauiApp2_MonterosVallejo.Views;

public partial class WeatherView : ContentPage
{
    public WeatherView()
    {
        InitializeComponent();
        BindingContext = new WeatherViewModel();
    }
}
