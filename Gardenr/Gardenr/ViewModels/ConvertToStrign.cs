using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Gardenr.ViewModels
{
    
    class ConvertToStrign : IValueConverter
    {
  
       
            public object Convert(object value, Type targetType, object parameter)
            {
                return value == null ? null : value.ToString();
            }

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try {
                string va = value as string;
                if (va == "0") {
                    return "Nee";
                }
                else
                {

                    return "Ja";
                }

            } catch (Exception e) { Exception mijnexceptie = e; }

            return "/";
        }

      

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
