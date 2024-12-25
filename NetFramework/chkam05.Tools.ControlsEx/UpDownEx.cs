using chkam05.Tools.ControlsEx.Data.Events;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx
{
    public abstract class UpDownEx<T> : Control
    {

        //  CONST

        protected static readonly char[] floatingPointSpecialChars = new char[] { ',' };
        protected static readonly char[] specialChars = new char[] { '-' };


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightMouseOver)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightSelected)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty ButtonBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonBackground),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColor)));

        public static readonly DependencyProperty ButtonBackgroundInactiveProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundInactive),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty ButtonBackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundMouseOver),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ButtonBackgroundPressedProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundPressed),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty ButtonStyleProperty = DependencyProperty.Register(
            nameof(ButtonStyle),
            typeof(Style),
            typeof(UpDownEx<T>),
            new PropertyMetadata(GetGenericButtonExStyle()));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected),
            typeof(Brush),
            typeof(UpDownEx<T>),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            nameof(IconHeight),
            typeof(double),
            typeof(UpDownEx<T>),
            new PropertyMetadata(12d));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
            nameof(IconWidth),
            typeof(double),
            typeof(UpDownEx<T>),
            new PropertyMetadata(12d));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(UpDownEx<T>),
            new PropertyMetadata(0.56d));

        public static readonly DependencyProperty TextBoxStyleProperty = DependencyProperty.Register(
            nameof(TextBoxStyle),
            typeof(Style),
            typeof(UpDownEx<T>),
            new PropertyMetadata(GetGenericTextBoxExStyle()));


        //  VARIABLES

        protected ButtonEx upButton;
        protected ButtonEx downButton;
        protected TextBoxEx textBox;

        protected bool lockUpdate = false;
        protected T previousValue = default(T);
        protected bool textChanged = false;


        //  GETTERS & SETTERS

        public Brush BackgroundInactive
        {
            get => (Brush)GetValue(BackgroundInactiveProperty);
            set => SetValue(BackgroundInactiveProperty, value);
        }

        public Brush BackgroundMouseOver
        {
            get => (Brush)GetValue(BackgroundMouseOverProperty);
            set => SetValue(BackgroundMouseOverProperty, value);
        }

        public Brush BackgroundSelected
        {
            get => (Brush)GetValue(BackgroundSelectedProperty);
            set => SetValue(BackgroundSelectedProperty, value);
        }

        public Brush BorderBrushInactive
        {
            get => (Brush)GetValue(BorderBrushInactiveProperty);
            set => SetValue(BorderBrushInactiveProperty, value);
        }

        public Brush BorderBrushMouseOver
        {
            get => (Brush)GetValue(BorderBrushMouseOverProperty);
            set => SetValue(BorderBrushMouseOverProperty, value);
        }

        public Brush BorderBrushSelected
        {
            get => (Brush)GetValue(BorderBrushSelectedProperty);
            set => SetValue(BorderBrushSelectedProperty, value);
        }

        public Brush ButtonBackground
        {
            get => (Brush)GetValue(ButtonBackgroundProperty);
            set => SetValue(ButtonBackgroundProperty, value);
        }

        public Brush ButtonBackgroundInactive
        {
            get => (Brush)GetValue(ButtonBackgroundInactiveProperty);
            set => SetValue(ButtonBackgroundInactiveProperty, value);
        }

        public Brush ButtonBackgroundMouseOver
        {
            get => (Brush)GetValue(ButtonBackgroundMouseOverProperty);
            set => SetValue(ButtonBackgroundMouseOverProperty, value);
        }

        public Brush ButtonBackgroundPressed
        {
            get => (Brush)GetValue(ButtonBackgroundPressedProperty);
            set => SetValue(ButtonBackgroundPressedProperty, value);
        }

        public Style ButtonStyle
        {
            get => (Style)GetValue(ButtonStyleProperty);
            set => SetValue(ButtonStyleProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Brush ForegroundInactive
        {
            get => (Brush)GetValue(ForegroundInactiveProperty);
            set => SetValue(ForegroundInactiveProperty, value);
        }

        public Brush ForegroundMouseOver
        {
            get => (Brush)GetValue(ForegroundMouseOverProperty);
            set => SetValue(ForegroundMouseOverProperty, value);
        }

        public Brush ForegroundSelected
        {
            get => (Brush)GetValue(ForegroundSelectedProperty);
            set => SetValue(ForegroundSelectedProperty, value);
        }

        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, Math.Max(0, value));
        }

        public double IconWidth
        {
            get => (double)GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, Math.Max(0, value));
        }

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }

        public Style TextBoxStyle
        {
            get => (Style)GetValue(TextBoxStyleProperty);
            set => SetValue(TextBoxStyleProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> UpDownEx class constructor. </summary>
        public UpDownEx()
        {
            Loaded += OnLoaded;
        }

        #endregion CONSTRUCTORS

        #region BUTTONS BEHAVIOR

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after clicking up button. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected virtual void UpButtonClick(object sender, RoutedEventArgs e)
        {
            //  Place for increment Value.
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after clicking down button. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected virtual void DownButtonClick(object sender, RoutedEventArgs e)
        {
            //  Place for decrement Value.
        }

        #endregion BUTTONS BEHAVIOR

        #region COMPONENT

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after loading component. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected virtual void OnLoaded(object sender, RoutedEventArgs e)
        {
            //  Place for move value from Value to TextBoxEx.
        }

        #endregion COMPONENT

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic Button style from resources. </summary>
        /// <returns> ScrollBarEx style. </returns>
        protected static Style GetGenericButtonExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ButtonEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ButtonEx.ButtonExStyle"] as Style;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic TextBox style from resources. </summary>
        /// <returns> ScrollBarEx style. </returns>
        protected static Style GetGenericTextBoxExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/TextBoxEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["TextBoxEx.TextBoxExStyle"] as Style;
        }

        #endregion STYLES

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            upButton = this.Template.FindName("upButton", this) as ButtonEx;
            downButton = this.Template.FindName("downButton", this) as ButtonEx;
            textBox = this.Template.FindName("textBox", this) as TextBoxEx;

            upButton.Click += UpButtonClick;
            downButton.Click += DownButtonClick;

            textBox.LostFocus += TextBoxLostFocus;
            textBox.TextChanged += TextBoxTextChanged;
        }

        #endregion TEMPLATE

        #region TEXTBOX BEHAVIOR

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after text box lost focus. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        protected virtual void TextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            //  Place for final Value manual update.
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after the contents of the text box change. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Text changed event arguments. </param>
        protected virtual void TextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            //  Place for Value manual update validation.
        }

        #endregion TEXTBOX BEHAVIOR

        #region VALUE MANAGEMENT

        //  --------------------------------------------------------------------------------
        /// <summary> Update text box value in lock mode. </summary>
        /// <param name="newValue"> New value. </param>
        protected virtual void LockTextBoxValueUpdate(string newValue)
        {
            lockUpdate = true;
            textBox.Text = newValue;
            lockUpdate = false;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Validates a string value to double. </summary>
        /// <param name="newValue"> String value to validate. </param>
        /// <param name="prevValue"> Previous correct value. </param>
        /// <param name="resultValue"> Correct validated value. </param>
        /// <param name="editMode"> Edit mode. </param>
        /// <returns> Returns true if validation was correct, false otherwise. </returns>
        protected virtual bool ValidateValue(string newValue, out string resultValue, bool editMode = false)
        {
            //  Place for Value validation.
            resultValue = newValue;
            return false;
        }

        #endregion VALUE MANAGEMENT

    }
}
