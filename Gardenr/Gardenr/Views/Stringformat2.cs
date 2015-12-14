using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Gardenr.Views
{
    class Stringformat2 :  IValueConverter
    { 
        public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value == null)
            return null;

        if (parameter == null)
            return value;

        String datum = (String)value.ToString();
        var x = datum.Split('/');
        string jaar = x[2].Substring(0, 4);
        string maand = x[1];

        string dag = x[0];
        DateTime ne = new DateTime(int.Parse(jaar), int.Parse(dag), int.Parse(maand));
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
