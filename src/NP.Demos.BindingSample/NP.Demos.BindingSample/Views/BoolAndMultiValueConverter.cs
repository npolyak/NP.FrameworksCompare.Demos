using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace NP.Demos.BindingSample.Views
{
    public class BoolAndMultiValueConverter : IMultiValueConverter
    {
        public static BoolAndMultiValueConverter Instance { get; } = new BoolAndMultiValueConverter();

        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            foreach(var item in values)
            {
                if (item is bool b) 
                {
                    if (!b)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
