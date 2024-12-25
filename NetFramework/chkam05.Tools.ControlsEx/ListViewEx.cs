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
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx
{
    public class ListViewEx : ListView
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty ColumnHeaderBackgroundProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackground),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty ColumnHeaderBackgroundInactiveProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackgroundInactive),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty ColumnHeaderBackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackgroundMouseOver),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ColumnHeaderBackgroundPressedProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackgroundPressed),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty ColumnHeaderBorderBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderBrush),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty ColumnHeaderBorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderBrushInactive),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty ColumnHeaderBorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderBrushMouseOver),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ColumnHeaderBorderBrushPressedProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderBrushPressed),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty ColumnHeaderBorderThicknessProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderThickness),
            typeof(Thickness),
            typeof(ListViewEx),
            new PropertyMetadata(new Thickness(0, 0, 1, 1)));

        public static readonly DependencyProperty ColumnHeaderCornerRadiusProperty = DependencyProperty.Register(
            nameof(ColumnHeaderCornerRadius),
            typeof(CornerRadius),
            typeof(ListViewEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ColumnHeaderForegroundProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForeground),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty ColumnHeaderForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForegroundInactive),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty ColumnHeaderForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForegroundMouseOver),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ColumnHeaderForegroundPressedProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForegroundPressed),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ColumnHeaderMarginProperty = DependencyProperty.Register(
            nameof(ColumnHeaderMargin),
            typeof(Thickness),
            typeof(ListViewEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty ColumnHeaderPaddingProperty = DependencyProperty.Register(
            nameof(ColumnHeaderPadding),
            typeof(Thickness),
            typeof(ListViewEx),
            new PropertyMetadata(new Thickness(2, 1, 2, 1)));

        public static readonly DependencyProperty ColumnGripperBackgroundProperty = DependencyProperty.Register(
            nameof(ColumnGripperBackground),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty ColumnGripperBackgroundInactiveProperty = DependencyProperty.Register(
            nameof(ColumnGripperBackgroundInactive),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty ColumnGripperBackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(ColumnGripperBackgroundMouseOver),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty ColumnGripperBackgroundPressedProperty = DependencyProperty.Register(
            nameof(ColumnGripperBackgroundPressed),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty ColumnGripperBorderBrushProperty = DependencyProperty.Register(
            nameof(ColumnGripperBorderBrush),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightBackground)));

        public static readonly DependencyProperty ColumnGripperBorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(ColumnGripperBorderBrushInactive),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty ColumnGripperBorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(ColumnGripperBorderBrushMouseOver),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightMouseOver)));

        public static readonly DependencyProperty ColumnGripperBorderBrushPressedProperty = DependencyProperty.Register(
            nameof(ColumnGripperBorderBrushPressed),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightPressed)));

        public static readonly DependencyProperty ColumnGripperBorderThicknessProperty = DependencyProperty.Register(
            nameof(ColumnGripperBorderThickness),
            typeof(Thickness),
            typeof(ListViewEx),
            new PropertyMetadata(new Thickness(0, 0, 1, 1)));

        public static readonly DependencyProperty ColumnGripperWidthProperty = DependencyProperty.Register(
            nameof(ColumnGripperWidth),
            typeof(double),
            typeof(ListViewEx),
            new PropertyMetadata(2d));

        public static readonly DependencyProperty ColumnTextAlignmentProperty = DependencyProperty.Register(
            nameof(ColumnTextAlignment),
            typeof(TextAlignment),
            typeof(ListViewEx),
            new PropertyMetadata(TextAlignment.Left));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ListViewEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty HeaderBackgroundProperty = DependencyProperty.Register(
            nameof(HeaderBackground),
            typeof(Brush),
            typeof(ListViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(ListViewEx),
            new PropertyMetadata(0.56d));

        public static readonly DependencyProperty ScrollViewerStyleProperty = DependencyProperty.Register(
            nameof(ScrollViewerStyle),
            typeof(Style),
            typeof(ListViewEx),
            new PropertyMetadata(GetGenericScrollViewerExStyle()));


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

        public Brush ColumnHeaderBackground
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundProperty);
            set => SetValue(ColumnHeaderBackgroundProperty, value);
        }

        public Brush ColumnHeaderBackgroundInactive
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundInactiveProperty);
            set => SetValue(ColumnHeaderBackgroundInactiveProperty, value);
        }

        public Brush ColumnHeaderBackgroundMouseOver
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundMouseOverProperty);
            set => SetValue(ColumnHeaderBackgroundMouseOverProperty, value);
        }

        public Brush ColumnHeaderBackgroundPressed
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundPressedProperty);
            set => SetValue(ColumnHeaderBackgroundPressedProperty, value);
        }

        public Brush ColumnHeaderBorderBrush
        {
            get => (Brush)GetValue(ColumnHeaderBorderBrushProperty);
            set => SetValue(ColumnHeaderBorderBrushProperty, value);
        }

        public Brush ColumnHeaderBorderBrushInactive
        {
            get => (Brush)GetValue(ColumnHeaderBorderBrushInactiveProperty);
            set => SetValue(ColumnHeaderBorderBrushInactiveProperty, value);
        }

        public Brush ColumnHeaderBorderBrushMouseOver
        {
            get => (Brush)GetValue(ColumnHeaderBorderBrushMouseOverProperty);
            set => SetValue(ColumnHeaderBorderBrushMouseOverProperty, value);
        }

        public Brush ColumnHeaderBorderBrushPressed
        {
            get => (Brush)GetValue(ColumnHeaderBorderBrushPressedProperty);
            set => SetValue(ColumnHeaderBorderBrushPressedProperty, value);
        }

        public Thickness ColumnHeaderBorderThickness
        {
            get => (Thickness)GetValue(ColumnHeaderBorderThicknessProperty);
            set => SetValue(ColumnHeaderBorderThicknessProperty, value);
        }

        public CornerRadius ColumnHeaderCornerRadius
        {
            get => (CornerRadius)GetValue(ColumnHeaderCornerRadiusProperty);
            set => SetValue(ColumnHeaderCornerRadiusProperty, value);
        }

        public Brush ColumnHeaderForeground
        {
            get => (Brush)GetValue(ColumnHeaderForegroundProperty);
            set => SetValue(ColumnHeaderForegroundProperty, value);
        }

        public Brush ColumnHeaderForegroundInactive
        {
            get => (Brush)GetValue(ColumnHeaderForegroundInactiveProperty);
            set => SetValue(ColumnHeaderForegroundInactiveProperty, value);
        }

        public Brush ColumnHeaderForegroundMouseOver
        {
            get => (Brush)GetValue(ColumnHeaderForegroundMouseOverProperty);
            set => SetValue(ColumnHeaderForegroundMouseOverProperty, value);
        }

        public Brush ColumnHeaderForegroundPressed
        {
            get => (Brush)GetValue(ColumnHeaderForegroundPressedProperty);
            set => SetValue(ColumnHeaderForegroundPressedProperty, value);
        }

        public Thickness ColumnHeaderMargin
        {
            get => (Thickness)GetValue(ColumnHeaderMarginProperty);
            set => SetValue(ColumnHeaderMarginProperty, value);
        }

        public Thickness ColumnHeaderPadding
        {
            get => (Thickness)GetValue(ColumnHeaderPaddingProperty);
            set => SetValue(ColumnHeaderPaddingProperty, value);
        }

        public Brush ColumnGripperBackground
        {
            get => (Brush)GetValue(ColumnGripperBackgroundProperty);
            set => SetValue(ColumnGripperBackgroundProperty, value);
        }

        public Brush ColumnGripperBackgroundInactive
        {
            get => (Brush)GetValue(ColumnGripperBackgroundInactiveProperty);
            set => SetValue(ColumnGripperBackgroundInactiveProperty, value);
        }

        public Brush ColumnGripperBackgroundMouseOver
        {
            get => (Brush)GetValue(ColumnGripperBackgroundMouseOverProperty);
            set => SetValue(ColumnGripperBackgroundMouseOverProperty, value);
        }

        public Brush ColumnGripperBackgroundPressed
        {
            get => (Brush)GetValue(ColumnGripperBackgroundPressedProperty);
            set => SetValue(ColumnGripperBackgroundPressedProperty, value);
        }

        public Brush ColumnGripperBorderBrush
        {
            get => (Brush)GetValue(ColumnGripperBorderBrushProperty);
            set => SetValue(ColumnGripperBorderBrushProperty, value);
        }

        public Brush ColumnGripperBorderBrushInactive
        {
            get => (Brush)GetValue(ColumnGripperBorderBrushInactiveProperty);
            set => SetValue(ColumnGripperBorderBrushInactiveProperty, value);
        }

        public Brush ColumnGripperBorderBrushMouseOver
        {
            get => (Brush)GetValue(ColumnGripperBorderBrushMouseOverProperty);
            set => SetValue(ColumnGripperBorderBrushMouseOverProperty, value);
        }

        public Brush ColumnGripperBorderBrushPressed
        {
            get => (Brush)GetValue(ColumnGripperBorderBrushPressedProperty);
            set => SetValue(ColumnGripperBorderBrushPressedProperty, value);
        }

        public Thickness ColumnGripperBorderThickness
        {
            get => (Thickness)GetValue(ColumnGripperBorderThicknessProperty);
            set => SetValue(ColumnGripperBorderThicknessProperty, value);
        }

        public double ColumnGripperWidth
        {
            get => (double)GetValue(ColumnGripperWidthProperty);
            set => SetValue(ColumnGripperWidthProperty, value);
        }

        public TextAlignment ColumnTextAlignment
        {
            get => (TextAlignment)GetValue(ColumnTextAlignmentProperty);
            set => SetValue(ColumnTextAlignmentProperty, value);
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

        public Brush HeaderBackground
        {
            get => (Brush)GetValue(HeaderBackgroundProperty);
            set => SetValue(HeaderBackgroundProperty, value);
        }

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }

        public Style ScrollViewerStyle
        {
            get => (Style)GetValue(ScrollViewerStyleProperty);
            set => SetValue(ScrollViewerStyleProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ListViewEx class constructor. </summary>
        static ListViewEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListViewEx),
                new FrameworkPropertyMetadata(typeof(ListViewEx)));

            ViewProperty.OverrideMetadata(typeof(ListViewEx),
                new FrameworkPropertyMetadata(null, ViewPropertyChangedCallback));
        }

        #endregion CONSTRUCTORS

        #region ITEMS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates or identifies the element used to display the specified item. </summary>
        /// <returns> The element used to display the specified item. </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ListViewItemEx();
        }

        #endregion ITEMS

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when View property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ViewPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listViewEx = d as ListViewEx;

            if (listViewEx != null && e.NewValue is GridView gridView)
            {
                if (listViewEx.Style == null)
                {
                    var mainStyle = GetGenericGridViewExStyle();

                    if (mainStyle != null)
                        listViewEx.Style = mainStyle;
                }

                if (listViewEx.ItemContainerStyle == null)
                {
                    var itemStyle = GetGenericGridViewItemExStyle();

                    if (itemStyle != null)
                        listViewEx.ItemContainerStyle = itemStyle;
                }


                if (gridView.ColumnHeaderContainerStyle == null)
                {
                    var headerStyle = GetGenericGridViewExColumnHeaderStyle();

                    if (headerStyle != null)
                        gridView.ColumnHeaderContainerStyle = headerStyle;
                }
            }
        }

        #endregion PROPERTIES CHANGED CALLBACKS

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic GridViewEx style from resources. </summary>
        /// <returns> GridViewEx style. </returns>
        protected static Style GetGenericGridViewExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/GridViewEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["GridViewExStyle"] as Style;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic GridViewExColumnHeader style from resources. </summary>
        /// <returns> GridViewExColumnHeader style. </returns>
        protected static Style GetGenericGridViewExColumnHeaderStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/GridViewExColumnHeader.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["GridViewEx.ColumnHeaderStyle"] as Style;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic GridViewItemEx style from resources. </summary>
        /// <returns> GridViewItemEx style. </returns>
        protected static Style GetGenericGridViewItemExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/GridViewItemEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["GridViewItemExStyle"] as Style;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic ListViewEx style from resources. </summary>
        /// <returns> ListViewEx style. </returns>
        protected static Style GetGenericListViewExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ListViewEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ListViewExStyle"] as Style;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic ScrollBarEx style from resources. </summary>
        /// <returns> ScrollBarEx style. </returns>
        protected static Style GetGenericScrollViewerExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ScrollViewerEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ScrollViewerExStyle"] as Style;
        }

        #endregion STYLES

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        #endregion TEMPLATE

    }
}
