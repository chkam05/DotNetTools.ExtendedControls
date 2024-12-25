using chkam05.Tools.ControlsEx.Data.Enums;
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
    public class ToggleEx : ToggleButton
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ToggleEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundCheckedProperty = DependencyProperty.Register(
            nameof(ForegroundChecked),
            typeof(Brush),
            typeof(ToggleEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(ToggleEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(ToggleEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty ForegroundPressedProperty = DependencyProperty.Register(
            nameof(ForegroundPressed),
            typeof(Brush),
            typeof(ToggleEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(ToggleEx),
            new PropertyMetadata(0.56d));

        public static readonly DependencyProperty ToggleBrushProperty = DependencyProperty.Register(
            nameof(ToggleBrush),
            typeof(Brush),
            typeof(ToggleEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColor)));

        public static readonly DependencyProperty ToggleBrushCheckedProperty = DependencyProperty.Register(
            nameof(ToggleBrushChecked),
            typeof(Brush),
            typeof(ToggleEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty ToggleBrushInactiveProperty = DependencyProperty.Register(
            nameof(ToggleBrushInactive),
            typeof(Brush),
            typeof(ToggleEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty ToggleBrushMouseOverProperty = DependencyProperty.Register(
            nameof(ToggleBrushMouseOver),
            typeof(Brush),
            typeof(ToggleEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ToggleBrushPressedProperty = DependencyProperty.Register(
            nameof(ToggleBrushPressed),
            typeof(Brush),
            typeof(ToggleEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty ToggleTypeProperty = DependencyProperty.Register(
            nameof(ToggleType),
            typeof(ToggleTypeIcon),
            typeof(ToggleEx),
            new PropertyMetadata(ToggleTypeIcon.Filled));


        //  GETTERS & SETTERS

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

        public Brush ToggleBrush
        {
            get => (Brush)GetValue(ToggleBrushProperty);
            set => SetValue(ToggleBrushProperty, value);
        }

        public Brush ToggleBrushChecked
        {
            get => (Brush)GetValue(ToggleBrushCheckedProperty);
            set => SetValue(ToggleBrushCheckedProperty, value);
        }

        public Brush ToggleBrushInactive
        {
            get => (Brush)GetValue(ToggleBrushInactiveProperty);
            set => SetValue(ToggleBrushInactiveProperty, value);
        }

        public Brush ToggleBrushMouseOver
        {
            get => (Brush)GetValue(ToggleBrushMouseOverProperty);
            set => SetValue(ToggleBrushMouseOverProperty, value);
        }

        public Brush ToggleBrushPressed
        {
            get => (Brush)GetValue(ToggleBrushPressedProperty);
            set => SetValue(ToggleBrushPressedProperty, value);
        }

        public ToggleTypeIcon ToggleType
        {
            get => (ToggleTypeIcon)GetValue(ToggleTypeProperty);
            set => SetValue(ToggleTypeProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ToggleEx class constructor. </summary>
        static ToggleEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ToggleEx),
                new FrameworkPropertyMetadata(typeof(ToggleEx)));
        }

        #endregion CONSTRUCTORS

    }
}
