using System.Globalization;

namespace TipCalculator;

public partial class MainPage : ContentPage
{
    private CultureInfo _currencyCulture;

    public MainPage()
    {
        InitializeComponent();
        _currencyCulture = CultureInfo.GetCultureInfo("da-DK");
        TipSlider.Value = 15;
    }

    #region EventHandlers

    private void AmountEntry_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        Calculate(false, false);
    }

    private void TipSlider_OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        TipPercentageLabel.Text = $"{Math.Round(TipSlider.Value, MidpointRounding.ToZero)}%";
        Calculate(false, false);
    }

    private void RoundUpButton_OnClicked(object? sender, EventArgs e)
    {
        Calculate(true, false);
    }

    private void RoundDownButton_OnClicked(object? sender, EventArgs e)
    {
        Calculate(false, true);
    }

    private async void TwentyPercentageButton_OnClicked(object? sender, EventArgs e)
    {
        SetTip(20);
    }

    private async void FifteenPercentageButton_OnClicked(object? sender, EventArgs e)
    {
        SetTip(15);
    }

    private async void CurrencyButton_OnClicked(object? sender, EventArgs e)
    {
        string currency = await DisplayActionSheet("Currency", "Cancel", null, "DKK", "EUR", "USD");
        string type = currency switch
        {
            "DKK" => "da-DK",
            "EUR" => "de-DE",
            "USD" => "en-US",
            _ => "da-DK"
        };

        _currencyCulture = CultureInfo.GetCultureInfo(type);
        Calculate(false, false);
    }

    #endregion

    #region Logic

    private async void SetTip(double sliderValue)
    {
        double tipValue = double.TryParse(AmountEntry.Text, out double amount) ? CalculateTip(amount, sliderValue) : 0;

        if (await DisplayAlert("Tip", $"Do you want to pay a {tipValue.ToString("C", _currencyCulture)} tip", "Yes",
                "No"))
        {
            TipSlider.Value = sliderValue;
        }
    }

    private double CalculateTip(double amount, double tip)
    {
        return Math.Round(tip, MidpointRounding.ToEven) / 100 * amount;
    }

    private void Calculate(bool roundUp, bool roundDown)
    {
        double.TryParse(AmountEntry.Text, out double amount);

        if (roundUp)
        {
            amount = Math.Ceiling(amount / 10) * 10;
        }
        else if (roundDown)
        {
            amount = Math.Floor(amount / 10) * 10;
        }

        double tip = CalculateTip(TipSlider.Value, amount);
        double totalAmount = amount > 0 ? amount + tip : 0;

        TipLabel.Text = tip.ToString("C", _currencyCulture);
        TotalLabel.Text = totalAmount.ToString("C", _currencyCulture);
    }

    #endregion
}