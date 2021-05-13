using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Data;

namespace WpfStopWatch
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
           // var ts = ((Stopwatch)value).Elapsed;
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
