using chkam05.Tools.ControlsEx.Data.Collections;
using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Resources;
using chkam05.Tools.ControlsEx.Utilities;
using chkam05.Tools.ControlsEx.Utilities.Interfaces;
using chkam05.Tools.ControlsEx.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using static MaterialDesignThemes.Wpf.Theme;

namespace chkam05.Tools.ControlsEx
{
    public class FrameEx : Control
    {

        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty BackgroundInactiveProperty = DependencyProperty.Register(
            nameof(BackgroundInactive),
            typeof(Brush),
            typeof(FrameEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty BorderBrushInactiveProperty = DependencyProperty.Register(
            nameof(BorderBrushInactive),
            typeof(Brush),
            typeof(FrameEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.LightInactive)));

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(FrameEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty CurrentPageProperty = DependencyProperty.Register(
            nameof(CurrentPage),
            typeof(Page),
            typeof(FrameEx),
            new PropertyMetadata(null, CurrentPagePropertyChangedCallback));

        public static readonly DependencyProperty CurrentPageIndexProperty = DependencyProperty.Register(
            nameof(CurrentPageIndex),
            typeof(int),
            typeof(FrameEx),
            new PropertyMetadata(0, CurrentPageIndexPropertyChangedCallback));

        public static readonly DependencyProperty ForegroundInactiveProperty = DependencyProperty.Register(
            nameof(ForegroundInactive),
            typeof(Brush),
            typeof(FrameEx),
            new PropertyMetadata(new SolidColorBrush(ColorsResources.DarkInactive)));

        public static readonly DependencyProperty OpacityInactiveProperty = DependencyProperty.Register(
            nameof(OpacityInactive),
            typeof(double),
            typeof(FrameEx),
            new PropertyMetadata(0.56d));

        public static readonly DependencyProperty PagesProperty = DependencyProperty.Register(
            nameof(Pages),
            typeof(FrameExPagesCollection<Page>),
            typeof(FrameEx),
            new PropertyMetadata(new FrameExPagesCollection<Page>(), PagesPropertyChangedCallback));


        //  DELEGATES



        //  EVENTS

        //  OnPageLoaded
        //  OnPageUnloaded


        //  VARIABLES

        private Frame frame;
        private bool pageSwitching = false;


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

        public bool CanGoBack
        {
            get => Pages != null && Pages.Any() && CurrentPage != null && CurrentPageIndex > 0;
        }

        public bool CanGoForward
        {
            get => Pages != null && Pages.Any() && CurrentPage != null && CurrentPageIndex < PagesCount - 1;
        }

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Page CurrentPage
        {
            get => (Page)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        public int CurrentPageIndex
        {
            get => (int)GetValue(CurrentPageIndexProperty);
            set => SetValue(CurrentPageIndexProperty, value);
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

        public FrameExPagesCollection<Page> Pages
        {
            get => (FrameExPagesCollection<Page>)GetValue(PagesProperty);
            set => SetValue(PagesProperty, value);
        }

        public int PagesCount
        {
            get => Pages?.Count ?? 0;
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> FrameEx class constructor. </summary>
        static FrameEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FrameEx),
                new FrameworkPropertyMetadata(typeof(FrameEx)));
        }

        #endregion CONSTRUCTORS

        #region COMPONENT

        //  --------------------------------------------------------------------------------
        /// <summary> Remove currently loaded page from content frame method. </summary>
        private void ClearFrameContent()
        {
            frame.Content = null;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked during loading content into the Frame component. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Navigation event arguments. </param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnFrameNavigated(object sender, NavigationEventArgs e)
        {
            //  Remove previous pages from content frame back entry.
            RemoveBackEntry();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Removes previous pages from content frame back entry method. </summary>
        private void RemoveBackEntry()
        {
            //  Get previous pages from content frame navigation service.
            var backEntry = frame.NavigationService.RemoveBackEntry();

            //  While previous pages are available - try to remove it.
            while (backEntry != null)
                backEntry = frame.NavigationService.RemoveBackEntry();
        }

        #endregion COMPONENT

        #region NAVIGATION

        //  --------------------------------------------------------------------------------
        public void GoBack()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        public void GoForward()
        {
            //
        }

        //  --------------------------------------------------------------------------------
        public void GoToPage(Page page)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        public void GoToPage(int pageIndex)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        public void LoadPage(Page page)
        {
            //
        }

        //  --------------------------------------------------------------------------------
        public void UnloadPage(Page page)
        {
            //
        }

        #endregion NAVIGATION

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when CurrentPage property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void CurrentPagePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameEx = d as FrameEx;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when CurrentPageIndex property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void CurrentPageIndexPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameEx = d as FrameEx;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when Pages property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void PagesPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var frameEx = d as FrameEx;

            if (frameEx != null)
            {
                if (e.OldValue is FrameExPagesCollection<Page> oldCollection)
                    oldCollection.CollectionChanged -= frameEx.OnPagesCollectionChanged;
                
                if (e.NewValue is FrameExPagesCollection<Page> newCollection)
                    newCollection.CollectionChanged += frameEx.OnPagesCollectionChanged;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after items change in Pages collection. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Notify collection changed event arguments. </param>
        private void OnPagesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            //
        }

        #endregion PROPERTIES CHANGED CALLBACKS

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            frame = GetTemplateChild("frame") as Frame;

            if (frame != null)
            {
                frame.Navigated += OnFrameNavigated;
            }
        }

        #endregion TEMPLATE

    }
}
