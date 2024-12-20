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
    public class MenuItemEx : MenuItem
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(BackgroundMouseOver),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BackgroundSelectedProperty = DependencyProperty.Register(
            nameof(BackgroundSelected),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty BorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(BorderBrushMouseOver),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty BorderBrushSelectedProperty = DependencyProperty.Register(
            nameof(BorderBrushSelected),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorSelected)));

        public static readonly DependencyProperty ContentPaddingProperty = DependencyProperty.Register(
            nameof(ContentPadding),
            typeof(Thickness),
            typeof(MenuItemEx),
            new PropertyMetadata(new Thickness(6, 0, 6, 0)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(MenuItemEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
           nameof(ForegroundInactive),
           typeof(Brush),
           typeof(MenuItemEx),
           new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty ForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ForegroundMouseOver),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ForegroundSelectedProperty = DependencyProperty.Register(
            nameof(ForegroundSelected),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            nameof(IconHeight),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind),
            typeof(PackIconKind),
            typeof(MenuItemEx),
            new PropertyMetadata(PackIconKind.None));

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(
            nameof(IconMargin),
            typeof(Thickness),
            typeof(MenuItemEx),
            new PropertyMetadata(new Thickness(3)));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
            nameof(IconWidth),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(MenuItemEx),
            new PropertyMetadata(0.56d));

        public static readonly DependencyProperty ShortcutPaddingProperty = DependencyProperty.Register(
            nameof(ShortcutPadding),
            typeof(Thickness),
            typeof(MenuItemEx),
            new PropertyMetadata(new Thickness(8, 0, 3, 0)));

        public static readonly DependencyProperty SubMenuBackgroundProperty = DependencyProperty.Register(
            nameof(SubMenuBackground),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightBackground)));

        public static readonly DependencyProperty SubMenuBorderBrushProperty = DependencyProperty.Register(
            nameof(SubMenuBorderBrush),
            typeof(Brush),
            typeof(MenuItemEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty SubMenuBorderThicknessProperty = DependencyProperty.Register(
            nameof(SubMenuBorderThickness),
            typeof(Thickness),
            typeof(MenuItemEx),
            new PropertyMetadata(new Thickness(1)));


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

        public double IconHeight
        {
            get => (double)GetValue(IconHeightProperty);
            set => SetValue(IconHeightProperty, value);
        }

        public PackIconKind IconKind
        {
            get => (PackIconKind)GetValue(IconKindProperty);
            set => SetValue(IconKindProperty, value);
        }

        public Thickness IconMargin
        {
            get => (Thickness)GetValue(IconMarginProperty);
            set => SetValue(IconMarginProperty, value);
        }

        public double IconWidth
        {
            get => (double)GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        }

        public double OpacityInactive
        {
            get => (double)GetValue(OpacityInactiveProperty);
            set => SetValue(OpacityInactiveProperty, MathUtilities.Clamp(value, 0d, 1d));
        }

        public Thickness ShortcutPadding
        {
            get => (Thickness)GetValue(ShortcutPaddingProperty);
            set => SetValue(ShortcutPaddingProperty, value);
        }

        public Brush SubMenuBackground
        {
            get => (Brush)GetValue(SubMenuBackgroundProperty);
            set => SetValue(SubMenuBackgroundProperty, value);
        }

        public Brush SubMenuBorderBrush
        {
            get => (Brush)GetValue(SubMenuBorderBrushProperty);
            set => SetValue(SubMenuBorderBrushProperty, value);
        }

        public Thickness SubMenuBorderThickness
        {
            get => (Thickness)GetValue(SubMenuBorderThicknessProperty);
            set => SetValue(SubMenuBorderThicknessProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> MenuItemEx class constructor. </summary>
        static MenuItemEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuItemEx),
                new FrameworkPropertyMetadata(typeof(MenuItemEx)));
        }

        #endregion CONSTRUCTORS

    }
}
