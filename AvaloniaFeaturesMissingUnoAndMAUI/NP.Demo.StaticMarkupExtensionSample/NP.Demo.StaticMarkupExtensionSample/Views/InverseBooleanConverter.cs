using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace NP.Demo.StaticMarkupExtensionSample.Views
{
    public class InverseBooleanConverter : IValueConverter
    {
        public static InverseBooleanConverter Instance { get; } = new InverseBooleanConverter();

        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                return !b;
            }

            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
