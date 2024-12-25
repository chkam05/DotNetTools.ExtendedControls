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
using System.Windows.Media.TextFormatting;

namespace chkam05.Tools.ControlsEx
{
    public class TextBoxEx : TextBox
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(TextBoxEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(TextBoxEx),
            new PropertyMetadata(0.56d));

        public static readonly DependencyProperty PreviewTextProperty = DependencyProperty.Register(
            nameof(PreviewText),
            typeof(string),
            typeof(TextBoxEx),
            new PropertyMetadata("Enter text here..."));

        public static readonly DependencyProperty PreviewTextForegroundProperty = DependencyProperty.Register(
            nameof(PreviewTextForeground),
            typeof(Brush),
            typeof(TextBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));


        //  DELEGATES

        public delegate void OnTextChangedExEventHandler(object sender, TextChangedEventArgsEx e);


        //  EVENTS

        public event OnTextChangedExEventHandler OnTextChangedEx;


        //  VARIABLES

        internal bool localFocused = false;
        internal TextChangedEventArgs textChangedEventArgs = null;


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

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }

        public string PreviewText
        {
            get => (string)GetValue(PreviewTextProperty);
            set => SetValue(PreviewTextProperty, value);
        }

        public Brush PreviewTextForeground
        {
            get => (Brush)GetValue(PreviewTextForegroundProperty);
            set => SetValue(PreviewTextForegroundProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> Static TextBoxEx class constructor. </summary>
        static TextBoxEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBoxEx),
                new FrameworkPropertyMetadata(typeof(TextBoxEx)));
        }

        #endregion CONSTRUCTORS

        #region USER INTERACTION

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever an GotFocus event reaches this element in its route. </summary>
        /// <param name="e"> Routed event arguments. </param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            localFocused = true;
            base.OnGotFocus(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Raises the LostFocus event (using the provided arguments). </summary>
        /// <param name="e"> Routed event arguments. </param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            if (textChangedEventArgs != null)
            {
                OnTextChangedEx?.Invoke(this, new TextChangedEventArgsEx(textChangedEventArgs, localFocused, true));
                textChangedEventArgs = null;
            }

            localFocused = false;
            base.OnLostFocus(e);
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Is called when content in this editing control changes. </summary>
        /// <param name="e"> Text changed event arguments. </param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if (localFocused)
                textChangedEventArgs = e;

            OnTextChangedEx?.Invoke(this, new TextChangedEventArgsEx(e, localFocused, false));
            base.OnTextChanged(e);
        }

        #endregion USER INTERACTION

    }
}
