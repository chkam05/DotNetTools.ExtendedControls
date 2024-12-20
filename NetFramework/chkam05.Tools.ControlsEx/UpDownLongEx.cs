using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using chkam05.Tools.ControlsEx.Data.Events;

namespace chkam05.Tools.ControlsEx
{
    public class UpDownLongEx : UpDownEx<long>
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
            nameof(Maximum),
            typeof(long),
            typeof(UpDownLongEx),
            new PropertyMetadata(100L));

        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(
            nameof(Minimum),
            typeof(long),
            typeof(UpDownLongEx),
            new PropertyMetadata(0L));

        public static readonly DependencyProperty StepProperty = DependencyProperty.Register(
            nameof(Step),
            typeof(long),
            typeof(UpDownLongEx),
            new PropertyMetadata(1L));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            nameof(Value),
            typeof(long),
            typeof(UpDownLongEx),
            new PropertyMetadata(50L, OnValuePropertyChanged));


        //  DELEGATES

        public delegate void LongUpDownValueChangedExEventHandler(object sender, UpDownLongValueChangedEventArgsEx e);


        //  EVENTS

        public event LongUpDownValueChangedExEventHandler ValueChangedEx;


        //  GETTERS & SETTERS

        public long Maximum
        {
            get => (long)GetValue(MaximumProperty);
            set => SetValue(MaximumProperty, MathUtilities.Clamp(value, Minimum, long.MaxValue));
        }

        public long Minimum
        {
            get => (long)GetValue(MinimumProperty);
            set => SetValue(MinimumProperty, MathUtilities.Clamp(value, long.MinValue, Maximum));
        }

        public long Step
        {
            get => (long)GetValue(StepProperty);
            set => SetValue(StepProperty, MathUtilities.Clamp(value, 0, Maximum));
        }

        public long Value
        {
            get => (long)GetValue(ValueProperty);
            set => SetValue(ValueProperty, MathUtilities.Clamp(value, Minimum, Maximum));
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownLongEx class constructor. </summary>
        public UpDownLongEx() : base()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownLongEx class constructor. </summary>
        static UpDownLongEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UpDownLongEx),
                new FrameworkPropertyMetadata(typeof(UpDownLongEx)));
        }

        #endregion CONSTRUCTORS

        #region BUTTONS BEHAVIOR

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after clicking up button. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected override void UpButtonClick(object sender, RoutedEventArgs e)
        {
            Value = Math.Min(Maximum, Value + Step);
            ValueChangedEx?.Invoke(this, new UpDownLongValueChangedEventArgsEx(Value, true, true));
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after clicking down button. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected override void DownButtonClick(object sender, RoutedEventArgs e)
        {
            Value = Math.Max(Minimum, Value - Step);
            ValueChangedEx?.Invoke(this, new UpDownLongValueChangedEventArgsEx(Value, true, true));
        }

        #endregion BUTTONS BEHAVIOR

        #region COMPONENT

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after loading component. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected override void OnLoaded(object sender, RoutedEventArgs e)
        {
            previousValue = Value;
            LockTextBoxValueUpdate(previousValue.ToString());
        }

        #endregion COMPONENT

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        #endregion TEMPLATE

        #region TEXTBOX BEHAVIOR

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after text box lost focus. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected override void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            if (textChanged)
            {
                textChanged = false;

                if (ValidateValue(textBox.Text, out string correctValue))
                {
                    lockUpdate = true;

                    if (previousValue.ToString() != correctValue)
                    {
                        var longValue = MathUtilities.Clamp(long.Parse(correctValue), Minimum, Maximum);
                        previousValue = longValue;
                        textBox.Text = previousValue.ToString();
                        Value = longValue;
                        ValueChangedEx?.Invoke(this, new UpDownLongValueChangedEventArgsEx(longValue, true, true));
                    }
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after the contents of the text box change. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Text changed event arguments. </param>
        protected override void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!lockUpdate)
            {
                if (textBox.localFocused)
                {
                    textChanged = true;

                    if (!ValidateValue(textBox.Text, out string correctValue, true))
                    {
                        int carretPosition = textBox.SelectionStart;
                        int textLength = textBox.Text.Length;
                        int textLengthDiff = Math.Max(0, textLength - correctValue.Length);

                        lockUpdate = true;
                        textBox.Text = correctValue;
                        textBox.SelectionStart = Math.Max(0, Math.Min(carretPosition - textLengthDiff, correctValue.Length));
                    }
                }
                else if (!ValidateValue(textBox.Text, out string correctValue))
                {
                    lockUpdate = true;
                    textBox.Text = correctValue;
                }
            }
            else
            {
                lockUpdate = false;
            }
        }

        #endregion TEXTBOX BEHAVIOR

        #region VALUE MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Update text box value in lock mode. </summary>
        /// <param name="newValue"> New value. </param>
        protected override void LockTextBoxValueUpdate(string newValue)
        {
            lockUpdate = true;
            textBox.Text = newValue;
            lockUpdate = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after upading Value propery in dependency property. </summary>
        /// <param name="d"> Dependency object that invoked the method. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as UpDownLongEx)?.LockTextBoxValueUpdate(e.NewValue.ToString());
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Validates a string value to double. </summary>
        /// <param name="newValue"> String value to validate. </param>
        /// <param name="prevValue"> Previous correct value. </param>
        /// <param name="resultValue"> Correct validated value. </param>
        /// <param name="editMode"> Edit mode. </param>
        /// <returns> Returns true if validation was correct, false otherwise. </returns>
        protected override bool ValidateValue(string newValue, out string resultValue, bool editMode = false)
        {
            if (editMode)
            {
                if (string.IsNullOrEmpty(newValue))
                {
                    resultValue = newValue;
                    return true;
                }

                if (newValue.Length == 1 && specialChars.Contains(newValue[0]))
                {
                    resultValue = newValue;
                    return true;
                }

                if (newValue.Length > 1 && long.TryParse(newValue, out long _))
                {
                    resultValue = newValue;
                    return true;
                }
            }

            bool canConvert = long.TryParse(newValue.ToLower(), out long _);
            resultValue = canConvert ? newValue : previousValue.ToString();
            return canConvert;
        }

        #endregion VALUE MANAGEMENT

    }
}
