using System.Globalization;
using TipCalculator.Models;

namespace TipCalculator;

public partial class MainPage : ContentPage
{
    private CultureInfo _currencyCulture;
    public Tip Tip { get; set; }

    public MainPage()
    {
        InitializeComponent();
        Tip = new Tip();
        BindingContext = Tip;
    }

    #region EventHandlers

    private void AmountEntry_OnTextChanged(object? sender, TextChangedEventArgs e) => Tip.Calculate(false, false);

    private void TipSlider_OnValueChanged(object? sender, ValueChangedEventArgs e) => Tip.Calculate(false, false);

    private void RoundUpButton_OnClicked(object? sender, EventArgs e) => Tip.Calculate(true, false);

    private void RoundDownButton_OnClicked(object? sender, EventArgs e) => Tip.Calculate(false, true);

    private void TwentyPercentageButton_OnClicked(object? sender, EventArgs e) => Tip.TipPercentage = 20;

    private async void FifteenPercentageButton_OnClicked(object? sender, EventArgs e) => Tip.TipPercentage = 15;

    private async void CurrencyButton_OnClicked(object? sender, EventArgs e)
    {
        string currency = await DisplayActionSheet("Currency", "Cancel", null, "DKK", "EUR", "USD");

        var _currencyCulture = CultureInfo.GetCultureInfo(currency switch
        {
            "DKK" => "da-DK",
            "EUR" => "de-DE",
            "USD" => "en-US",
            _ => "da-DK"
        });
        
        Tip.Calculate(false, false);
    }

    #endregion
}