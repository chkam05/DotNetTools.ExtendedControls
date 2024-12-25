using chkam05.Tools.ControlsEx.Data.Enums;
using chkam05.Tools.ControlsEx.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace chkam05.Tools.ControlsEx
{
    public class WindowEx : Window
    {

        //  CONST

        private static readonly string[] resizeBordersNames = new string[]
        {
            "resizeTopLeftBorder",
            "resizeTopBorder",
            "resizeTopRightBorder",
            "resizeRightBorderH",
            "resizeRightBorderC",
            "resizeBottomRightBorder",
            "resizeBottomBorder",
            "resizeBottomLeftBorder",
            "resizeLeftBorderH",
            "resizeLeftBorderC"
        };


        //  DEPENDENCY PROPERTIES

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(
            nameof(CornerRadius),
            typeof(CornerRadius),
            typeof(WindowEx),
            new PropertyMetadata(new CornerRadius(4)));

        public static readonly DependencyProperty IsMaximizedProperty = DependencyProperty.Register(
            nameof(IsMaximized),
            typeof(bool),
            typeof(WindowEx),
            new PropertyMetadata(false, IsMaximizedPropertyChangeCallback));

        public static readonly DependencyProperty IsMinimizedProperty = DependencyProperty.Register(
            nameof(IsMinimized),
            typeof(bool),
            typeof(WindowEx),
            new PropertyMetadata(false, IsMinimizedPropertyChangeCallback));

        public static readonly DependencyProperty ResizeAreaSizeProperty = DependencyProperty.Register(
            nameof(ResizeAreaSize),
            typeof(double),
            typeof(WindowEx),
            new PropertyMetadata(2d));

        public static readonly DependencyProperty WindowTitleBarExStyleProperty = DependencyProperty.Register(
            nameof(WindowTitleBarExStyle),
            typeof(Style),
            typeof(WindowEx),
            new PropertyMetadata(GetGenericWindowTitleBarExStyle()));

        public static readonly DependencyProperty TitleBarVisibilityProperty = DependencyProperty.Register(
            nameof(TitleBarVisibility),
            typeof(Visibility),
            typeof(WindowEx),
            new PropertyMetadata(Visibility.Visible));


        //  VARIABLES

        private bool isResizing;
        private Point lastMousePosition;
        private Point normalPosition;
        private Size normalSize;
        private WindowExResizeDirection resizeDirection;


        //  GETTERS & SETTERS

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public bool IsMaximized
        {
            get => (bool)GetValue(IsMaximizedProperty);
            set => SetValue(IsMaximizedProperty, value);
        }

        public bool IsMinimized
        {
            get => (bool)GetValue(IsMinimizedProperty);
            set => SetValue(IsMinimizedProperty, value);
        }

        public double ResizeAreaSize
        {
            get => (double)GetValue(ResizeAreaSizeProperty);
            set => SetValue(ResizeAreaSizeProperty, value);
        }

        public Style WindowTitleBarExStyle
        {
            get => (Style)GetValue(WindowTitleBarExStyleProperty);
            set => SetValue(WindowTitleBarExStyleProperty, value);
        }

        public Visibility TitleBarVisibility
        {
            get => (Visibility)GetValue(TitleBarVisibilityProperty);
            set => SetValue(TitleBarVisibilityProperty, value);
        }

        private new WindowState WindowState
        {
            get => base.WindowState;
            set => base.WindowState = value;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("WindowStyle property is not supported in WindowEx.", true)]
        public new WindowStyle WindowStyle
        {
            get => base.WindowStyle;
            private set => base.WindowStyle = value;
        }


        //  METHODS

        #region CONSTRUCTORS

        //  --------------------------------------------------------------------------------
        /// <summary> WindowEx class constructor. </summary>
        public WindowEx()
        {
            MouseMove += OnWindowMouseMove;
            MouseUp += OnWindowMouseUp;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> WindowEx class constructor. </summary>
        static WindowEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowEx),
                new FrameworkPropertyMetadata(typeof(WindowEx)));

            WindowStateProperty.OverrideMetadata(
                typeof(WindowEx),
                new FrameworkPropertyMetadata(WindowState.Normal, WindowStatePropertyChangedCallback));

            WindowStyleProperty.OverrideMetadata(
                typeof(WindowEx),
                new FrameworkPropertyMetadata(WindowStyle.None));
        }

        #endregion CONSTRUCTORS

        #region BUTTONS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after clicking title bar close button. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        private void OnTitleBarCloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after clicking title bar maximize button. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        private void OnTitleBarMaximizeButtonClick(object sender, RoutedEventArgs e)
        {
            IsMaximized = !IsMaximized;
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked after clicking title bar minimize button. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Routed event arguments. </param>
        private void OnTitleBarMinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            IsMinimized = true;
        }

        #endregion BUTTONS

        #region PROPERTIES CHANGED CALLBACKS

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when IsMaximized property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void IsMaximizedPropertyChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as WindowEx;

            if (window != null && e.OldValue is bool oldValue && e.NewValue is bool newValue)
            {
                if (oldValue == false && newValue == true)
                {
                    window.normalPosition = new Point(window.Left, window.Top);
                    window.normalSize = new Size(window.Width, window.Height);

                    var screenWorkingArea = SystemParameters.WorkArea;
                    window.Top = screenWorkingArea.Top;
                    window.Left = screenWorkingArea.Left;
                    window.Width = screenWorkingArea.Width;
                    window.Height = screenWorkingArea.Height;
                }
                else if (oldValue == true && newValue == false)
                {
                    window.Height = window.normalSize.Height;
                    window.Width = window.normalSize.Width;
                    window.Left = window.normalPosition.X;
                    window.Top = window.normalPosition.Y;
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when IsMinimized property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void IsMinimizedPropertyChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as WindowEx;

            if (window != null && e.OldValue is bool oldValue && e.NewValue is bool newValue)
            {
                if (window.WindowState == WindowState.Minimized && newValue == false)
                {
                    window.WindowState = WindowState.Normal;
                }
                else if (window.WindowState != WindowState.Minimized && newValue == true)
                {
                    window.WindowState = WindowState.Minimized;
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when WindowState property changes. </summary>
        /// <param name="d"> Dependency object from which event has been invoked. </param>
        /// <param name="e"> Dependency property changed event arguments. </param>
        private static void WindowStatePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var window = d as WindowEx;

            if (window != null && e.OldValue is WindowState oldValue && e.NewValue is WindowState newValue)
            {
                if (oldValue == WindowState.Minimized && newValue != WindowState.Minimized)
                {
                    window.IsMinimized = false;
                }

                if (newValue == WindowState.Maximized)
                {
                    window.WindowState = WindowState.Normal;
                    window.IsMaximized = true;
                }
            }
        }

        #endregion PROPERTIES CHANGED CALLBACKS

        #region RESIZE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when pressing the mouse button while cursor is over title bar. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse button event args. </param>
        private void OnTitleBarMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (IsMaximized)
                {
                    var cursorPosition = new Point(Mouse.GetPosition(null).X + this.Left, Mouse.GetPosition(null).Y + this.Top);

                    double relativeX = cursorPosition.X / this.ActualWidth;
                    double relativeY = cursorPosition.Y / this.ActualHeight;

                    IsMaximized = false;

                    Left = cursorPosition.X - normalSize.Width * relativeX;
                    Top = cursorPosition.Y - normalSize.Height * relativeY;
                }

                DragMove();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when pressing the mouse button while cursor is over a resize border. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse button event args. </param>
        private void OnResizeBorderMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var border = sender as Border;

                if (border == null)
                    return;

                lastMousePosition = e.GetPosition(this);

                switch (border.Name)
                {
                    case "resizeTopLeftBorder":
                        resizeDirection = WindowExResizeDirection.TopLeft;
                        break;

                    case "resizeTopBorder":
                        resizeDirection = WindowExResizeDirection.Top;
                        break;

                    case "resizeTopRightBorder":
                        resizeDirection = WindowExResizeDirection.TopRight;
                        break;

                    case "resizeRightBorderH":
                    case "resizeRightBorderC":
                        resizeDirection = WindowExResizeDirection.Right;
                        break;

                    case "resizeBottomRightBorder":
                        resizeDirection = WindowExResizeDirection.BottomRight;
                        break;

                    case "resizeBottomBorder":
                        resizeDirection = WindowExResizeDirection.Bottom;
                        break;

                    case "resizeBottomLeftBorder":
                        resizeDirection = WindowExResizeDirection.BottomLeft;
                        break;

                    case "resizeLeftBorderH":
                    case "resizeLeftBorderC":
                        resizeDirection = WindowExResizeDirection.Left;
                        break;
                }

                isResizing = true;
                CaptureMouse();
                SetResizeCursor();
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked while moving the cursor over the window. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse event args. </param>
        private void OnWindowMouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                var currentPosition = e.GetPosition(this);
                var deltaX = currentPosition.X - lastMousePosition.X;
                var deltaY = currentPosition.Y - lastMousePosition.Y;

                switch (resizeDirection)
                {
                    case WindowExResizeDirection.TopLeft:
                        SetHeight(Height - deltaY, Top + deltaY);
                        SetWidth(Width - deltaX, Left + deltaX);
                        break;

                    case WindowExResizeDirection.Top:
                        SetHeight(Height - deltaY, Top + deltaY);
                        break;

                    case WindowExResizeDirection.TopRight:
                        SetHeight(Height - deltaY, Top + deltaY);
                        SetWidth(Width + deltaX);
                        lastMousePosition = new Point(currentPosition.X, lastMousePosition.Y);
                        break;

                    case WindowExResizeDirection.Right:
                        SetWidth(Width + deltaX);
                        lastMousePosition = currentPosition;
                        break;

                    case WindowExResizeDirection.BottomRight:
                        SetHeight(Height + deltaY);
                        SetWidth(Width + deltaX);
                        lastMousePosition = currentPosition;
                        break;

                    case WindowExResizeDirection.Bottom:
                        SetHeight(Height + deltaY);
                        lastMousePosition = currentPosition;
                        break;

                    case WindowExResizeDirection.BottomLeft:
                        SetHeight(Height + deltaY);
                        SetWidth(Width - deltaX, Left + deltaX);
                        lastMousePosition = new Point(lastMousePosition.X, currentPosition.Y);
                        break;

                    case WindowExResizeDirection.Left:
                        SetWidth(Width - deltaX, Left + deltaX);
                        break;
                }
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked when releasing the mouse button while cursor is over a window. </summary>
        /// <param name="sender"> Object that invoked the method. </param>
        /// <param name="e"> Mouse button event args. </param>
        private void OnWindowMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isResizing)
            {
                isResizing = false;
                ReleaseMouseCapture();
                Mouse.SetCursor(Cursors.Arrow);
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Sets new window height during resizing. </summary>
        /// <param name="newHeight"> New window height value. </param>
        /// <param name="top"> New top value. </param>
        private void SetHeight(double newHeight, double? top = null)
        {
            if (newHeight <= MinHeight)
            {
                Height = MinHeight;
            }
            else if (newHeight >= MaxHeight)
            {
                Height = MaxHeight;
            }
            else
            {
                Height = newHeight;

                if (top.HasValue)
                    Top = top.Value;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Sets the appropriate cursor according to the resize action. </summary>
        private void SetResizeCursor()
        {
            switch (resizeDirection)
            {
                case WindowExResizeDirection.Top:
                case WindowExResizeDirection.Bottom:
                    Mouse.SetCursor(Cursors.SizeNS);
                    break;

                case WindowExResizeDirection.Left:
                case WindowExResizeDirection.Right:
                    Mouse.SetCursor(Cursors.SizeWE);
                    break;

                case WindowExResizeDirection.TopLeft:
                case WindowExResizeDirection.BottomRight:
                    Mouse.SetCursor(Cursors.SizeNWSE);
                    break;

                case WindowExResizeDirection.TopRight:
                case WindowExResizeDirection.BottomLeft:
                    Mouse.SetCursor(Cursors.SizeNESW);
                    break;

                default:
                    Mouse.SetCursor(Cursors.Arrow);
                    break;
            }
        }

        //  --------------------------------------------------------------------------------
        /// <summary> Sets new window width during resizing. </summary>
        /// <param name="newHeight"> New window width value. </param>
        /// <param name="left"> New left value. </param>
        private void SetWidth(double newWidth, double? left = null)
        {
            if (newWidth <= MinWidth)
            {
                Width = MinWidth;
            }
            else if (newWidth >= MaxWidth)
            {
                Width = MaxWidth;
            }
            else
            {
                Width = newWidth;

                if (left.HasValue)
                    Left = left.Value;
            }
        }

        #endregion RESIZE

        #region TEMPLATE

        //  --------------------------------------------------------------------------------
        /// <summary> Invoked whenever application code or internal processes call ApplyTemplate. </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            normalPosition = new Point(Left, Top);
            normalSize = new Size(Width, Height);

            var titleBar = GetTemplateChild("titleBar") as WindowTitleBarEx;

            if (titleBar != null)
            {
                titleBar.MouseDown += OnTitleBarMouseDown;
                titleBar.CloseButtonClick += OnTitleBarCloseButtonClick;
                titleBar.MaximizeButtonClick += OnTitleBarMaximizeButtonClick;
                titleBar.MinimizeButtonClick += OnTitleBarMinimizeButtonClick;
            }

            foreach (var resizeBorderName in resizeBordersNames)
            {
                var border = GetTemplateChild(resizeBorderName) as Border;
                border.MouseDown += OnResizeBorderMouseDown;
            }
        }

        #endregion TEMPLATE

        #region STYLES

        //  --------------------------------------------------------------------------------
        /// <summary> Get generic WindowTitleBarEx style from resources. </summary>
        /// <returns> WindowTitleBarEx style. </returns>
        protected static Style GetGenericWindowTitleBarExStyle()
        {
            var uri = new Uri("pack://application:,,,/chkam05.Tools.ControlsEx;component/Themes/WindowTitleBarEx.xaml", UriKind.Absolute);
            var resourceDictionary = new ResourceDictionary { Source = uri };
            return resourceDictionary["WindowTitleBarExStyle"] as Style;
        }

        #endregion STYLES

    }
}
