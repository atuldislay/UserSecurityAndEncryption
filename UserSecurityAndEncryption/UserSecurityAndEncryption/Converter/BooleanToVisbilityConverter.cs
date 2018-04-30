using System;
using System.Windows;
using System.Windows.Data;

namespace UserSecurityAndEncryption.Converter
{
    class BooleanToVisbilityConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool visibility = Boolean.Parse(value.ToString());
            if (visibility)
            {
                return Visibility.Visible;
            }
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
