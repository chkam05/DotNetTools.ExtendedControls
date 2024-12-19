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
    public class TreeViewItemEx : TreeViewItem
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(TreeViewItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(Brush),
            typeof(TreeViewItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected),
            typeof(Brush),
            typeof(TreeViewItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(TreeViewItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(TreeViewItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected),
            typeof(Brush),
            typeof(TreeViewItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty ChildPaddingProperty = DependencyProperty.Register(
            nameof(ChildPadding),
            typeof(Thickness),
            typeof(TreeViewItemEx),
            new PropertyMetadata(new Thickness(8,0,0,0)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(TreeViewItemEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ExpanderIconHeightProperty = DependencyProperty.Register(
            nameof(ExpanderIconHeight),
            typeof(double),
            typeof(TreeViewItemEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty ExpanderIconWidthProperty = DependencyProperty.Register(
            nameof(ExpanderIconWidth),
            typeof(double),
            typeof(TreeViewItemEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
           nameof(ForegroundInactive),
           typeof(Brush),
           typeof(TreeViewItemEx),
           new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(TreeViewItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected),
            typeof(Brush),
            typeof(TreeViewItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(TreeViewItemEx),
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

        public Brush BackgroundSelected
        {
            get => (Brush)GetValue(BackgroundSelectedProperty);
            set => SetValue(BackgroundSelectedProperty, value);
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

        public Brush BorderBrushSelected
        {
            get => (Brush)GetValue(BorderBrushSelectedProperty);
            set => SetValue(BorderBrushSelectedProperty, value);
        }

        public Thickness ChildPadding
        {
            get => (Thickness)GetValue(ChildPaddingProperty);
            set => SetValue(ChildPaddingProperty, value);
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public double ExpanderIconHeight
        {
            get => (double)GetValue(ExpanderIconHeightProperty);
            set => SetValue(ExpanderIconHeightProperty, value);
        }

        public double ExpanderIconWidth
        {
            get => (double)GetValue(ExpanderIconWidthProperty);
            set => SetValue(ExpanderIconWidthProperty, value);
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

        public Brush ForegroundSelected
        {
            get => (Brush)GetValue(ForegroundSelectedProperty);
            set => SetValue(ForegroundSelectedProperty, value);
        }

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> TreeViewItemEx class constructor. </summary>
        static TreeViewItemEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TreeViewItemEx),
                new FrameworkPropertyMetadata(typeof(TreeViewItemEx)));
        }

        #endregion CONSTRUCTORS

    }
}
