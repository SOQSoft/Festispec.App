using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Festispec.App.Helpers
{
    public class TextToNummerOnlyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((int)value).ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = new string(((string)value).ToCharArray().Where(c => Char.IsDigit(c)).ToArray());
            return string.IsNullOrWhiteSpace(str) ? 0 : int.Parse(str);
        }
    }
}
