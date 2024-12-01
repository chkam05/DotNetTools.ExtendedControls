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
    public class GridViewEx : ListViewEx
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty ColumnHeaderBackgroundProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackground),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty ColumnHeaderBackgroundInactiveProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackgroundInactive),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ColumnHeaderBackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackgroundMouseOver),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ColumnHeaderBackgroundPressedProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBackgroundPressed),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty ColumnHeaderBorderBrushProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderBrush),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightShadeBackground)));

        public static readonly DependencyProperty ColumnHeaderBorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderBrushInactive),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ColumnHeaderBorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderBrushMouseOver),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorMouseOver)));

        public static readonly DependencyProperty ColumnHeaderBorderBrushPressedProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderBrushPressed),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorPressed)));

        public static readonly DependencyProperty ColumnHeaderBorderThicknessProperty = DependencyProperty.Register(
            nameof(ColumnHeaderBorderThickness),
            typeof(Thickness),
            typeof(GridViewEx),
            new PropertyMetadata(new Thickness(0, 0, 1, 1)));

        public static readonly DependencyProperty ColumnHeaderForegroundProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForeground),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightForeground)));

        public static readonly DependencyProperty ColumnHeaderForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForegroundInactive),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ColumnHeaderForegroundMouseOverProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForegroundMouseOver),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ColumnHeaderForegroundPressedProperty = DependencyProperty.Register(
            nameof(ColumnHeaderForegroundPressed),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DefaultAccentColorForeground)));

        public static readonly DependencyProperty ColumnHeaderMarginProperty = DependencyProperty.Register(
            nameof(ColumnHeaderMargin),
            typeof(Thickness),
            typeof(GridViewEx),
            new PropertyMetadata(new Thickness(0)));

        public static readonly DependencyProperty ColumnHeaderPaddingProperty = DependencyProperty.Register(
            nameof(ColumnHeaderPadding),
            typeof(Thickness),
            typeof(GridViewEx),
            new PropertyMetadata(new Thickness(2,1,2,1)));

        public static readonly DependencyProperty ColumnGripperBackgroundProperty = DependencyProperty.Register(
            nameof(ColumnGripperBackground),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty ColumnGripperBackgroundInactiveProperty = DependencyProperty.Register(
            nameof(ColumnGripperBackgroundInactive),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty ColumnGripperBackgroundMouseOverProperty = DependencyProperty.Register(
            nameof(ColumnGripperBackgroundMouseOver),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty ColumnGripperBackgroundPressedProperty = DependencyProperty.Register(
            nameof(ColumnGripperBackgroundPressed),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static readonly DependencyProperty ColumnGripperBorderBrushProperty = DependencyProperty.Register(
            nameof(ColumnGripperBorderBrush),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightBackground)));

        public static readonly DependencyProperty ColumnGripperBorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(ColumnGripperBorderBrushInactive),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighInactive)));

        public static readonly DependencyProperty ColumnGripperBorderBrushMouseOverProperty = DependencyProperty.Register(
            nameof(ColumnGripperBorderBrushMouseOver),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighMouseOver)));

        public static readonly DependencyProperty ColumnGripperBorderBrushPressedProperty = DependencyProperty.Register(
            nameof(ColumnGripperBorderBrushPressed),
            typeof(Brush),
            typeof(GridViewEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LighPressed)));

        public static readonly DependencyProperty ColumnGripperBorderThicknessProperty = DependencyProperty.Register(
            nameof(ColumnGripperBorderThickness),
            typeof(Thickness),
            typeof(GridViewEx),
            new PropertyMetadata(new Thickness(0, 0, 1, 1)));

        public static readonly DependencyProperty ColumnTextAlignmentProperty = DependencyProperty.Register(
            nameof(ColumnTextAlignment),
            typeof(TextAlignment),
            typeof(GridViewEx),
            new PropertyMetadata(TextAlignment.Left));


        //  GETTERS & SETTERS

        public Brush ColumnHeaderBackground
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundProperty);
            set => SetValue(ColumnHeaderBackgroundProperty, value);
        }

        public Brush ColumnHeaderBackgroundInactive
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundInactiveProperty);
            set => SetValue(ColumnHeaderBackgroundInactiveProperty, value);
        }

        public Brush ColumnHeaderBackgroundMouseOver
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundMouseOverProperty);
            set => SetValue(ColumnHeaderBackgroundMouseOverProperty, value);
        }

        public Brush ColumnHeaderBackgroundPressed
        {
            get => (Brush)GetValue(ColumnHeaderBackgroundPressedProperty);
            set => SetValue(ColumnHeaderBackgroundPressedProperty, value);
        }

        public Brush ColumnHeaderBorderBrush
        {
            get => (Brush)GetValue(ColumnHeaderBorderBrushProperty);
            set => SetValue(ColumnHeaderBorderBrushProperty, value);
        }

        public Brush ColumnHeaderBorderBrushInactive
        {
            get => (Brush)GetValue(ColumnHeaderBorderBrushInactiveProperty);
            set => SetValue(ColumnHeaderBorderBrushInactiveProperty, value);
        }

        public Brush ColumnHeaderBorderBrushMouseOver
        {
            get => (Brush)GetValue(ColumnHeaderBorderBrushMouseOverProperty);
            set => SetValue(ColumnHeaderBorderBrushMouseOverProperty, value);
        }

        public Brush ColumnHeaderBorderBrushPressed
        {
            get => (Brush)GetValue(ColumnHeaderBorderBrushPressedProperty);
            set => SetValue(ColumnHeaderBorderBrushPressedProperty, value);
        }

        public Thickness ColumnHeaderBorderThickness
        {
            get => (Thickness)GetValue(ColumnHeaderBorderThicknessProperty);
            set => SetValue(ColumnHeaderBorderThicknessProperty, value);
        }

        public Brush ColumnHeaderForeground
        {
            get => (Brush)GetValue(ColumnHeaderForegroundProperty);
            set => SetValue(ColumnHeaderForegroundProperty, value);
        }

        public Brush ColumnHeaderForegroundInactive
        {
            get => (Brush)GetValue(ColumnHeaderForegroundInactiveProperty);
            set => SetValue(ColumnHeaderForegroundInactiveProperty, value);
        }

        public Brush ColumnHeaderForegroundMouseOver
        {
            get => (Brush)GetValue(ColumnHeaderForegroundMouseOverProperty);
            set => SetValue(ColumnHeaderForegroundMouseOverProperty, value);
        }

        public Brush ColumnHeaderForegroundPressed
        {
            get => (Brush)GetValue(ColumnHeaderForegroundPressedProperty);
            set => SetValue(ColumnHeaderForegroundPressedProperty, value);
        }

        public Thickness ColumnHeaderMargin
        {
            get => (Thickness)GetValue(ColumnHeaderMarginProperty);
            set => SetValue(ColumnHeaderMarginProperty, value);
        }

        public Thickness ColumnHeaderPadding
        {
            get => (Thickness)GetValue(ColumnHeaderPaddingProperty);
            set => SetValue(ColumnHeaderPaddingProperty, value);
        }

        public Brush ColumnGripperBackground
        {
            get => (Brush)GetValue(ColumnGripperBackgroundProperty);
            set => SetValue(ColumnGripperBackgroundProperty, value);
        }

        public Brush ColumnGripperBackgroundInactive
        {
            get => (Brush)GetValue(ColumnGripperBackgroundInactiveProperty);
            set => SetValue(ColumnGripperBackgroundInactiveProperty, value);
        }

        public Brush ColumnGripperBackgroundMouseOver
        {
            get => (Brush)GetValue(ColumnGripperBackgroundMouseOverProperty);
            set => SetValue(ColumnGripperBackgroundMouseOverProperty, value);
        }

        public Brush ColumnGripperBackgroundPressed
        {
            get => (Brush)GetValue(ColumnGripperBackgroundPressedProperty);
            set => SetValue(ColumnGripperBackgroundPressedProperty, value);
        }

        public Brush ColumnGripperBorderBrush
        {
            get => (Brush)GetValue(ColumnGripperBorderBrushProperty);
            set => SetValue(ColumnGripperBorderBrushProperty, value);
        }

        public Brush ColumnGripperBorderBrushInactive
        {
            get => (Brush)GetValue(ColumnGripperBorderBrushInactiveProperty);
            set => SetValue(ColumnGripperBorderBrushInactiveProperty, value);
        }

        public Brush ColumnGripperBorderBrushMouseOver
        {
            get => (Brush)GetValue(ColumnGripperBorderBrushMouseOverProperty);
            set => SetValue(ColumnGripperBorderBrushMouseOverProperty, value);
        }

        public Brush ColumnGripperBorderBrushPressed
        {
            get => (Brush)GetValue(ColumnGripperBorderBrushPressedProperty);
            set => SetValue(ColumnGripperBorderBrushPressedProperty, value);
        }

        public Thickness ColumnGripperBorderThickness
        {
            get => (Thickness)GetValue(ColumnGripperBorderThicknessProperty);
            set => SetValue(ColumnGripperBorderThicknessProperty, value);
        }

        public TextAlignment ColumnTextAlignment
        {
            get => (TextAlignment)GetValue(ColumnTextAlignmentProperty);
            set => SetValue(ColumnTextAlignmentProperty, value);
        }

        public new ViewBase View
        {
            get => base.View;
            set => base.View = value;
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> GridViewEx class constructor. </summary>
        static GridViewEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GridViewEx),
                new FrameworkPropertyMetadata(typeof(GridViewEx)));

            ViewProperty.OverrideMetadata(
                typeof(GridViewEx),
                new FrameworkPropertyMetadata(null)
            );
        }

        #endregion CONSTRUCTORS

        #region ITEMS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates or identifies the element used to display the specified item. </summary>
        /// <returns> The element used to display the specified item. </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new GridViewItemEx();
        }

        #endregion ITEMS

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (View == null)
                View = new GridView();
        }

        #endregion TEMPLATE

    }
}
