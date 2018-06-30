using System;
using System.Diagnostics;
using System.Globalization;

namespace Word
{
    /// <summary>
    /// Convertrs the <see cref="ApplicationPageEnum"/> to a <see cref="Page"/>
    /// </summary>
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        /// <summary>
        /// Creates a page every time we want to change the page
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is ApplicationPageEnum))
                throw new ArgumentException();

            switch ((ApplicationPageEnum)value)
            {
                case ApplicationPageEnum.Login:
                    return new LoginPage();

                case ApplicationPageEnum.Chat:
                    return new ChatPage();

                default:
                    throw new ArgumentException();
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
