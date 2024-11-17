using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx
{
    public class ToggleButtonEx : ToggleButton
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundCheckedProperty = DependencyProperty.Register(
            nameof(BackgroundChecked),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BackgroundPressedProperty = DependencyProperty.Register(
            nameof(BackgroundPressed),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty BorderBrushCheckedProperty = DependencyProperty.Register(
            nameof(BorderBrushChecked),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BorderBrushPressedProperty = DependencyProperty.Register(
            nameof(BorderBrushPressed),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundCheckedProperty = DependencyProperty.Register(
            nameof(ForegroundChecked),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundPressedProperty = DependencyProperty.Register(
            nameof(ForegroundPressed),
            typeof(Brush),
            typeof(ToggleButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(ToggleButtonEx),
            new PropertyMetadata(0.56d));


        //  GETTERS & SETTERS

        public Brush BackgroundChecked
        {
            get => (Brush)GetValue(BackgroundCheckedProperty);
            set => SetValue(BackgroundCheckedProperty, value);
        }

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

        public Brush BackgroundPressed
        {
            get => (Brush)GetValue(BackgroundPressedProperty);
            set => SetValue(BackgroundPressedProperty, value);
        }

        public Brush BorderBrushChecked
        {
            get => (Brush)GetValue(BorderBrushCheckedProperty);
            set => SetValue(BorderBrushCheckedProperty, value);
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

        public Brush BorderBrushPressed
        {
            get => (Brush)GetValue(BorderBrushPressedProperty);
            set => SetValue(BorderBrushPressedProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Brush ForegroundChecked
        {
            get => (Brush)GetValue(ForegroundCheckedProperty);
            set => SetValue(ForegroundCheckedProperty, value);
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


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ToggleButtonEx class constructor. </summary>
        static ToggleButtonEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleButtonEx),
                new FrameworkPropertyMetadata(typeof(ToggleButtonEx)));
        }

        #endregion CONSTRUCTORS

    }
}
