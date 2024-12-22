using chkam05.Tools.ControlsEx.Utilities;
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
    public class InnerCornerRadiusConverter : IMultiValueConverter
    {

        //  CONST

        private const string TOP_LEFT_PARAM_KEY = "TOPLEFT";
        private const string TOP_RIGHT_PARAM_KEY = "TOPRIGHT";
        private const string BOTTOM_RIGHT_PARAM_KEY = "BOTTOMRIGHT";
        private const string BOTTOM_LEFT_PARAM_KEY = "BOTTOMLEFT";

        private static readonly string[] operators = new string[] { "+", "-", "*", "/" };
        private static readonly string[] parametersKeys = new string[]
        {
            TOP_LEFT_PARAM_KEY, TOP_RIGHT_PARAM_KEY, BOTTOM_RIGHT_PARAM_KEY, BOTTOM_LEFT_PARAM_KEY
        };
        private static readonly string[] distanceKeys = new string[]
        {
            "T", "THICKNESS"
        };


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Calculates inner CornerRadius value. </summary>
        /// <param name="values"> The outer CornerRadius value and inner object Thickness produced by the binding source. </param>
        /// <param name="targetType"> The type of the binding target property. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in converter. </param>
        /// <returns> A calculated inner CornerRadius value. If the methods returns null, the vaild null value is used. </returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (ObjectUtilities.GetValue(values, out CornerRadius outerCornerRadius))
            {
                var innerThickness = ObjectUtilities.GetValue(values, out Thickness tempInnerThickness)
                    ? tempInnerThickness
                    : new Thickness(0);

                var innerValues = ObjectUtilities.GetValues(values, out IEnumerable<double> tempInnerValues)
                    ? tempInnerValues.ToArray()
                    : new double[0];

                if (parameter is string strParameter)
                {
                    return ModifyWithParameter(outerCornerRadius, innerThickness, strParameter.ToUpper().Split(';'), innerValues);
                }

                return new CornerRadius(
                    outerCornerRadius.TopLeft - Math.Max(innerThickness.Left, innerThickness.Top),
                    outerCornerRadius.TopRight - Math.Max(innerThickness.Top, innerThickness.Right),
                    outerCornerRadius.BottomRight - Math.Max(innerThickness.Right, innerThickness.Bottom),
                    outerCornerRadius.BottomLeft - Math.Max(innerThickness.Bottom, innerThickness.Left));
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
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Modifies CornerRadius using additional parameters. </summary>
        /// <param name="outerCornerRadius"> The outer CornerRadius value to modify. </param>
        /// <param name="innerThickness"> The inner object Thickness modificator. </param>
        /// <param name="parameters"> Array of additional modification parameters. </param>
        /// <param name="innerValues"> Additional array of double values. </param>
        /// <returns> A modified CornerRadius. </returns>
        private CornerRadius ModifyWithParameter(CornerRadius outerCornerRadius, Thickness innerThickness, string[] parameters, double[] innerValues)
        {
            var topLeft = outerCornerRadius.TopLeft;
            var topRight = outerCornerRadius.TopRight;
            var bottomRight = outerCornerRadius.BottomRight;
            var bottomLeft = outerCornerRadius.BottomLeft;

            var topLeftDistance = Math.Max(innerThickness.Left, innerThickness.Top);
            var topRightDistance = Math.Max(innerThickness.Top, innerThickness.Right);
            var bottomRightDistance = Math.Max(innerThickness.Right, innerThickness.Bottom);
            var bottomLeftDistance = Math.Max(innerThickness.Bottom, innerThickness.Left);

            foreach (var parameterKey in parametersKeys)
            {
                var parameter = parameters.FirstOrDefault(p => p.StartsWith(parameterKey))?.Split(':').Last();

                switch (parameterKey)
                {
                    case TOP_LEFT_PARAM_KEY:
                        topLeft = ProcessParameter(topLeft, topLeftDistance, parameterKey, parameter, innerValues, outerCornerRadius);
                        break;

                    case TOP_RIGHT_PARAM_KEY:
                        topRight = ProcessParameter(topRight, topRightDistance, parameterKey, parameter, innerValues, outerCornerRadius);
                        break;

                    case BOTTOM_RIGHT_PARAM_KEY:
                        bottomRight = ProcessParameter(bottomRight, bottomRightDistance, parameterKey, parameter, innerValues, outerCornerRadius);
                        break;

                    case BOTTOM_LEFT_PARAM_KEY:
                        bottomLeft = ProcessParameter(bottomLeft, bottomLeftDistance, parameterKey, parameter, innerValues, outerCornerRadius);
                        break;
                }
            }

            return new CornerRadius(topLeft, topRight, bottomRight, bottomLeft);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Modifies single attribute of CornerRadius using additional parameters. </summary>
        /// <param name="value"> CornerRadius single attribute. </param>
        /// <param name="distance"> Distance between CornerRadius and inner object. </param>
        /// <param name="key"> CornerRadius angle definition key. </param>
        /// <param name="parameter"> Additional modification parameter. </param>
        /// <param name="innerValues"> Additional array of double values. </param>
        /// <param name="outerCornerRadius"> The outer CornerRadius value. </param>
        /// <returns> Modified CornerRadius attribute. </returns>
        private double ProcessParameter(double value, double distance, string key, string parameter, double[] innerValues, CornerRadius outerCornerRadius)
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

                            if (v.Contains('{') && v.Contains('}'))
                            {
                                int innerValueKey = int.Parse(v.Replace("{", "").Replace("}", ""));
                                return innerValues[innerValueKey];
                            }

                            if (distanceKeys.Contains(v.ToUpper()))
                                return distance;

                            if (parametersKeys.Contains(v.ToUpper()))
                                return GetCorner(outerCornerRadius, v.ToUpper());

                            return (double?)null;
                        })
                        .Where(v => v.HasValue)
                        .Select(v => v.Value)
                        .ToList();

                    var opers = parameter.Where(c => operators.Any(o => o == $"{c}")).ToArray();

                    if (!values.Any() || !opers.Any())
                        return value;

                    bool firstOper = opers.Length == values.Count && opers[0] == '-';
                    var jumps = Math.Min(opers.Length, values.Count);
                    double result = firstOper ? -(values[0]) : values[0];

                    for (int i = 1; i < (firstOper ? jumps-1 : jumps) + 1; i++)
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
                    return GetCorner(outerCornerRadius, parameter.ToUpper());
                }
                else if (parametersKeys.Contains(key))
                {
                    return value;
                }
            }

            return value - distance;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get corner radius side value from corner radius by side key. </summary>
        /// <param name="cornerRadius"> The Corner radius whose value is to be extracted. </param>
        /// <param name="key"> CornerRadius angle definition key. </param>
        /// <returns> Corner radius single attribute or 0. </returns>
        private double GetCorner(CornerRadius cornerRadius, string key)
        {
            switch (key)
            {
                case TOP_LEFT_PARAM_KEY:
                    return cornerRadius.TopLeft;

                case TOP_RIGHT_PARAM_KEY:
                    return cornerRadius.TopRight;

                case BOTTOM_RIGHT_PARAM_KEY:
                    return cornerRadius.BottomRight;

                case BOTTOM_LEFT_PARAM_KEY:
                    return cornerRadius.BottomLeft;
            }

            return 0;
        }
    }
}
