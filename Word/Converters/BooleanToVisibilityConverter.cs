using System;
using System.Globalization;
using System.Windows;

namespace Word
{
    /// <summary>
    /// A converter that takes in a boolean and returns a <see cref="Visibility"/>
    /// </summary>
    public class BooleanToVisibilityConverter : BaseValueConverter<BooleanToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(parameter is string)) throw new ArgumentNullException("Parameter passed is invalid type");

            if ((string)parameter == "True")
                return (bool)value ? Visibility.Visible : Visibility.Hidden;
            if ((string)parameter == "False")
                return (bool)value ? Visibility.Hidden : Visibility.Visible;
            throw new ArgumentNullException("Parameter passed has an invalid value");
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}