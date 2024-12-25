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
    public class SliderEx : Slider
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(SliderEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty HorizontalThumbHeightProperty = DependencyProperty.Register(
            nameof(HorizontalThumbHeight),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(18d));

        public static readonly DependencyProperty HorizontalThumbStyleProperty = DependencyProperty.Register(
            nameof(HorizontalThumbStyle),
            typeof(Style),
            typeof(SliderEx),
            new PropertyMetadata(GetGenericHorizontalThumbExStyle()));

        public static readonly DependencyProperty HorizontalThumbWidthProperty = DependencyProperty.Register(
            nameof(HorizontalThumbWidth),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(11d));

        public static readonly DependencyProperty HorizontalTrackBarHeightProperty = DependencyProperty.Register(
            nameof(HorizontalTrackBarHeight),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(5d));

        public static readonly DependencyProperty HorizontalTrackBarMarginProperty = DependencyProperty.Register(
            nameof(HorizontalTrackBarMargin),
            typeof(Thickness),
            typeof(SliderEx),
            new PropertyMetadata(new Thickness(5, 2, 5, 2)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(0.56d));

        public static readonly DependencyProperty SelectionRangeBackgroundProperty = DependencyProperty.Register(
            nameof(SelectionRangeBackground),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColor)));

        public static readonly DependencyProperty TickSizeProperty = DependencyProperty.Register(
            nameof(TickSize),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(4d));

        public static readonly DependencyProperty TrackBarBackgroundProperty = DependencyProperty.Register(
            nameof(TrackBarBackground),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty TrackBarBorderBrushProperty = DependencyProperty.Register(
            nameof(TrackBarBorderBrush),
            typeof(Brush),
            typeof(SliderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty TrackBarBorderThicknessProperty = DependencyProperty.Register(
            nameof(TrackBarBorderThickness),
            typeof(Thickness),
            typeof(SliderEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty TrackBarCornerRadiusProperty = DependencyProperty.Register(
            nameof(TrackBarCornerRadius),
            typeof(CornerRadius),
            typeof(SliderEx),
            new PropertyMetadata(new CornerRadius(2)));

        public static readonly DependencyProperty VerticalThumbHeightProperty = DependencyProperty.Register(
            nameof(VerticalThumbHeight),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(11d));

        public static readonly DependencyProperty VerticalThumbStyleProperty = DependencyProperty.Register(
            nameof(VerticalThumbStyle),
            typeof(Style),
            typeof(SliderEx),
            new PropertyMetadata(GetGenericVerticalThumbExStyle()));

        public static readonly DependencyProperty VerticalThumbWidthProperty = DependencyProperty.Register(
            nameof(VerticalThumbWidth),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(18d));

        public static readonly DependencyProperty VerticalTrackBarMarginProperty = DependencyProperty.Register(
            nameof(VerticalTrackBarMargin),
            typeof(Thickness),
            typeof(SliderEx),
            new PropertyMetadata(new Thickness(2, 5, 2, 5)));

        public static readonly DependencyProperty VerticalTrackBarWidthProperty = DependencyProperty.Register(
            nameof(VerticalTrackBarWidth),
            typeof(double),
            typeof(SliderEx),
            new PropertyMetadata(5d));


        //  GETTERS & SETTERS

        public Brush BorderBrushMouseOver
        {
            get => (Brush)GetValue(BorderBrushMouseOverProperty);
            set => SetValue(BorderBrushMouseOverProperty, value);
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

        public double HorizontalThumbHeight
        {
            get => (double)GetValue(HorizontalThumbHeightProperty);
            set => SetValue(HorizontalThumbHeightProperty, value);
        }

        public Style HorizontalThumbStyle
        {
            get => (Style)GetValue(HorizontalThumbStyleProperty);
            set => SetValue(HorizontalThumbStyleProperty, value);
        }

        public double HorizontalThumbWidth
        {
            get => (double)GetValue(HorizontalThumbWidthProperty);
            set => SetValue(HorizontalThumbWidthProperty, value);
        }

        public double HorizontalTrackBarHeight
        {
            get => (double)GetValue(HorizontalTrackBarHeightProperty);
            set => SetValue(HorizontalTrackBarHeightProperty, value);
        }

        public Thickness HorizontalTrackBarMargin
        {
            get => (Thickness)GetValue(HorizontalTrackBarMarginProperty);
            set => SetValue(HorizontalTrackBarMarginProperty, value);
        }

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }

        public Brush SelectionRangeBackground
        {
            get => (Brush)GetValue(SelectionRangeBackgroundProperty);
            set => SetValue(SelectionRangeBackgroundProperty, value);
        }

        public double TickSize
        {
            get => (double)GetValue(TickSizeProperty);
            set => SetValue(TickSizeProperty, value);
        }

        public Brush TrackBarBackground
        {
            get => (Brush)GetValue(TrackBarBackgroundProperty);
            set => SetValue(TrackBarBackgroundProperty, value);
        }

        public Brush TrackBarBorderBrush
        {
            get => (Brush)GetValue(TrackBarBorderBrushProperty);
            set => SetValue(TrackBarBorderBrushProperty, value);
        }

        public Thickness TrackBarBorderThickness
        {
            get => (Thickness)GetValue(TrackBarBorderThicknessProperty);
            set => SetValue(TrackBarBorderThicknessProperty, value);
        }

        public CornerRadius TrackBarCornerRadius
        {
            get => (CornerRadius)GetValue(TrackBarCornerRadiusProperty);
            set => SetValue(TrackBarCornerRadiusProperty, value);
        }

        public double VerticalThumbHeight
        {
            get => (double)GetValue(VerticalThumbHeightProperty);
            set => SetValue(VerticalThumbHeightProperty, value);
        }

        public Style VerticalThumbStyle
        {
            get => (Style)GetValue(VerticalThumbStyleProperty);
            set => SetValue(VerticalThumbStyleProperty, value);
        }

        public double VerticalThumbWidth
        {
            get => (double)GetValue(VerticalThumbWidthProperty);
            set => SetValue(VerticalThumbWidthProperty, value);
        }

        public Thickness VerticalTrackBarMargin
        {
            get => (Thickness)GetValue(VerticalTrackBarMarginProperty);
            set => SetValue(VerticalTrackBarMarginProperty, value);
        }

        public double VerticalTrackBarWidth
        {
            get => (double)GetValue(VerticalTrackBarWidthProperty);
            set => SetValue(VerticalTrackBarWidthProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> SliderEx class constructor. </summary>
        static SliderEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SliderEx),
                new FrameworkPropertyMetadata(typeof(SliderEx)));
        }

        #endregion CONSTRUCTORS

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic horizontal GeometryThumbEx style from resources. </summary>
        /// <returns> GeometryThumbEx style. </returns>
        protected static Style GetGenericHorizontalThumbExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/SliderEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["SliderEx.Horizontal.ThumbExStyle"] as Style;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic vertical GeometryThumbEx style from resources. </summary>
        /// <returns> GeometryThumbEx style. </returns>
        protected static Style GetGenericVerticalThumbExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/SliderEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["SliderEx.Vertical.ThumbExStyle"] as Style;
        }

        #endregion STYLES

    }
}
