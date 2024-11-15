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
    public class ButtonEx : Button
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(Brush),
            typeof(ButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BackgroundPressedProperty = DependencyProperty.Register(
            nameof(BackgroundPressed),
            typeof(Brush),
            typeof(ButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected),
            typeof(Brush),
            typeof(ButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(ButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BorderBrushPressedProperty = DependencyProperty.Register(
            nameof(BorderBrushPressed),
            typeof(Brush),
            typeof(ButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected),
            typeof(Brush),
            typeof(ButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ButtonEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(ButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundPressedProperty = DependencyProperty.Register(
            nameof(ForegroundPressed),
            typeof(Brush),
            typeof(ButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected),
            typeof(Brush),
            typeof(ButtonEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));


        //  GETTERS & SETTERS

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

        public Brush BackgroundSelected
        {
            get => (Brush)GetValue(BackgroundSelectedProperty);
            set => SetValue(BackgroundSelectedProperty, value);
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

        public Brush BorderBrushSelected
        {
            get => (Brush)GetValue(BorderBrushSelectedProperty);
            set => SetValue(BorderBrushSelectedProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
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

        public Brush ForegroundSelected
        {
            get => (Brush)GetValue(ForegroundSelectedProperty);
            set => SetValue(ForegroundSelectedProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ButtonEx class constructor. </summary>
        static ButtonEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonEx),
                new FrameworkPropertyMetadata(typeof(ButtonEx)));
        }

        #endregion CONSTRUCTORS

    }
}
