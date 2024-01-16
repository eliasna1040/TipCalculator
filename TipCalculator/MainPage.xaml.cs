namespace TipCalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        TipSlider.Value = 15;
    }

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

    private void TwentyPercentageButton_OnClicked(object? sender, EventArgs e)
    {
        TipSlider.Value = 20;
    }

    private void FifteenPercentageButton_OnClicked(object? sender, EventArgs e)
    {
        TipSlider.Value = 15;
    }

    private void Calculate(bool roundUp, bool roundDown)
    {
        if (double.TryParse(AmountEntry.Text, out double amount))
        {
            if (roundUp)
            {
                amount = Math.Ceiling(amount / 10) * 10;
            }
            else if (roundDown)
            {
                amount = Math.Floor(amount / 10) * 10;
            }
            
            double tip = Math.Round(TipSlider.Value, MidpointRounding.ToEven) / 100 * amount;
            double totalAmount = amount > 0 ? amount + tip : 0;
            
            TipLabel.Text = tip.ToString("C");
            TotalLabel.Text = totalAmount.ToString("C");
        }
        
    }
}