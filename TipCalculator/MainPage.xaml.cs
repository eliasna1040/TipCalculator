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
        SetCalculatedTip();
        SetCalculatedTotal();
    }
    
    private void TipSlider_OnValueChanged(object? sender, ValueChangedEventArgs e)
    {
        TipPercentageLabel.Text = Math.Round(TipSlider.Value, MidpointRounding.ToZero).ToString("P");

        SetCalculatedTip();
        SetCalculatedTotal();
    }
    
    private void RoundUpButton_OnClicked(object? sender, EventArgs e)
    {
        double totalAmount = GetCalculatedTotal();
        double rounded = Math.Ceiling(totalAmount / 10) * 10;
        TotalLabel.Text = rounded.ToString("C");
    }

    private void RoundDownButton_OnClicked(object? sender, EventArgs e)
    {
        double totalAmount = GetCalculatedTotal();
        double rounded = Math.Floor(totalAmount / 10) * 10;
        TotalLabel.Text = rounded.ToString("C");
    }

    private void TwentyPercentageButton_OnClicked(object? sender, EventArgs e)
    {
        TipSlider.Value = 20;
    }

    private void FifteenPercentageButton_OnClicked(object? sender, EventArgs e)
    {
        TipSlider.Value = 15;
    }


    private double GetCalculatedTip()
    {
        if (double.TryParse(AmountEntry.Text, out double amount))
        {
            return Math.Round(TipSlider.Value, MidpointRounding.ToEven) / 100 * amount;
        }

        return 0;
    }

    private void SetCalculatedTip()
    {
        TipLabel.Text = GetCalculatedTip().ToString("C");
    }

    private double GetCalculatedTotal()
    {
        if (!double.TryParse(AmountEntry.Text, out double amount)) 
            return 0;
        
        double tip = GetCalculatedTip();
        return amount + tip;
    }

    private void SetCalculatedTotal()
    {
        double totalAmount = GetCalculatedTotal();
        TotalLabel.Text = totalAmount.ToString("C");
    }

}