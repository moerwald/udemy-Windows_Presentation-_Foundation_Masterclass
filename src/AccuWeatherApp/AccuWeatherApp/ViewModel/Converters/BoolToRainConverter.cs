using System;
using System.Globalization;
using System.Windows.Data;


namespace AccuWeatherApp.ViewModel.Converters
{
    public class BoolToRainConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            =>
            value is bool rain && rain  ? "It is raining" : "No rain";

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => 
            value is string rain && rain == "It is raining" ? true : (object)false;
    }
}
