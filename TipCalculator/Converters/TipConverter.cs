using System.Globalization;

namespace TipCalculator.Converters;

public class TipConverter : IValueConverter, IMarkupExtension
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        double castedValue = value as double? ?? 0;
        return castedValue >= 0 ? castedValue : 0;
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