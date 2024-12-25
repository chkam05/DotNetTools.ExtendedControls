using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using static MaterialDesignThemes.Wpf.Theme;

namespace chkam05.Tools.ControlsEx
{
    public class DatePickerEx : DatePicker
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(DatePickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(Brush),
            typeof(DatePickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected),
            typeof(Brush),
            typeof(DatePickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(DatePickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(DatePickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected),
            typeof(Brush),
            typeof(DatePickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static DependencyProperty ButtonStyleProperty = DependencyProperty.Register(
            nameof(ButtonStyle),
            typeof(Style),
            typeof(DatePickerEx),
            new PropertyMetadata(GetGenericButtonExWithIconStyle()));

        private static readonly new DependencyProperty CalendarStyleProperty = DependencyProperty.Register(
            "CalendarStyle",
            typeof(Style),
            typeof(DatePickerEx),
            new FrameworkPropertyMetadata(null));

        public static DependencyProperty CalendarExStyleProperty = DependencyProperty.Register(
            nameof(CalendarExStyle),
            typeof(Style),
            typeof(DatePickerEx),
            new PropertyMetadata(GetGenericCalendarExStyle()));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(DatePickerEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(DatePickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(DatePickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected),
            typeof(Brush),
            typeof(DatePickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(DatePickerEx),
            new PropertyMetadata(0.56d));

        public static readonly DependencyProperty PreviewTextProperty = DependencyProperty.Register(
            nameof(PreviewText),
            typeof(string),
            typeof(DatePickerEx),
            new PropertyMetadata("Select date..."));

        public static readonly DependencyProperty PreviewTextForegroundProperty = DependencyProperty.Register(
            nameof(PreviewTextForeground),
            typeof(Brush),
            typeof(DatePickerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));


        //  VARIABLES

        private CalendarEx customCalendar;
        private Popup popup;


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

        public Style ButtonStyle
        {
            get => (Style)GetValue(ButtonStyleProperty);
            set => SetValue(ButtonStyleProperty, value);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        private new Style CalendarStyle
        {
            get => base.CalendarStyle;
            set => base.CalendarStyle = value;
        }

        public Style CalendarExStyle
        {
            get => (Style)GetValue(CalendarExStyleProperty);
            set => SetValue(CalendarExStyleProperty, value);
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
        /// <summary> DatePickerEx class constructor. </summary>
        static DatePickerEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DatePickerEx),
                new FrameworkPropertyMetadata(typeof(DatePickerEx)));
        }

        #endregion CONSTRUCTORS

        #region INTERACTION

        //  --------------------------------------------------------------------------------
        /// <summary> Occurs when the collection returned by the CalendarEx SelectedDates property is changed.</summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Selection changed event arguments. </param>
        private void CustomCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (customCalendar.SelectedDate != null)
            {
                SelectedDate = customCalendar.SelectedDate;
                popup.IsOpen = false;
            }
        }

        #endregion INTERACTION

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            popup = GetTemplateChild("PART_Popup") as Popup;

            if (popup != null)
            {
                if (popup.Child is Calendar existingCalendar)
                {
                    customCalendar = new CalendarEx
                    {
                        DisplayDate = existingCalendar.DisplayDate,
                        SelectedDate = existingCalendar.SelectedDate,
                        FirstDayOfWeek = existingCalendar.FirstDayOfWeek,
                        Style = CalendarExStyle
                    };

                    customCalendar.SelectedDatesChanged += CustomCalendar_SelectedDatesChanged;
                    popup.Child = customCalendar;
                }
            }
        }

        #endregion TEMPLATE

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic ButtonExWithIcon style from resources. </summary>
        /// <returns> ButtonExWithIcon style. </returns>
        protected static Style GetGenericButtonExWithIconStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ButtonExWithIcon.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ButtonExWithIcon.ButtonExWithIconStyle"] as Style;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic CalendarEx style from resources. </summary>
        /// <returns> CalendarEx style. </returns>
        protected static Style GetGenericCalendarExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/DatePickerEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["DatePickerEx.CalenderExStyle"] as Style;
        }

        #endregion STYLES

    }
}
