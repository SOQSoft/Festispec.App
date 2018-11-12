using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Festispec.App.Helpers
{
    class QuestionTypeToControlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                var url = $"{assemblyName}.Views.Controls.Create{value}";
                Type userControl = Type.GetType(url, null, null);
                return Activator.CreateInstance(userControl ?? Type.GetType($"{assemblyName}.Views.Controls.EmptyControl"));
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
