using chkam05.Tools.ControlsEx.Data;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace chkam05.Tools.ControlsEx.Converters
{
    public class ToggleTypePackIconConverter : IValueConverter
    {

        //  CONST

        private static readonly Dictionary<ToggleTypeIcon, PackIconKind[]> checkMarkTypeIcons = new Dictionary<ToggleTypeIcon, PackIconKind[]>()
        {
            { ToggleTypeIcon.Filled, new[] { PackIconKind.ToggleSwitchOff, PackIconKind.ToggleSwitch } },
            { ToggleTypeIcon.Outline, new[] { PackIconKind.ToggleSwitchOffOutline, PackIconKind.ToggleSwitchOutline } }
        };


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Converts ToggleTypeIcon value to check mark PackIconKind. </summary>
        /// <param name="value"> The ToggleTypeIcon value produced by the binding source. </param>
        /// <param name="targetType"> The type of the binding target property. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in converter. </param>
        /// <returns> A converted PackIconKind value. If the methods returns null, the vaild null value is used. </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isChecked = (parameter as string)?.ToLower().Contains("checked") ?? false;

            if (value is ToggleTypeIcon checkMarkType)
                return GetToggleIconKind(checkMarkType, isChecked);

            return GetToggleIconKind(ToggleTypeIcon.Filled, isChecked);
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
        /// <summary> Get toggle PackIconKind from presets dictionary. </summary>
        /// <param name="checkMarkType"> ToggleTypeIcon value. </param>
        /// <param name="isChecked"> Is checked parameter. </param>
        /// <returns> PackIconKind value. </returns>
        private PackIconKind GetToggleIconKind(ToggleTypeIcon checkMarkType, bool isChecked)
        {
            var checkMarkIcons = checkMarkTypeIcons[checkMarkType];

            if (isChecked)
                return checkMarkIcons[1];

            return checkMarkIcons[0];
        }

    }
}
