﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {

        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Converts bool value to Visibility. </summary>
        /// <param name="value"> The value produced by the binding source for comparision. </param>
        /// <param name="targetType"> The type of the binding target property. </param>
        /// <param name="parameter"> The converter parameter to use for compare. </param>
        /// <param name="culture"> The culture to use in converter. </param>
        /// <returns> Returns Visible if value is true; Collapse/Hidden - otherwise. </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                var param = parameter as string;

                if ((bool)boolValue)
                    return Visibility.Visible;
                else if (!string.IsNullOrEmpty(param) && param.ToLower() == Visibility.Hidden.ToString().ToLower())
                    return Visibility.Hidden;
                else
                    return Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Converts a Visibility value to bool. </summary>
        /// <param name="value"> The value that is produced by the binding target. </param>
        /// <param name="targetType"> The type to convert to. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in the converter. </param>
        /// <returns> True if Visible; False - otherwise. </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                switch (visibility)
                {
                    case Visibility.Visible:
                        return true;

                    case Visibility.Collapsed:
                    case Visibility.Hidden:
                    default:
                        return false;
                }
            }

            return false;
        }

    }
}
