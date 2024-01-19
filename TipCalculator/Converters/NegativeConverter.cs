using System.Globalization;

namespace TipCalculator.Converters;

public class NegativeConverter : IValueConverter, IMarkupExtension
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value != null && !value.ToString().Contains('-') ? value : 0;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}