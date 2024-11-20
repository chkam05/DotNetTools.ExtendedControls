using chkam05.Tools.ControlsEx.Data;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace chkam05.Tools.ControlsEx.Converters
{
    public class CheckMarkTypePackIconConverter : IValueConverter
    {

        //  CONST

        private static readonly Dictionary<CheckMarkTypeIcon, PackIconKind[]> checkMarkTypeIcons = new Dictionary<CheckMarkTypeIcon, PackIconKind[]>()
        {
            { CheckMarkTypeIcon.Default, new[] { PackIconKind.CheckboxBlankOutline, PackIconKind.Check } },
            { CheckMarkTypeIcon.Filled, new[] { PackIconKind.CheckboxBlank, PackIconKind.CheckboxMarked, PackIconKind.CheckboxBlankOff } },
            { CheckMarkTypeIcon.FilledCircle, new[] { PackIconKind.CheckboxBlankCircle, PackIconKind.CheckboxMarkedCircle, PackIconKind.CircleOffOutline } },
            { CheckMarkTypeIcon.Inline, new[] { PackIconKind.CheckboxBlankOutline, PackIconKind.CheckboxOutline, PackIconKind.CheckboxBlankOffOutline } },
            { CheckMarkTypeIcon.InlineCircle, new[] { PackIconKind.CheckboxBlankCircleOutline, PackIconKind.CheckCircleOutline, PackIconKind.CircleOffOutline } },
            { CheckMarkTypeIcon.Outline, new[] { PackIconKind.CheckboxBlankOutline, PackIconKind.CheckboxMarkedOutline, PackIconKind.CheckboxBlankOffOutline } },
            { CheckMarkTypeIcon.OutlineCircle, new[] { PackIconKind.CheckboxBlankCircleOutline, PackIconKind.CheckboxMarkedCircleOutline, PackIconKind.CircleOffOutline } },
            { CheckMarkTypeIcon.MultipleDefault, new[] { PackIconKind.CheckboxesBlankOutline, PackIconKind.CheckMultiple } },
            { CheckMarkTypeIcon.MultipleFilled, new[] { PackIconKind.CheckboxesBlank, PackIconKind.CheckboxesMarked, PackIconKind.CheckboxBlankOff } },
            { CheckMarkTypeIcon.MultipleFilledCircle, new[] { PackIconKind.CheckboxesBlankCircle, PackIconKind.CheckboxesMarkedCircle, PackIconKind.CircleOffOutline } },
            { CheckMarkTypeIcon.MultipleInline, new[] { PackIconKind.CheckboxesBlankOutline, PackIconKind.CheckboxMultipleOutline, PackIconKind.CheckboxBlankOffOutline } },
            { CheckMarkTypeIcon.MultipleOutline, new[] { PackIconKind.CheckboxesBlankOutline, PackIconKind.CheckboxesMarkedOutline, PackIconKind.CheckboxBlankOffOutline } },
            { CheckMarkTypeIcon.MutlipleOutlineCircle, new[] { PackIconKind.CheckboxesBlankCircleOutline, PackIconKind.CheckboxesMarkedCircleOutline, PackIconKind.CircleOffOutline } },
        };


        //  METHODS

        //  --------------------------------------------------------------------------------
        /// <summary> Converts CheckMarkTypeIcon value to check mark PackIconKind. </summary>
        /// <param name="value"> The CheckMarkTypeIcon value produced by the binding source. </param>
        /// <param name="targetType"> The type of the binding target property. </param>
        /// <param name="parameter"> The converter parameter to use. </param>
        /// <param name="culture"> The culture to use in converter. </param>
        /// <returns> A converted PackIconKind value. If the methods returns null, the vaild null value is used. </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isChecked = (parameter as string)?.ToLower().Contains("checked") ?? false;
            bool isDisabled = (parameter as string)?.ToLower().Contains("disabled") ?? false;

            if (value is CheckMarkTypeIcon checkMarkType)
                return GetCheckMarkIconKind(checkMarkType, isChecked, isDisabled);

            return GetCheckMarkIconKind(CheckMarkTypeIcon.Default, isChecked, isDisabled);
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
        /// <summary> Get check mark PackIconKind from presets dictionary. </summary>
        /// <param name="checkMarkType"> CheckMarkTypeIcon value. </param>
        /// <param name="isChecked"> Is checked parameter. </param>
        /// <param name="isDisabled"> Is disabled parameter. </param>
        /// <returns> PackIconKind value. </returns>
        private PackIconKind GetCheckMarkIconKind(CheckMarkTypeIcon checkMarkType, bool isChecked, bool isDisabled)
        {
            var checkMarkIcons = checkMarkTypeIcons[checkMarkType];

            if (isDisabled && checkMarkIcons.Length == 3)
                return checkMarkIcons[2];

            if (isChecked)
                return checkMarkIcons[1];

            return checkMarkIcons[0];
        }

    }
}
