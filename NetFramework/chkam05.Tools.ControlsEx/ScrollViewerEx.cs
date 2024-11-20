using chkam05.Tools.ControlsEx.Resources;
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
    public class ScrollViewerEx : ScrollViewer
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty CornerBackgroundProperty = DependencyProperty.Register(
            nameof(CornerBackground),
            typeof(Brush),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightBackground)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ScrollViewerEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static DependencyProperty HorizontalScrollBarHeightProperty = DependencyProperty.Register(
            nameof(HorizontalScrollBarHeight),
            typeof(double),
            typeof(ScrollViewerEx),
            new PropertyMetadata(12d));

        public static DependencyProperty HorizontalScrollBarStyleProperty = DependencyProperty.Register(
            nameof(HorizontalScrollBarStyle),
            typeof(Style),
            typeof(ScrollViewerEx),
            new PropertyMetadata(GetGenericScrollBarExStyle()));

        public static DependencyProperty VerticalScrollBarWidthProperty = DependencyProperty.Register(
            nameof(VerticalScrollBarWidth),
            typeof(double),
            typeof(ScrollViewerEx),
            new PropertyMetadata(12d));

        public static DependencyProperty VerticalScrollBarStyleProperty = DependencyProperty.Register(
            nameof(VerticalScrollBarStyle),
            typeof(Style),
            typeof(ScrollViewerEx),
            new PropertyMetadata(GetGenericScrollBarExStyle()));


        //  GETTERS & SETTERS

        public Brush CornerBackground
        {
            get => (Brush)GetValue(CornerBackgroundProperty);
            set => SetValue(CornerBackgroundProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public double HorizontalScrollBarHeight
        {
            get => (double)GetValue(HorizontalScrollBarHeightProperty);
            set => SetValue(HorizontalScrollBarHeightProperty, value);
        }

        public Style HorizontalScrollBarStyle
        {
            get => (Style)GetValue(HorizontalScrollBarStyleProperty);
            set => SetValue(HorizontalScrollBarStyleProperty, value);
        }

        public double VerticalScrollBarWidth
        {
            get => (double)GetValue(VerticalScrollBarWidthProperty);
            set => SetValue(VerticalScrollBarWidthProperty, value);
        }

        public Style VerticalScrollBarStyle
        {
            get => (Style)GetValue(VerticalScrollBarStyleProperty);
            set => SetValue(VerticalScrollBarStyleProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ScrollViewerEx class constructor. </summary>
        static ScrollViewerEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ScrollViewerEx),
                new FrameworkPropertyMetadata(typeof(ScrollViewerEx)));
        }

        #endregion CONSTRUCTORS

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic ScrollBarEx style from resources. </summary>
        /// <returns> ScrollBarEx style. </returns>
        protected static Style GetGenericScrollBarExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ScrollBarEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ScrollBarEx.ScrollBarExStyle"] as Style;
        }

        #endregion STYLES

    }
}
