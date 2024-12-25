using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Converters
{
    public class CircleCornerRadiusConverter : IMultiValueConverter
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Calculates circle corner radius. </summary>
        /// <param name="values"> Dimension values produced by the binding source. </param>
        /// <param name="targetType"> The type of the binding target property. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in converter. </param>
        /// <returns> A calculated corner radius value. If the methods returns null, the vaild null value is used. </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Any(v => v is double))
            {
                var doubleValues = values.Where(v => v is double).Select(v => (double)v);
                var cornerRadiusValue = doubleValues.Max() / 2;

                return new CornerRadius(cornerRadiusValue);
            }

            return new CornerRadius(0);
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
