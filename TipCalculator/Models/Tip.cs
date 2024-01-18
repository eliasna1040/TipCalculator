using System.Globalization;

namespace TipCalculator.Models;

public class Tip
{
    private double billAmount;
    public double BillAmount
    {
        get => billAmount;
        set => billAmount = double.TryParse(value.ToString(), out double amount) ? amount : 0;
    }

    public double TipAmount
    {
        get
        {
            return Math.Round(TipPercentage, MidpointRounding.ToEven) / 100 * BillAmount;
        }
    }

    public string TotalAmount { get; set; }
    public double TipPercentage { get; set; }
    public CultureInfo CurrencyCulture { get; set; }
    
    public void Calculate(bool roundUp, bool roundDown)
    {
        double amount = 0;
        
        if (roundUp)
        {
            amount = Math.Ceiling(BillAmount / 10) * 10;
        }
        else if (roundDown)
        {
            amount = Math.Floor(BillAmount / 10) * 10;
        }

        double tipAmount = amount + TipAmount;

        TotalAmount = tipAmount.ToString(CurrencyCulture);
    }
}