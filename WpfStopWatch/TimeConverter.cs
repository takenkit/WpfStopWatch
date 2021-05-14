using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfStopWatch
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ts = (TimeSpan)value;
            return string.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Minutes, ts.Seconds, ts.Milliseconds / 10, ts.Milliseconds);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
