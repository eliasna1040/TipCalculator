using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace TipCalculator.Models;

public class Tip : INotifyPropertyChanged
{
    private double _billAmount = 0;
    private double _totalAmount = 0;
    private double _tipPercentage = 0;

    public double BillAmount
    {
        get => _billAmount;
        set
        {
            _billAmount = double.TryParse(value.ToString(), out double amount) ? amount : 0;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TipAmount));
        }
    }

    public double TipAmount => Math.Round(TipPercentage, MidpointRounding.ToEven) / 100 * BillAmount;

    public double TotalAmount
    {
        get => _totalAmount;
        set
        {
            if (value == _totalAmount) return;
            _totalAmount = value;
            OnPropertyChanged();
        }
    }

    public double TipPercentage
    {
        get => _tipPercentage;
        set
        {
            if (value.Equals(_tipPercentage)) return;
            _tipPercentage = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(TipAmount));
        }
    }

    public void Calculate(bool roundUp, bool roundDown)
    {
        double amount = BillAmount;
        
        if (roundUp)
        {
            amount = Math.Ceiling(BillAmount / 10) * 10;
        }
        else if (roundDown)
        {
            amount = Math.Floor(BillAmount / 10) * 10;
        }

        TotalAmount = amount + TipAmount;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}