using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Converters
{
    public class MinMaxDimensionConverter : IMultiValueConverter
    {

        //  --------------------------------------------------------------------------------
        /// <summary> Gets max dimension value. </summary>
        /// <param name="values"> Dimension values produced by the binding source. </param>
        /// <param name="targetType"> The type of the binding target property. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in converter. </param>
        /// <returns> A calculated max dimension value. If the methods returns null, the vaild null value is used. </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            bool isMax = parameter is string paramStr ? paramStr.ToUpper() == "MAX" : false;

            if (values.Any(v => v is double))
            {
                var doubleValues = values.Where(v => v is double).Select(v => (double)v);
                return Math.Max(0, (isMax ? doubleValues.Max() : doubleValues.Min()));
            }

            return 0;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Converts a value. </summary>
        /// <param name="value"> The value that is produced by the binding target. </param>
        /// <param name="targetTypes"> The types to convert to. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in the converter. </param>
        /// <returns> A converted value. If the method returns null, the valid null value is used. </returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
