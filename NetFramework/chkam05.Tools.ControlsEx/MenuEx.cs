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
    public class MenuEx : Menu
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(MenuEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(MenuEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(MenuEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(MenuEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(MenuEx),
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

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> MenuEx class constructor. </summary>
        static MenuEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuEx),
                new FrameworkPropertyMetadata(typeof(MenuEx)));
        }

        #endregion CONSTRUCTORS

    }
}
