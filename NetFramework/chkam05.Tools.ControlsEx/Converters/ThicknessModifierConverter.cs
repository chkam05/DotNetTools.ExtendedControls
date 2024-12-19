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
    public class ThicknessModifierConverter : IValueConverter
    {

        //  CONST

        private const string LEFT_PARAM_KEY = "LEFT";
        private const string TOP_PARAM_KEY = "TOP";
        private const string RIGHT_PARAM_KEY = "RIGHT";
        private const string BOTTOM_PARAM_KEY = "BOTTOM";

        private static readonly string[] operators = new string[] { "+", "-", "*", "/" };
        private static readonly string[] parametersKeys = new string[]
        {
            LEFT_PARAM_KEY, TOP_PARAM_KEY, RIGHT_PARAM_KEY, BOTTOM_PARAM_KEY
        };


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Modifies Thickness value. </summary>
        /// <param name="value"> The Thickness value produced by the binding source. </param>
        /// <param name="targetType"> The type of the binding target property. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in converter. </param>
        /// <returns> A modified Thickness value. If the methods returns null, the vaild null value is used. </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness thickness)
            {
                if (parameter is string strParameter)
                {
                    return ModifyWithParameter(thickness, strParameter.ToUpper().Split(';'));
                }

                return thickness;
            }

            return null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Converts a value. </summary>
        /// <param name="value"> The value that is produced by the binding target. </param>
        /// <param name="targetType"> The type to convert to. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in the converter. </param>
        /// <returns> A converted value. If the method returns null, the valid null value is used. </returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Modifies Thickness using additional parameters. </summary>
        /// <param name="thickness"> The Thickness value to modify. </param>
        /// <param name="parameters"> Array of additional modification parameters. </param>
        /// <returns> A modified Thickness. </returns>
        private Thickness ModifyWithParameter(Thickness thickness, string[] parameters)
        {
            var left = thickness.Left;
            var top = thickness.Top;
            var right = thickness.Right;
            var bottom = thickness.Bottom;

            foreach (var parameterKey in parametersKeys)
            {
                var parameter = parameters.FirstOrDefault(p => p.StartsWith(parameterKey))?.Split(':').Last();

                switch (parameterKey)
                {
                    case LEFT_PARAM_KEY:
                        left = ProcessParameter(left, parameter, thickness);
                        break;

                    case TOP_PARAM_KEY:
                        top = ProcessParameter(top, parameter, thickness);
                        break;

                    case RIGHT_PARAM_KEY:
                        right = ProcessParameter(right, parameter, thickness);
                        break;

                    case BOTTOM_PARAM_KEY:
                        bottom = ProcessParameter(bottom, parameter, thickness);
                        break;
                }
            }

            return new Thickness(left, top, right, bottom);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Modifies single attribute of Thickness using additional parameters. </summary>
        /// <param name="value"> Thickness single attribute. </param>
        /// <param name="parameter"> Additional modification parameter. </param>
        /// <param name="thickness"> The Thickness value. </param>
        /// <returns> Modified Thickness attribute. </returns>
        private double ProcessParameter(double value, string parameter, Thickness thickness)
        {
            if (!string.IsNullOrEmpty(parameter))
            {
                if (operators.Any(o => parameter.Contains(o)))
                {
                    var values = parameter.Split(operators, StringSplitOptions.RemoveEmptyEntries)
                        .Select(v =>
                        {
                            if (double.TryParse(v, out double dv))
                                return dv;

                            if (parametersKeys.Contains(v.ToUpper()))
                                return GetSide(thickness, v.ToUpper());

                            return (double?)null;
                        })
                        .Where(v => v.HasValue)
                        .Select(v => v.Value)
                        .ToList();

                    var opers = parameter.Select(c => operators.Any(o => o == $"{c}")).ToString();

                    if (!values.Any() || !opers.Any())
                        return value;

                    bool firstOper = opers.Length == values.Count && opers[0] == '-';
                    var jumps = Math.Min(opers.Length, values.Count);
                    double result = firstOper ? -(values[0]) : values[0];

                    for (int i = 1; i < (firstOper ? jumps - 1 : jumps); i++)
                    {
                        var nextValue = values[i];
                        var nextOper = opers[firstOper ? i : i - 1];

                        switch (nextOper)
                        {
                            case '+':
                                result = result + nextValue;
                                break;

                            case '-':
                                result = result - nextValue;
                                break;

                            case '*':
                                result = result * nextValue;
                                break;

                            case '/':
                                result = result / (nextValue == 0 ? 1 : nextValue);
                                break;
                        }
                    }

                    return result;
                }
                else if (double.TryParse(parameter, out double paramValue))
                {
                    return paramValue;
                }
                else if (parametersKeys.Contains(parameter.ToUpper()))
                {
                    return GetSide(thickness, parameter.ToUpper());
                }
            }

            return value;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get thickness side value from thickness by side key. </summary>
        /// <param name="thickness"> The Thickness whose value is to be extracted. </param>
        /// <param name="key"> Thickness angle definition key. </param>
        /// <returns> Thickness single attribute or 0. </returns>
        private double GetSide(Thickness thickness, string key)
        {
            switch (key)
            {
                case LEFT_PARAM_KEY:
                    return thickness.Left;

                case TOP_PARAM_KEY:
                    return thickness.Top;

                case RIGHT_PARAM_KEY:
                    return thickness.Right;

                case BOTTOM_PARAM_KEY:
                    return thickness.Bottom;
            }

            return 0;
        }
    }
}
