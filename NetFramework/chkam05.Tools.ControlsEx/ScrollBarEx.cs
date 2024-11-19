using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx
{
    public class ScrollBarEx : ScrollBar
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightBackground)));

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightBackground)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightBackground)));

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ButtonBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonBackground),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColor)));

        public static readonly DependencyProperty ButtonBackgroundInactiveProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundInactive),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonBackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundMouseOver),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ButtonBackgroundPressedProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundPressed),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ButtonBorderBrushProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrush),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColor)));

        public static readonly DependencyProperty ButtonBorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrushInactive),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonBorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrushMouseOver),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ButtonBorderBrushPressedProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrushPressed),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty ButtonBorderThicknessProperty = DependencyProperty.Register(
            nameof(ButtonBorderThickness),
            typeof(Thickness),
            typeof(ScrollBarEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty ButtonCornerRadiusProperty = DependencyProperty.Register(
            nameof(ButtonCornerRadius),
            typeof(CornerRadius),
            typeof(ScrollBarEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ButtonHorizontalWidthProperty = DependencyProperty.Register(
            nameof(ButtonHorizontalWidth),
            typeof(double),
            typeof(ScrollBarEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty ButtonMarginProperty = DependencyProperty.Register(
            nameof(ButtonMargin),
            typeof(Thickness),
            typeof(ScrollBarEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty ButtonVerticalHeightProperty = DependencyProperty.Register(
            nameof(ButtonVerticalHeight),
            typeof(double),
            typeof(ScrollBarEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ScrollBarEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundPressedProperty = DependencyProperty.Register(
            nameof(ForegroundPressed),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(ScrollBarEx),
            new PropertyMetadata(0.56d));

        public static readonly DependencyProperty StyleButtonProperty = DependencyProperty.Register(
            nameof(StyleButton),
            typeof(Style),
            typeof(ScrollBarEx),
            new PropertyMetadata(GetGenericStyleRepeatButton()));

        public static readonly DependencyProperty StyleThumbHorizontalProperty = DependencyProperty.Register(
            nameof(StyleThumbHorizontal),
            typeof(Style),
            typeof(ScrollBarEx),
            new PropertyMetadata(GetGenericStyleThumbHorizontal()));

        public static readonly DependencyProperty StyleThumbVerticalProperty = DependencyProperty.Register(
            nameof(StyleThumbVertical),
            typeof(Style),
            typeof(ScrollBarEx),
            new PropertyMetadata(GetGenericStyleThumbVertical()));

        public static readonly DependencyProperty ThumbBackgroundProperty = DependencyProperty.Register(
            nameof(ThumbBackground),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColor)));

        public static readonly DependencyProperty ThumbBackgroundDraggingProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundDragging),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty ThumbBackgroundInactiveProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundInactive),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ThumbBackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(ThumbBackgroundMouseOver),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ThumbBorderBrushProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrush),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColor)));

        public static readonly DependencyProperty ThumbBorderBrushDraggingProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrushDragging),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty ThumbBorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrushInactive),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ThumbBorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(ThumbBorderBrushMouseOver),
            typeof(Brush),
            typeof(ScrollBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ThumbBorderThicknessProperty = DependencyProperty.Register(
            nameof(ThumbBorderThickness),
            typeof(Thickness),
            typeof(ScrollBarEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty ThumbCornerRadiusProperty = DependencyProperty.Register(
            nameof(ThumbCornerRadius),
            typeof(CornerRadius),
            typeof(ScrollBarEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ThumbMarginProperty = DependencyProperty.Register(
            nameof(ThumbMargin),
            typeof(Thickness),
            typeof(ScrollBarEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty UseSystemDimensionsProperty = DependencyProperty.Register(
            nameof(UseSystemDimensions),
            typeof(bool),
            typeof(ScrollBarEx),
            new PropertyMetadata(false));


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

        public Brush ButtonBorderBrush
        {
            get => (Brush)GetValue(ButtonBorderBrushProperty);
            set => SetValue(ButtonBorderBrushProperty, value);
        }

        public Brush ButtonBorderBrushInactive
        {
            get => (Brush)GetValue(ButtonBorderBrushInactiveProperty);
            set => SetValue(ButtonBorderBrushInactiveProperty, value);
        }

        public Brush ButtonBorderBrushMouseOver
        {
            get => (Brush)GetValue(ButtonBorderBrushMouseOverProperty);
            set => SetValue(ButtonBorderBrushMouseOverProperty, value);
        }

        public Brush ButtonBorderBrushPressed
        {
            get => (Brush)GetValue(ButtonBorderBrushPressedProperty);
            set => SetValue(ButtonBorderBrushPressedProperty, value);
        }

        public Thickness ButtonBorderThickness
        {
            get => (Thickness)GetValue(ButtonBorderThicknessProperty);
            set => SetValue(ButtonBorderThicknessProperty, value);
        }

        public CornerRadius ButtonCornerRadius
        {
            get => (CornerRadius)GetValue(ButtonCornerRadiusProperty);
            set => SetValue(ButtonCornerRadiusProperty, value);
        }

        public double ButtonHorizontalWidth
        {
            get => (double)GetValue(ButtonHorizontalWidthProperty);
            set => SetValue(ButtonHorizontalWidthProperty, Math.Max(0, value));
        }

        public Thickness ButtonMargin
        {
            get => (Thickness)GetValue(ButtonMarginProperty);
            set => SetValue(ButtonMarginProperty, value);
        }

        public double ButtonVerticalHeight
        {
            get => (double)GetValue(ButtonVerticalHeightProperty);
            set => SetValue(ButtonVerticalHeightProperty, Math.Max(0, value));
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

        public Brush ForegroundPressed
        {
            get => (Brush)GetValue(ForegroundPressedProperty);
            set => SetValue(ForegroundPressedProperty, value);
        }

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }

        public Style StyleButton
        {
            get => (Style)GetValue(StyleButtonProperty);
            set => SetValue(StyleButtonProperty, value);
        }

        public Style StyleThumbHorizontal
        {
            get => (Style)GetValue(StyleThumbHorizontalProperty);
            set => SetValue(StyleThumbHorizontalProperty, value);
        }
        
        public Style StyleThumbVertical
        {
            get => (Style)GetValue(StyleThumbVerticalProperty);
            set => SetValue(StyleThumbVerticalProperty, value);
        }

        public Brush ThumbBackground
        {
            get => (Brush)GetValue(ThumbBackgroundProperty);
            set => SetValue(ThumbBackgroundProperty, value);
        }

        public Brush ThumbBackgroundDragging
        {
            get => (Brush)GetValue(ThumbBackgroundDraggingProperty);
            set => SetValue(ThumbBackgroundDraggingProperty, value);
        }

        public Brush ThumbBackgroundInactive
        {
            get => (Brush)GetValue(ThumbBackgroundInactiveProperty);
            set => SetValue(ThumbBackgroundInactiveProperty, value);
        }

        public Brush ThumbBackgroundMouseOver
        {
            get => (Brush)GetValue(ThumbBackgroundMouseOverProperty);
            set => SetValue(ThumbBackgroundMouseOverProperty, value);
        }

        public Brush ThumbBorderBrush
        {
            get => (Brush)GetValue(ThumbBorderBrushProperty);
            set => SetValue(ThumbBorderBrushProperty, value);
        }

        public Brush ThumbBorderBrushDragging
        {
            get => (Brush)GetValue(ThumbBorderBrushDraggingProperty);
            set => SetValue(ThumbBorderBrushDraggingProperty, value);
        }

        public Brush ThumbBorderBrushInactive
        {
            get => (Brush)GetValue(ThumbBorderBrushInactiveProperty);
            set => SetValue(ThumbBorderBrushInactiveProperty, value);
        }

        public Brush ThumbBorderBrushMouseOver
        {
            get => (Brush)GetValue(ThumbBorderBrushMouseOverProperty);
            set => SetValue(ThumbBorderBrushMouseOverProperty, value);
        }

        public Thickness ThumbBorderThickness
        {
            get => (Thickness)GetValue(ThumbBorderThicknessProperty);
            set => SetValue(ThumbBorderThicknessProperty, value);
        }

        public CornerRadius ThumbCornerRadius
        {
            get => (CornerRadius)GetValue(ThumbCornerRadiusProperty);
            set => SetValue(ThumbCornerRadiusProperty, value);
        }

        public Thickness ThumbMargin
        {
            get => (Thickness)GetValue(ThumbMarginProperty);
            set => SetValue(ThumbMarginProperty, value);
        }

        public bool UseSystemDimensions
        {
            get => (bool)GetValue(UseSystemDimensionsProperty);
            set => SetValue(UseSystemDimensionsProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ScrollBarEx class constructor. </summary>
        static ScrollBarEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScrollBarEx),
                new FrameworkPropertyMetadata(typeof(ScrollBarEx)));
        }

        #endregion CONSTRUCTORS

        #region STYLES

        protected static Style GetGenericStyleRepeatButton()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ScrollBarEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ScrollBarEx.RepeatButtonExStyle"] as Style;
        }

        protected static Style GetGenericStyleThumbHorizontal()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ScrollBarEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ScrollBarEx.ThumbExHorizontalStyle"] as Style;
        }

        protected static Style GetGenericStyleThumbVertical()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ScrollBarEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ScrollBarEx.ThumbExVerticalStyle"] as Style;
        }

        #endregion STYLES

    }
}
