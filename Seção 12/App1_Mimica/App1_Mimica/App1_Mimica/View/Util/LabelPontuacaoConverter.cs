using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace App1_Mimica.View.Util
{
    public class LabelPontuacaoConverter : IValueConverter
    {
        //View > ViewModel(Dado)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if((byte)value == 0)
            {
                return "Palavra";
            }
            else
            {
                return "Palavra - Pontuação: " + value;
            }
            
        }
        //ViewModel > View
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
