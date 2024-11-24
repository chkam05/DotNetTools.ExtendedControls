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
    public class ComboBoxEx : ComboBox
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightBackground)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ButtonBackgroundProperty = DependencyProperty.Register(
            nameof(ButtonBackground),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonBackgroundInactiveProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundInactive),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonBackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundMouseOver),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonBackgroundPressedProperty = DependencyProperty.Register(
            nameof(ButtonBackgroundPressed),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonBorderBrushProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrush),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonBorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrushInactive),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonBorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrushMouseOver),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonBorderBrushPressedProperty = DependencyProperty.Register(
            nameof(ButtonBorderBrushPressed),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonBorderThicknessProperty = DependencyProperty.Register(
            nameof(ButtonBorderThickness),
            typeof(Thickness),
            typeof(ComboBoxEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty ButtonCornerRadiusProperty = DependencyProperty.Register(
            nameof(ButtonCornerRadius),
            typeof(CornerRadius),
            typeof(ComboBoxEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ButtonForegroundProperty = DependencyProperty.Register(
            nameof(ButtonForeground),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ButtonForegroundInactive),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ButtonForegroundMouseOver),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonForegroundPressedProperty = DependencyProperty.Register(
            nameof(ButtonForegroundPressed),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ButtonMarginProperty = DependencyProperty.Register(
            nameof(ButtonMargin),
            typeof(Thickness),
            typeof(ComboBoxEx),
            new PropertyMetadata(new Thickness(2,0,0,0)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ComboBoxEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty DropDownBackgroundProperty = DependencyProperty.Register(
            nameof(DropDownBackground),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightBackground)));

        public static readonly DependencyProperty DropDownBorderBrushProperty = DependencyProperty.Register(
            nameof(DropDownBorderBrush),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColor)));

        public static readonly DependencyProperty DropDownBorderThicknessProperty = DependencyProperty.Register(
            nameof(DropDownBorderThickness),
            typeof(Thickness),
            typeof(ComboBoxEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty DropDownForegroundProperty = DependencyProperty.Register(
            nameof(DropDownForeground),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty DropDownCornerRadiusProperty = DependencyProperty.Register(
            nameof(DropDownCornerRadius),
            typeof(CornerRadius),
            typeof(ComboBoxEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty DropDownPaddingProperty = DependencyProperty.Register(
            nameof(DropDownPadding),
            typeof(Thickness),
            typeof(ComboBoxEx),
            new PropertyMetadata(new Thickness(2)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(ComboBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(ComboBoxEx),
            new PropertyMetadata(0.56d));


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

        public Brush ButtonForeground
        {
            get => (Brush)GetValue(ButtonForegroundProperty);
            set => SetValue(ButtonForegroundProperty, value);
        }

        public Brush ButtonForegroundInactive
        {
            get => (Brush)GetValue(ButtonForegroundInactiveProperty);
            set => SetValue(ButtonForegroundInactiveProperty, value);
        }

        public Brush ButtonForegroundMouseOver
        {
            get => (Brush)GetValue(ButtonForegroundMouseOverProperty);
            set => SetValue(ButtonForegroundMouseOverProperty, value);
        }

        public Brush ButtonForegroundPressed
        {
            get => (Brush)GetValue(ButtonForegroundPressedProperty);
            set => SetValue(ButtonForegroundPressedProperty, value);
        }

        public Thickness ButtonMargin
        {
            get => (Thickness)GetValue(ButtonMarginProperty);
            set => SetValue(ButtonMarginProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Brush DropDownBackground
        {
            get => (Brush)GetValue(DropDownBackgroundProperty);
            set => SetValue(DropDownBackgroundProperty, value);
        }
        
        public Brush DropDownBorderBrush
        {
            get => (Brush)GetValue(DropDownBorderBrushProperty);
            set => SetValue(DropDownBorderBrushProperty, value);
        }

        public Thickness DropDownBorderThickness
        {
            get => (Thickness)GetValue(DropDownBorderThicknessProperty);
            set => SetValue(DropDownBorderThicknessProperty, value);
        }

        public CornerRadius DropDownCornerRadius
        {
            get => (CornerRadius)GetValue(DropDownCornerRadiusProperty);
            set => SetValue(DropDownCornerRadiusProperty, value);
        }

        public Brush DropDownForeground
        {
            get => (Brush)GetValue(DropDownForegroundProperty);
            set => SetValue(DropDownForegroundProperty, value);
        }

        public Thickness DropDownPadding
        {
            get => (Thickness)GetValue(DropDownPaddingProperty);
            set => SetValue(DropDownPaddingProperty, value);
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

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ComboBoxEx class constructor. </summary>
        static ComboBoxEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ComboBoxEx),
                new FrameworkPropertyMetadata(typeof(ComboBoxEx)));
        }

        #endregion CONSTRUCTORS

    }
}
