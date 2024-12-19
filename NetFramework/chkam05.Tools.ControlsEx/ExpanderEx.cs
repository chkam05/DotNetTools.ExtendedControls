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
    public class ExpanderEx : Expander
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ExpanderEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty HeaderBackgroundProperty = DependencyProperty.Register(
            nameof(HeaderBackground),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty HeaderBackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(HeaderBackgroundMouseOver),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty HeaderBackgroundPressedProperty = DependencyProperty.Register(
            nameof(HeaderBackgroundPressed),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty HeaderBorderBrushProperty = DependencyProperty.Register(
            nameof(HeaderBorderBrush),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty HeaderBorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(HeaderBorderBrushMouseOver),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty HeaderBorderBrushPressedProperty = DependencyProperty.Register(
            nameof(HeaderBorderBrushPressed),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty HeaderBorderThicknessProperty = DependencyProperty.Register(
            nameof(HeaderBorderThickness),
            typeof(Thickness),
            typeof(ExpanderEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty HeaderForegroundProperty = DependencyProperty.Register(
            nameof(HeaderForeground),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty HeaderForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(HeaderForegroundMouseOver),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty HeaderForegroundPressedProperty = DependencyProperty.Register(
            nameof(HeaderForegroundPressed),
            typeof(Brush),
            typeof(ExpanderEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty HeaderIconHeightProperty = DependencyProperty.Register(
            nameof(HeaderIconHeight),
            typeof(double),
            typeof(ExpanderEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty HeaderIconWidthProperty = DependencyProperty.Register(
            nameof(HeaderIconWidth),
            typeof(double),
            typeof(ExpanderEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty HeaderPaddingProperty = DependencyProperty.Register(
            nameof(HeaderPadding),
            typeof(Thickness),
            typeof(ExpanderEx),
            new PropertyMetadata(new Thickness(4)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(ExpanderEx),
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

        public Brush HeaderBackgroundMouseOver
        {
            get => (Brush)GetValue(HeaderBackgroundMouseOverProperty);
            set => SetValue(HeaderBackgroundMouseOverProperty, value);
        }

        public Brush HeaderBackgroundPressed
        {
            get => (Brush)GetValue(HeaderBackgroundPressedProperty);
            set => SetValue(HeaderBackgroundPressedProperty, value);
        }

        public Brush HeaderBorderBrush
        {
            get => (Brush)GetValue(HeaderBorderBrushProperty);
            set => SetValue(HeaderBorderBrushProperty, value);
        }

        public Brush HeaderBorderBrushMouseOver
        {
            get => (Brush)GetValue(HeaderBorderBrushMouseOverProperty);
            set => SetValue(HeaderBorderBrushMouseOverProperty, value);
        }

        public Brush HeaderBorderBrushPressed
        {
            get => (Brush)GetValue(HeaderBorderBrushPressedProperty);
            set => SetValue(HeaderBorderBrushPressedProperty, value);
        }

        public Thickness HeaderBorderThickness
        {
            get => (Thickness)GetValue(HeaderBorderThicknessProperty);
            set => SetValue(HeaderBorderThicknessProperty, value);
        }

        public Brush HeaderForeground
        {
            get => (Brush)GetValue(HeaderForegroundProperty);
            set => SetValue(HeaderForegroundProperty, value);
        }

        public Brush HeaderForegroundMouseOver
        {
            get => (Brush)GetValue(HeaderForegroundMouseOverProperty);
            set => SetValue(HeaderForegroundMouseOverProperty, value);
        }

        public Brush HeaderForegroundPressed
        {
            get => (Brush)GetValue(HeaderForegroundPressedProperty);
            set => SetValue(HeaderForegroundPressedProperty, value);
        }

        public double HeaderIconHeight
        {
            get => (double)GetValue(HeaderIconHeightProperty);
            set => SetValue(HeaderIconHeightProperty, value);
        }

        public double HeaderIconWidth
        {
            get => (double)GetValue(HeaderIconWidthProperty);
            set => SetValue(HeaderIconWidthProperty, value);
        }

        public Thickness HeaderPadding
        {
            get => (Thickness)GetValue(HeaderPaddingProperty);
            set => SetValue(HeaderPaddingProperty, value);
        }

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ExpanderEx class constructor. </summary>
        static ExpanderEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExpanderEx),
                new FrameworkPropertyMetadata(typeof(ExpanderEx)));
        }

        #endregion CONSTRUCTORS

    }
}
