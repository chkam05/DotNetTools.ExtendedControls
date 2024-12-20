using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace chkam05.Tools.ControlsEx
{
    public class ContextMenuEx : ContextMenu
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(ContextMenuEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty ScrollViewerStyleProperty = DependencyProperty.Register(
           nameof(ScrollViewerStyle),
           typeof(Style),
           typeof(ContextMenuEx),
           new PropertyMetadata(GetGenericScrollViewerExStyle()));


        //  GETTERS & SETTERS

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Style ScrollViewerStyle
        {
            get => (Style)GetValue(ScrollViewerStyleProperty);
            set => SetValue(ScrollViewerStyleProperty, value);
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> ContextMenuEx class constructor. </summary>
        static ContextMenuEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ContextMenuEx),
                new FrameworkPropertyMetadata(typeof(ContextMenuEx)));
        }

        #endregion CONSTRUCTORS

        #region ITEMS

        //  --------------------------------------------------------------------------------
        /// <summary> Creates or identifies the element used to display the specified item. </summary>
        /// <returns> The element used to display the specified item. </returns>
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ContextMenuItemEx();
        }

        #endregion ITEMS

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic ScrollBarEx style from resources. </summary>
        /// <returns> ScrollBarEx style. </returns>
        protected static Style GetGenericScrollViewerExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/ScrollViewerEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["ScrollViewerExStyle"] as Style;
        }

        #endregion STYLES

    }
}
