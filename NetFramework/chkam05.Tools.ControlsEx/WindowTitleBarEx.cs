using chkam05.Tools.ControlsEx.Data;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using MaterialDesignThemes.Wpf;
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
    public class WindowTitleBarEx : Control
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonCloseVisibilityProperty = DependencyProperty.Register(
            nameof(ButtonCloseVisibility),
            typeof(Visibility),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty ButtonMaximizeVisibilityProperty = DependencyProperty.Register(
            nameof(ButtonMaximizeVisibility),
            typeof(Visibility),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty ButtonMinimizeVisibilityProperty = DependencyProperty.Register(
            nameof(ButtonMinimizeVisibility),
            typeof(Visibility),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(Visibility.Visible));

        public static readonly DependencyProperty ButtonsMarginProperty = DependencyProperty.Register(
            nameof(ButtonsMargin),
            typeof(Thickness),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(new Thickness(4,0,0,0)));

        public static readonly DependencyProperty ButtonsPositionProperty = DependencyProperty.Register(
            nameof(ButtonsPosition),
            typeof(TitleBarButtonPosition),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(TitleBarButtonPosition.Right));

        public static readonly DependencyProperty ButtonsStyleProperty = DependencyProperty.Register(
            nameof(ButtonsStyle),
            typeof(Style),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(GetGenericButtonExWithIconStyle()));

        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
            nameof(Content),
            typeof(object),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(null));

        public static readonly DependencyProperty ContentPaddingProperty = DependencyProperty.Register(
            nameof(ContentPadding),
            typeof(Thickness),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(new Thickness(4, 0, 4, 0)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(new CornerRadius(4,4,0,0)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
            nameof(Icon),
            typeof(ImageSource),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(null));

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind),
            typeof(PackIconKind),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(PackIconKind.Application));

        public static readonly DependencyProperty IconPaddingProperty = DependencyProperty.Register(
            nameof(IconPadding),
            typeof(Thickness),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(new Thickness(4)));

        public static readonly DependencyProperty IconPositionProperty = DependencyProperty.Register(
            nameof(IconPosition),
            typeof(TitleBarIconPosition),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(TitleBarIconPosition.Left));

        public static readonly DependencyProperty IconSnapToContentProperty = DependencyProperty.Register(
            nameof(IconSnapToContent),
            typeof(bool),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(WindowTitleBarEx),
            new PropertyMetadata(0.56d));


        //  EVENTS

        public event RoutedEventHandler CloseButtonClick;
        public event RoutedEventHandler MaximizeButtonClick;
        public event RoutedEventHandler MinimizeButtonClick;


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

        public Visibility ButtonCloseVisibility
        {
            get => (Visibility)GetValue(ButtonCloseVisibilityProperty);
            set => SetValue(ButtonCloseVisibilityProperty, value);
        }

        public Visibility ButtonMaximizeVisibility
        {
            get => (Visibility)GetValue(ButtonMaximizeVisibilityProperty);
            set => SetValue(ButtonMaximizeVisibilityProperty, value);
        }

        public Visibility ButtonMinimizeVisibility
        {
            get => (Visibility)GetValue(ButtonMinimizeVisibilityProperty);
            set => SetValue(ButtonMinimizeVisibilityProperty, value);
        }

        public Thickness ButtonsMargin
        {
            get => (Thickness)GetValue(ButtonsMarginProperty);
            set => SetValue(ButtonsMarginProperty, value);
        }

        public TitleBarButtonPosition ButtonsPosition
        {
            get => (TitleBarButtonPosition)GetValue(ButtonsPositionProperty);
            set => SetValue(ButtonsPositionProperty, value);
        }

        public Style ButtonsStyle
        {
            get => (Style)GetValue(ButtonsStyleProperty);
            set => SetValue(ButtonsStyleProperty, value);
        }

        public object Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
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

        public Brush ForegroundInactive
        {
            get => (Brush)GetValue(ForegroundInactiveProperty);
            set => SetValue(ForegroundInactiveProperty, value);
        }

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public PackIconKind IconKind
        {
            get => (PackIconKind)GetValue(IconKindProperty);
            set => SetValue(IconKindProperty, value);
        }

        public Thickness IconPadding
        {
            get => (Thickness)GetValue(IconPaddingProperty);
            set => SetValue(IconPaddingProperty, value);
        }

        public TitleBarIconPosition IconPosition
        {
            get => (TitleBarIconPosition)GetValue(IconPositionProperty);
            set => SetValue(IconPositionProperty, value);
        }

        public bool IconSnapToContent
        {
            get => (bool)GetValue(IconSnapToContentProperty);
            set => SetValue(IconSnapToContentProperty, value);
        }

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> WindowTitleBarEx class constructor. </summary>
        static WindowTitleBarEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowTitleBarEx),
                new FrameworkPropertyMetadata(typeof(WindowTitleBarEx)));
        }

        #endregion CONSTRUCTORS

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            var closeButton = GetTemplateChild("closeButton") as ButtonExWithIcon;
            var maximizeButton = GetTemplateChild("maximizeButton") as ButtonExWithIcon;
            var minimizeButton = GetTemplateChild("minimizeButton") as ButtonExWithIcon;

            closeButton.Click += CloseButtonClick;
            maximizeButton.Click += MaximizeButtonClick;
            minimizeButton.Click += MinimizeButtonClick;
        }

        #endregion TEMPLATE

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic ButtonExWithIcon style from resources. </summary>
        /// <returns> ButtonExWithIcon style. </returns>
        protected static Style GetGenericButtonExWithIconStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/WindowTitleBarEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["WindowTitleBarEx.ButtonExWithIconStyle"] as Style;
        }

        #endregion STYLES

    }
}
