using chkam05.Tools.ControlsEx.Data;
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
    public class CalendarEx : Calendar
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(CalendarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(CalendarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ContentPaddingProperty = DependencyProperty.Register(
            nameof(ContentPadding),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(4)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(CalendarEx),
            new PropertyMetadata(new CornerRadius(4)));

        #region DayMonthYearButton

        public static readonly DependencyProperty DayMonthYearButtonBackgroundProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBackground),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty DayMonthYearButtonBackgroundBlackedOutProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBackgroundBlackedOut),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty DayMonthYearButtonBackgroundInactiveProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBackgroundInactive),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty DayMonthYearButtonBackgroundMouseOverProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBackgroundMouseOver),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty DayMonthYearButtonBackgroundPressedProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBackgroundPressed),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty DayMonthYearButtonBackgroundTodayProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBackgroundToday),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty DayMonthYearButtonBorderBrushProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBorderBrush),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty DayMonthYearButtonBorderBrushBlackedOutProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBorderBrushBlackedOut),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty DayMonthYearButtonBorderBrushInactiveProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBorderBrushInactive),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty DayMonthYearButtonBorderBrushMouseOverProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBorderBrushMouseOver),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty DayMonthYearButtonBorderBrushPressedProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBorderBrushPressed),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty DayMonthYearButtonBorderBrushTodayProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonBorderBrushToday),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColor)));

        public static readonly DependencyProperty DayMonthYearButtonBorderThicknessProperty = DependencyProperty.Register(
            nameof(DayMonthYearButtonBorderThickness),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty DayMonthYearButtonForegroundProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonForeground),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty DayMonthYearButtonForegroundBlackedOutProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonForegroundBlackedOut),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty DayMonthYearButtonForegroundInactiveProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonForegroundInactive),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty DayMonthYearButtonForegroundMouseOverProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonForegroundMouseOver),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty DayMonthYearButtonForegroundPressedProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonForegroundPressed),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty DayMonthYearButtonForegroundTodayProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonForegroundToday),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColor)));

        public static readonly DependencyProperty DayMonthYearButtonCornerRadiusProperty = DependencyProperty.Register(
              nameof(DayMonthYearButtonCornerRadius),
              typeof(CornerRadius),
              typeof(CalendarEx),
              new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty DayMonthYearButtonMarginProperty = DependencyProperty.Register(
            nameof(DayMonthYearButtonMargin),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty DayMonthYearButtonPaddingProperty = DependencyProperty.Register(
            nameof(DayMonthYearButtonPadding),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(1)));

        #endregion DayMonthYearButton

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(CalendarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty HeaderBackgroundProperty = DependencyProperty.Register(
            nameof(HeaderBackground),
            typeof(Brush),
            typeof(CalendarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty HeaderBorderBrushProperty = DependencyProperty.Register(
            nameof(HeaderBorderBrush),
            typeof(Brush),
            typeof(CalendarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty HeaderBorderThicknessProperty = DependencyProperty.Register(
            nameof(HeaderBorderThickness),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(1)));

        #region HeaderNavigationButton

        public static readonly DependencyProperty HeaderNavigationButtonBackgroundProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonBackground),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty HeaderNavigationButtonBackgroundInactiveProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonBackgroundInactive),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty HeaderNavigationButtonBackgroundMouseOverProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonBackgroundMouseOver),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty HeaderNavigationButtonBackgroundPressedProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonBackgroundPressed),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty HeaderNavigationButtonBorderBrushProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonBorderBrush),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty HeaderNavigationButtonBorderBrushInactiveProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonBorderBrushInactive),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty HeaderNavigationButtonBorderBrushMouseOverProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonBorderBrushMouseOver),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty HeaderNavigationButtonBorderBrushPressedProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonBorderBrushPressed),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty HeaderNavigationButtonBorderThicknessProperty = DependencyProperty.Register(
            nameof(HeaderNavigationButtonBorderThickness),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty HeaderNavigationButtonForegroundProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonForeground),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty HeaderNavigationButtonForegroundInactiveProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonForegroundInactive),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty HeaderNavigationButtonForegroundMouseOverProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonForegroundMouseOver),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty HeaderNavigationButtonForegroundPressedProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonForegroundPressed),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty HeaderNavigationButtonCornerRadiusProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonCornerRadius),
              typeof(CornerRadius),
              typeof(CalendarEx),
              new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty HeaderNavigationButtonIconHeightProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonIconHeight),
              typeof(double),
              typeof(CalendarEx),
              new PropertyMetadata(16d));

        public static readonly DependencyProperty HeaderNavigationButtonIconWidthProperty = DependencyProperty.Register(
              nameof(HeaderNavigationButtonIconWidth),
              typeof(double),
              typeof(CalendarEx),
              new PropertyMetadata(16d));

        public static readonly DependencyProperty HeaderNavigationButtonMarginProperty = DependencyProperty.Register(
            nameof(HeaderNavigationButtonMargin),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty HeaderNavigationButtonPaddingProperty = DependencyProperty.Register(
            nameof(HeaderNavigationButtonPadding),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty HeaderNavigationButtonPositionProperty = DependencyProperty.Register(
            nameof(HeaderNavigationButtonPosition),
            typeof(HorizontalAlignment),
            typeof(CalendarEx),
            new PropertyMetadata(HorizontalAlignment.Stretch));

        #endregion HeaderNavigationButton

        public static readonly DependencyProperty HeaderPaddingProperty = DependencyProperty.Register(
            nameof(HeaderPadding),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty CalendarExHeaderPositionProperty = DependencyProperty.Register(
            nameof(CalendarExHeaderPosition),
            typeof(CalendarExHeaderPosition),
            typeof(CalendarEx),
            new PropertyMetadata(CalendarExHeaderPosition.Top));

        #region HeaderTitleButton

        public static readonly DependencyProperty HeaderTitleButtonBackgroundProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonBackground),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty HeaderTitleButtonBackgroundInactiveProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonBackgroundInactive),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty HeaderTitleButtonBackgroundMouseOverProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonBackgroundMouseOver),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty HeaderTitleButtonBackgroundPressedProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonBackgroundPressed),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty HeaderTitleButtonBorderBrushProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonBorderBrush),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty HeaderTitleButtonBorderBrushInactiveProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonBorderBrushInactive),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty HeaderTitleButtonBorderBrushMouseOverProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonBorderBrushMouseOver),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty HeaderTitleButtonBorderBrushPressedProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonBorderBrushPressed),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty HeaderTitleButtonBorderThicknessProperty = DependencyProperty.Register(
            nameof(HeaderTitleButtonBorderThickness),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty HeaderTitleButtonForegroundProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonForeground),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty HeaderTitleButtonForegroundInactiveProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonForegroundInactive),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty HeaderTitleButtonForegroundMouseOverProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonForegroundMouseOver),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty HeaderTitleButtonForegroundPressedProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonForegroundPressed),
              typeof(Brush),
              typeof(CalendarEx),
              new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty HeaderTitleButtonCornerRadiusProperty = DependencyProperty.Register(
              nameof(HeaderTitleButtonCornerRadius),
              typeof(CornerRadius),
              typeof(CalendarEx),
              new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty HeaderTitleButtonMarginProperty = DependencyProperty.Register(
            nameof(HeaderTitleButtonMargin),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty HeaderTitleButtonPaddingProperty = DependencyProperty.Register(
            nameof(HeaderTitleButtonPadding),
            typeof(Thickness),
            typeof(CalendarEx),
            new PropertyMetadata(new Thickness(4)));

        #endregion HeaderTitleButton

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(CalendarEx),
            new PropertyMetadata(0.56d));


        //  GETTERS & SETTERS

        public Brush BackgroundInactive
        {
            get => (Brush)GetValue(BackgroundInactiveProperty);
            set => SetValue(BackgroundInactiveProperty, value);
        }

        public Brush BorderBrushInactive
        {
            get => (Brush)GetValue(BorderBrushInactiveProperty);
            set => SetValue(BorderBrushInactiveProperty, value);
        }

        public Thickness ContentPadding
        {
            get => (Thickness)GetValue(ContentPaddingProperty);
            set => SetValue(ContentPaddingProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        #region DayMonthYearButton

        public Brush DayMonthYearButtonBackground
        {
            get => (Brush)GetValue(DayMonthYearButtonBackgroundProperty);
            set => SetValue(DayMonthYearButtonBackgroundProperty, value);
        }

        public Brush DayMonthYearButtonBackgroundBlackedOut
        {
            get => (Brush)GetValue(DayMonthYearButtonBackgroundBlackedOutProperty);
            set => SetValue(DayMonthYearButtonBackgroundBlackedOutProperty, value);
        }

        public Brush DayMonthYearButtonBackgroundInactive
        {
            get => (Brush)GetValue(DayMonthYearButtonBackgroundInactiveProperty);
            set => SetValue(DayMonthYearButtonBackgroundInactiveProperty, value);
        }

        public Brush DayMonthYearButtonBackgroundMouseOver
        {
            get => (Brush)GetValue(DayMonthYearButtonBackgroundMouseOverProperty);
            set => SetValue(DayMonthYearButtonBackgroundMouseOverProperty, value);
        }

        public Brush DayMonthYearButtonBackgroundPressed
        {
            get => (Brush)GetValue(DayMonthYearButtonBackgroundPressedProperty);
            set => SetValue(DayMonthYearButtonBackgroundPressedProperty, value);
        }

        public Brush DayMonthYearButtonBackgroundToday
        {
            get => (Brush)GetValue(DayMonthYearButtonBackgroundTodayProperty);
            set => SetValue(DayMonthYearButtonBackgroundTodayProperty, value);
        }

        public Brush DayMonthYearButtonBorderBrush
        {
            get => (Brush)GetValue(DayMonthYearButtonBorderBrushProperty);
            set => SetValue(DayMonthYearButtonBorderBrushProperty, value);
        }

        public Brush DayMonthYearButtonBorderBrushBlackedOut
        {
            get => (Brush)GetValue(DayMonthYearButtonBorderBrushBlackedOutProperty);
            set => SetValue(DayMonthYearButtonBorderBrushBlackedOutProperty, value);
        }

        public Brush DayMonthYearButtonBorderBrushInactive
        {
            get => (Brush)GetValue(DayMonthYearButtonBorderBrushInactiveProperty);
            set => SetValue(DayMonthYearButtonBorderBrushInactiveProperty, value);
        }

        public Brush DayMonthYearButtonBorderBrushMouseOver
        {
            get => (Brush)GetValue(DayMonthYearButtonBorderBrushMouseOverProperty);
            set => SetValue(DayMonthYearButtonBorderBrushMouseOverProperty, value);
        }

        public Brush DayMonthYearButtonBorderBrushPressed
        {
            get => (Brush)GetValue(DayMonthYearButtonBorderBrushPressedProperty);
            set => SetValue(DayMonthYearButtonBorderBrushPressedProperty, value);
        }

        public Brush DayMonthYearButtonBorderBrushToday
        {
            get => (Brush)GetValue(DayMonthYearButtonBorderBrushTodayProperty);
            set => SetValue(DayMonthYearButtonBorderBrushTodayProperty, value);
        }

        public Thickness DayMonthYearButtonBorderThickness
        {
            get => (Thickness)GetValue(DayMonthYearButtonBorderThicknessProperty);
            set => SetValue(DayMonthYearButtonBorderThicknessProperty, value);
        }

        public Brush DayMonthYearButtonForeground
        {
            get => (Brush)GetValue(DayMonthYearButtonForegroundProperty);
            set => SetValue(DayMonthYearButtonForegroundProperty, value);
        }

        public Brush DayMonthYearButtonForegroundBlackedOut
        {
            get => (Brush)GetValue(DayMonthYearButtonForegroundBlackedOutProperty);
            set => SetValue(DayMonthYearButtonForegroundBlackedOutProperty, value);
        }

        public Brush DayMonthYearButtonForegroundInactive
        {
            get => (Brush)GetValue(DayMonthYearButtonForegroundInactiveProperty);
            set => SetValue(DayMonthYearButtonForegroundInactiveProperty, value);
        }

        public Brush DayMonthYearButtonForegroundMouseOver
        {
            get => (Brush)GetValue(DayMonthYearButtonForegroundMouseOverProperty);
            set => SetValue(DayMonthYearButtonForegroundMouseOverProperty, value);
        }

        public Brush DayMonthYearButtonForegroundPressed
        {
            get => (Brush)GetValue(DayMonthYearButtonForegroundPressedProperty);
            set => SetValue(DayMonthYearButtonForegroundPressedProperty, value);
        }

        public Brush DayMonthYearButtonForegroundToday
        {
            get => (Brush)GetValue(DayMonthYearButtonForegroundTodayProperty);
            set => SetValue(DayMonthYearButtonForegroundTodayProperty, value);
        }

        public CornerRadius DayMonthYearButtonCornerRadius
        {
            get => (CornerRadius)GetValue(DayMonthYearButtonCornerRadiusProperty);
            set => SetValue(DayMonthYearButtonCornerRadiusProperty, value);
        }

        public Thickness DayMonthYearButtonMargin
        {
            get => (Thickness)GetValue(DayMonthYearButtonMarginProperty);
            set => SetValue(DayMonthYearButtonMarginProperty, value);
        }

        public Thickness DayMonthYearButtonPadding
        {
            get => (Thickness)GetValue(DayMonthYearButtonPaddingProperty);
            set => SetValue(DayMonthYearButtonPaddingProperty, value);
        }

        #endregion DayMonthYearButton

        public Brush ForegroundInactive
        {
            get => (Brush)GetValue(ForegroundInactiveProperty);
            set => SetValue(ForegroundInactiveProperty, value);
        }

        public Brush HeaderBackground
        {
            get => (Brush)GetValue(HeaderBackgroundProperty);
            set => SetValue(HeaderBackgroundProperty, value);
        }

        public Brush HeaderBorderBrush
        {
            get => (Brush)GetValue(HeaderBorderBrushProperty);
            set => SetValue(HeaderBorderBrushProperty, value);
        }

        public Thickness HeaderBorderThickness
        {
            get => (Thickness)GetValue(HeaderBorderThicknessProperty);
            set => SetValue(HeaderBorderThicknessProperty, value);
        }

        #region HeaderNavigationButton

        public Brush HeaderNavigationButtonBackground
        {
            get => (Brush)GetValue(HeaderNavigationButtonBackgroundProperty);
            set => SetValue(HeaderNavigationButtonBackgroundProperty, value);
        }

        public Brush HeaderNavigationButtonBackgroundInactive
        {
            get => (Brush)GetValue(HeaderNavigationButtonBackgroundInactiveProperty);
            set => SetValue(HeaderNavigationButtonBackgroundInactiveProperty, value);
        }

        public Brush HeaderNavigationButtonBackgroundMouseOver
        {
            get => (Brush)GetValue(HeaderNavigationButtonBackgroundMouseOverProperty);
            set => SetValue(HeaderNavigationButtonBackgroundMouseOverProperty, value);
        }

        public Brush HeaderNavigationButtonBackgroundPressed
        {
            get => (Brush)GetValue(HeaderNavigationButtonBackgroundPressedProperty);
            set => SetValue(HeaderNavigationButtonBackgroundPressedProperty, value);
        }

        public Brush HeaderNavigationButtonBorderBrush
        {
            get => (Brush)GetValue(HeaderNavigationButtonBorderBrushProperty);
            set => SetValue(HeaderNavigationButtonBorderBrushProperty, value);
        }

        public Brush HeaderNavigationButtonBorderBrushInactive
        {
            get => (Brush)GetValue(HeaderNavigationButtonBorderBrushInactiveProperty);
            set => SetValue(HeaderNavigationButtonBorderBrushInactiveProperty, value);
        }

        public Brush HeaderNavigationButtonBorderBrushMouseOver
        {
            get => (Brush)GetValue(HeaderNavigationButtonBorderBrushMouseOverProperty);
            set => SetValue(HeaderNavigationButtonBorderBrushMouseOverProperty, value);
        }

        public Brush HeaderNavigationButtonBorderBrushPressed
        {
            get => (Brush)GetValue(HeaderNavigationButtonBorderBrushPressedProperty);
            set => SetValue(HeaderNavigationButtonBorderBrushPressedProperty, value);
        }

        public Thickness HeaderNavigationButtonBorderThickness
        {
            get => (Thickness)GetValue(HeaderNavigationButtonBorderThicknessProperty);
            set => SetValue(HeaderNavigationButtonBorderThicknessProperty, value);
        }

        public CornerRadius HeaderNavigationButtonCornerRadius
        {
            get => (CornerRadius)GetValue(HeaderNavigationButtonCornerRadiusProperty);
            set => SetValue(HeaderNavigationButtonCornerRadiusProperty, value);
        }

        public Brush HeaderNavigationButtonForeground
        {
            get => (Brush)GetValue(HeaderNavigationButtonForegroundProperty);
            set => SetValue(HeaderNavigationButtonForegroundProperty, value);
        }

        public Brush HeaderNavigationButtonForegroundInactive
        {
            get => (Brush)GetValue(HeaderNavigationButtonForegroundInactiveProperty);
            set => SetValue(HeaderNavigationButtonForegroundInactiveProperty, value);
        }

        public Brush HeaderNavigationButtonForegroundMouseOver
        {
            get => (Brush)GetValue(HeaderNavigationButtonForegroundMouseOverProperty);
            set => SetValue(HeaderNavigationButtonForegroundMouseOverProperty, value);
        }

        public Brush HeaderNavigationButtonForegroundPressed
        {
            get => (Brush)GetValue(HeaderNavigationButtonForegroundPressedProperty);
            set => SetValue(HeaderNavigationButtonForegroundPressedProperty, value);
        }

        public double HeaderNavigationButtonIconHeight
        {
            get => (double)GetValue(HeaderNavigationButtonIconHeightProperty);
            set => SetValue(HeaderNavigationButtonIconHeightProperty, value);
        }

        public double HeaderNavigationButtonIconWidth
        {
            get => (double)GetValue(HeaderNavigationButtonIconWidthProperty);
            set => SetValue(HeaderNavigationButtonIconWidthProperty, value);
        }

        public Thickness HeaderNavigationButtonMargin
        {
            get => (Thickness)GetValue(HeaderNavigationButtonMarginProperty);
            set => SetValue(HeaderNavigationButtonMarginProperty, value);
        }

        public Thickness HeaderNavigationButtonPadding
        {
            get => (Thickness)GetValue(HeaderNavigationButtonPaddingProperty);
            set => SetValue(HeaderNavigationButtonPaddingProperty, value);
        }

        public HorizontalAlignment HeaderNavigationButtonPosition
        {
            get => (HorizontalAlignment)GetValue(HeaderNavigationButtonPositionProperty);
            set => SetValue(HeaderNavigationButtonPositionProperty, value);
        }

        #endregion HeaderNavigationButton

        public Thickness HeaderPadding
        {
            get => (Thickness)GetValue(HeaderPaddingProperty);
            set => SetValue(HeaderPaddingProperty, value);
        }

        public CalendarExHeaderPosition CalendarExHeaderPosition
        {
            get => (CalendarExHeaderPosition)GetValue(CalendarExHeaderPositionProperty);
            set => SetValue(CalendarExHeaderPositionProperty, value);
        }

        #region HeaderTitleButton

        public Brush HeaderTitleButtonBackground
        {
            get => (Brush)GetValue(HeaderTitleButtonBackgroundProperty);
            set => SetValue(HeaderTitleButtonBackgroundProperty, value);
        }

        public Brush HeaderTitleButtonBackgroundInactive
        {
            get => (Brush)GetValue(HeaderTitleButtonBackgroundInactiveProperty);
            set => SetValue(HeaderTitleButtonBackgroundInactiveProperty, value);
        }

        public Brush HeaderTitleButtonBackgroundMouseOver
        {
            get => (Brush)GetValue(HeaderTitleButtonBackgroundMouseOverProperty);
            set => SetValue(HeaderTitleButtonBackgroundMouseOverProperty, value);
        }

        public Brush HeaderTitleButtonBackgroundPressed
        {
            get => (Brush)GetValue(HeaderTitleButtonBackgroundPressedProperty);
            set => SetValue(HeaderTitleButtonBackgroundPressedProperty, value);
        }

        public Brush HeaderTitleButtonBorderBrush
        {
            get => (Brush)GetValue(HeaderTitleButtonBorderBrushProperty);
            set => SetValue(HeaderTitleButtonBorderBrushProperty, value);
        }

        public Brush HeaderTitleButtonBorderBrushInactive
        {
            get => (Brush)GetValue(HeaderTitleButtonBorderBrushInactiveProperty);
            set => SetValue(HeaderTitleButtonBorderBrushInactiveProperty, value);
        }

        public Brush HeaderTitleButtonBorderBrushMouseOver
        {
            get => (Brush)GetValue(HeaderTitleButtonBorderBrushMouseOverProperty);
            set => SetValue(HeaderTitleButtonBorderBrushMouseOverProperty, value);
        }

        public Brush HeaderTitleButtonBorderBrushPressed
        {
            get => (Brush)GetValue(HeaderTitleButtonBorderBrushPressedProperty);
            set => SetValue(HeaderTitleButtonBorderBrushPressedProperty, value);
        }

        public Thickness HeaderTitleButtonBorderThickness
        {
            get => (Thickness)GetValue(HeaderTitleButtonBorderThicknessProperty);
            set => SetValue(HeaderTitleButtonBorderThicknessProperty, value);
        }

        public Brush HeaderTitleButtonForeground
        {
            get => (Brush)GetValue(HeaderTitleButtonForegroundProperty);
            set => SetValue(HeaderTitleButtonForegroundProperty, value);
        }

        public Brush HeaderTitleButtonForegroundInactive
        {
            get => (Brush)GetValue(HeaderTitleButtonForegroundInactiveProperty);
            set => SetValue(HeaderTitleButtonForegroundInactiveProperty, value);
        }

        public Brush HeaderTitleButtonForegroundMouseOver
        {
            get => (Brush)GetValue(HeaderTitleButtonForegroundMouseOverProperty);
            set => SetValue(HeaderTitleButtonForegroundMouseOverProperty, value);
        }

        public Brush HeaderTitleButtonForegroundPressed
        {
            get => (Brush)GetValue(HeaderTitleButtonForegroundPressedProperty);
            set => SetValue(HeaderTitleButtonForegroundPressedProperty, value);
        }

        public CornerRadius HeaderTitleButtonCornerRadius
        {
            get => (CornerRadius)GetValue(HeaderTitleButtonCornerRadiusProperty);
            set => SetValue(HeaderTitleButtonCornerRadiusProperty, value);
        }

        public Thickness HeaderTitleButtonMargin
        {
            get => (Thickness)GetValue(HeaderTitleButtonMarginProperty);
            set => SetValue(HeaderTitleButtonMarginProperty, value);
        }

        public Thickness HeaderTitleButtonPadding
        {
            get => (Thickness)GetValue(HeaderTitleButtonPaddingProperty);
            set => SetValue(HeaderTitleButtonPaddingProperty, value);
        }

        #endregion HeaderTitleButton

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> CalendarEx class constructor. </summary>
        static CalendarEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CalendarEx),
                new FrameworkPropertyMetadata(typeof(CalendarEx)));
        }

        #endregion CONSTRUCTORS

    }
}
