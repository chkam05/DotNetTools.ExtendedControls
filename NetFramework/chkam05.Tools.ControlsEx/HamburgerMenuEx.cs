using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace chkam05.Tools.ControlsEx
{
    public class HamburgerMenuEx : Control
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ExpandMenuOnHoverProperty = DependencyProperty.Register(
            nameof(ExpandMenuOnHover),
            typeof(bool),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty IsExpandedProperty = DependencyProperty.Register(
            nameof(IsExpanded),
            typeof(bool),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(false, IsExpandedPropertyChangeCallback));

        public static readonly DependencyProperty ItemBorderThicknessProperty = DependencyProperty.Register(
            nameof(ItemBorderThickness),
            typeof(Thickness),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(new Thickness(1)));

        public static readonly DependencyProperty ItemHeightProperty = DependencyProperty.Register(
            nameof(ItemHeight),
            typeof(double),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(40d, ItemHeightPropertyChangeCallback));

        public static readonly DependencyProperty ItemMarginProperty = DependencyProperty.Register(
            nameof(ItemMargin),
            typeof(Thickness),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(new Thickness(0,1,0,1)));

        public static readonly DependencyProperty ItemPaddingProperty = DependencyProperty.Register(
            nameof(ItemPadding),
            typeof(Thickness),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(new Thickness(4)));

        public static readonly DependencyProperty ItemStyleProperty = DependencyProperty.Register(
            nameof(ItemStyle),
            typeof(Style),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(GetGenericListViewItemExStyle()));

        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            nameof(Items),
            typeof(ObservableCollection<HamburgerMenuItemViewModel>),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(new ObservableCollection<HamburgerMenuItemViewModel>()));

        public static readonly DependencyProperty LeaveSelectionActiveProperty = DependencyProperty.Register(
            nameof(LeaveSelectionActive),
            typeof(bool),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(false));

        public static readonly DependencyProperty ShowDescriptionInToolTipProperty = DependencyProperty.Register(
            nameof(ShowDescriptionInToolTip),
            typeof(bool),
            typeof(HamburgerMenuEx),
            new PropertyMetadata(true));


        //  GETTERS & SETTERS

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public bool ExpandMenuOnHover
        {
            get => (bool)GetValue(ExpandMenuOnHoverProperty);
            set => SetValue(ExpandMenuOnHoverProperty, value);
        }

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        public Thickness ItemBorderThickness
        {
            get => (Thickness)GetValue(ItemBorderThicknessProperty);
            set => SetValue(ItemBorderThicknessProperty, value);
        }

        public double ItemHeight
        {
            get => (double)GetValue(ItemHeightProperty);
            set => SetValue(ItemHeightProperty, value);
        }

        public Thickness ItemMargin
        {
            get => (Thickness)GetValue(ItemMarginProperty);
            set => SetValue(ItemMarginProperty, value);
        }

        public Thickness ItemPadding
        {
            get => (Thickness)GetValue(ItemPaddingProperty);
            set => SetValue(ItemPaddingProperty, value);
        }

        public Style ItemStyle
        {
            get => (Style)GetValue(ItemStyleProperty);
            set => SetValue(ItemStyleProperty, value);
        }

        public ObservableCollection<HamburgerMenuItemViewModel> Items
        {
            get => (ObservableCollection<HamburgerMenuItemViewModel>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public bool LeaveSelectionActive
        {
            get => (bool)GetValue(LeaveSelectionActiveProperty);
            set => SetValue(LeaveSelectionActiveProperty, value);
        }

        public bool ShowDescriptionInToolTip
        {
            get => (bool)GetValue(ShowDescriptionInToolTipProperty);
            set => SetValue(ShowDescriptionInToolTipProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> HamburgerMenuEx class constructor. </summary>
        static HamburgerMenuEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(HamburgerMenuEx),
                new FrameworkPropertyMetadata(typeof(HamburgerMenuEx)));
        }

        #endregion CONSTRUCTORS

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when ItemHeight property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void ItemHeightPropertyChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var hamburgerMenu = d as HamburgerMenuEx;

            if (hamburgerMenu != null)
                hamburgerMenu.UpdateMinWidth();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when IsExpanded property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void IsExpandedPropertyChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion PROPERTIES CHANGED CALLBACKS

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic ListViewItemEx style from resources. </summary>
        /// <returns> ListViewItemEx style. </returns>
        protected static Style GetGenericListViewItemExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/HamburgerMenuEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["HamburgerMenuEx.ListViewItemExStyle"] as Style;
        }

        #endregion STYLES

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            UpdateMinWidth();
        }

        #endregion TEMPLATE

        #region UPDATE APPEARANCE

        //  --------------------------------------------------------------------------------
        protected virtual void UpdateMinWidth()
        {
            MinWidth = ItemHeight
                + (Padding.Left + Padding.Right)
                + (ItemMargin.Left + ItemMargin.Right)
                + (ItemBorderThickness.Left + ItemBorderThickness.Right)
                + (ItemPadding.Left + ItemPadding.Right)
                - (ItemPadding.Top + ItemPadding.Bottom);

            if (!IsExpanded)
                Width = MinWidth;
        }

        #endregion UPDATE APPEARANCE

    }
}
