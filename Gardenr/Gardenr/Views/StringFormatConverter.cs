using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Gardenr.Views
{
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            if (parameter == null)
                return value;

            String datum = (String)value;
            var x = datum.Split('/');
            
            DateTime ne = new DateTime(int.Parse(x[2]), int.Parse(x[1]), int.Parse(x[0]));
            string monthName = ne
    .ToString("MMMM", CultureInfo.InvariantCulture);
            return "" + ne.Day + " " + monthName;

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
