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
    public class GroupBoxEx : GroupBox
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(GroupBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(GroupBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(GroupBoxEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty HeaderForegroundProperty = DependencyProperty.Register(
            nameof(HeaderForeground),
            typeof(Brush),
            typeof(GroupBoxEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty HeaderMarginProperty = DependencyProperty.Register(
            nameof(HeaderMargin),
            typeof(Thickness),
            typeof(GroupBoxEx),
            new PropertyMetadata(new Thickness(8,0,0,0)));

        public static readonly DependencyProperty HeaderPaddingProperty = DependencyProperty.Register(
            nameof(HeaderPadding),
            typeof(Thickness),
            typeof(GroupBoxEx),
            new PropertyMetadata(new Thickness(2)));


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

        public Brush HeaderForeground
        {
            get => (Brush)GetValue(HeaderForegroundProperty);
            set => SetValue(HeaderForegroundProperty, value);
        }

        public Thickness HeaderMargin
        {
            get => (Thickness)GetValue(HeaderMarginProperty);
            set => SetValue(HeaderMarginProperty, value);
        }

        public Thickness HeaderPadding
        {
            get => (Thickness)GetValue(HeaderPaddingProperty);
            set => SetValue(HeaderPaddingProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> GroupBoxEx class constructor. </summary>
        static GroupBoxEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GroupBoxEx),
                new FrameworkPropertyMetadata(typeof(GroupBoxEx)));
        }

        #endregion CONSTRUCTORS

    }
}
