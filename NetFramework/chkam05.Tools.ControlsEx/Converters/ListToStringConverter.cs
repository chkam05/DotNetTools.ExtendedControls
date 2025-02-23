using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Converters
{
    public class ListToStringConverter : IValueConverter
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Returns joned string list value. </summary>
        /// <param name="value"> The value produced by the binding source for comparision. </param>
        /// <param name="targetType"> The type of the binding target property. </param>
        /// <param name="parameter"> The converter parameter to use for compare. </param>
        /// <param name="culture"> The culture to use in converter. </param>
        /// <returns> Joned string list values. </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is IEnumerable<string> list)
            {
                string sep = (parameter is string tempSep && !string.IsNullOrEmpty(tempSep)) ? tempSep : ", ";
                return string.Join(sep, list);
            }

            return string.Empty;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Returns spearated string values. </summary>
        /// <param name="value"> The value that is produced by the binding target. </param>
        /// <param name="targetType"> The type to convert to. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in the converter. </param>
        /// <returns> Spearated string values. </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string strValue)
            {
                string sep = (parameter is string tempSep && !string.IsNullOrEmpty(tempSep)) ? tempSep : ", ";
                return strValue.Split(new string[] { sep }, StringSplitOptions.RemoveEmptyEntries);
            }

            return Enumerable.Empty<string>();
        }

    }
}
