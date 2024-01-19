using System.Globalization;

namespace TipCalculator.Converters;

public class AmountConverter : IValueConverter, IMarkupExtension
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        string? castedValue = value as string;
        if (string.IsNullOrWhiteSpace(castedValue)) return castedValue;

        if (double.TryParse(castedValue, out double parsedValue) && castedValue.Last() != '.')
        {
            return parsedValue;
        }

        return castedValue;
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}