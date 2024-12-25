using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Resources;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace chkam05.Tools.ControlsEx
{
    public class ButtonExWithIcon : ButtonEx
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty ContentMarginProperty = DependencyProperty.Register(
            nameof(ContentMargin),
            typeof(Thickness),
            typeof(ButtonEx),
            new PropertyMetadata(new Thickness(2, 0, 0, 0)));

        public static readonly DependencyProperty HorizontalIconAlignmentProperty = DependencyProperty.Register(
            nameof(HorizontalIconAlignment),
            typeof(HorizontalAlignment),
            typeof(ButtonEx),
            new PropertyMetadata(HorizontalAlignment.Center));

        public static readonly DependencyProperty IconHeightProperty = DependencyProperty.Register(
            nameof(IconHeight),
            typeof(double),
            typeof(ButtonEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty IconKindProperty = DependencyProperty.Register(
            nameof(IconKind),
            typeof(PackIconKind),
            typeof(ButtonEx),
            new PropertyMetadata(PackIconKind.CursorDefaultClick));

        public static readonly DependencyProperty IconMarginProperty = DependencyProperty.Register(
            nameof(IconMargin),
            typeof(Thickness),
            typeof(ButtonEx),
            new PropertyMetadata(new Thickness(0, 0, 2, 0)));

        public static readonly DependencyProperty IconPositionProperty = DependencyProperty.Register(
            nameof(IconPosition),
            typeof(NSWEPosition),
            typeof(ButtonEx),
            new PropertyMetadata(NSWEPosition.Left));

        public static readonly DependencyProperty IconWidthProperty = DependencyProperty.Register(
            nameof(IconWidth),
            typeof(double),
            typeof(ButtonEx),
            new PropertyMetadata(16d));

        public static readonly DependencyProperty VerticalIconAlignmentProperty = DependencyProperty.Register(
            nameof(VerticalIconAlignment),
            typeof(VerticalAlignment),
            typeof(ButtonEx),
            new PropertyMetadata(VerticalAlignment.Center));

        
        //  GETTERS & SETTERS

        public Thickness ContentMargin
        {
            get => (Thickness)GetValue(ContentMarginProperty);
            set => SetValue(ContentMarginProperty, value);
        }

        public HorizontalAlignment HorizontalIconAlignment
        {
            get => (HorizontalAlignment)GetValue(HorizontalIconAlignmentProperty);
            set => SetValue(HorizontalIconAlignmentProperty, value);
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
            get => (Thickness)(GetValue(IconMarginProperty));
            set => SetValue(IconMarginProperty, value);
        }

        public NSWEPosition IconPosition
        {
            get => (NSWEPosition)(GetValue(IconPositionProperty));
            set => SetValue(IconPositionProperty, value);
        }

        public double IconWidth
        {
            get => (double) GetValue(IconWidthProperty);
            set => SetValue(IconWidthProperty, value);
        }

        public VerticalAlignment VerticalIconAlignment
        {
            get => (VerticalAlignment)GetValue(VerticalIconAlignmentProperty);
            set => SetValue(VerticalIconAlignmentProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ButtonExWithIcon class constructor. </summary>
        static ButtonExWithIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonExWithIcon),
                new FrameworkPropertyMetadata(typeof(ButtonExWithIcon)));
        }

        #endregion CONSTRUCTORS

    }
}
